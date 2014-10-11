using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleCheck : MonoBehaviour {

	public static float firecharge;
	public static float watercharge;
	public static float earthcharge;
	public static float Shieldcharge;

	public static string LeaderElement;
	public static string Member1Element;
	public static string Member2Element;

	public static int defendcount;
	public static int fireelementcount;
	public static int waterelementcount;
	public static int earthelemetcount;

	public static float totalfireattack=0;
	public static float totalwaterattack=0;
	public static float totalearthattack=0;

	public static float enemyfireattack = 0;
	public static float enemywaterattack = 0;
	public static float enemyearthattack = 0;

	public static float firehp=0;
	public static float waterhp=0;
	public static float earthhp=0;

	//for player
	public static float teamhp;
	public static float nowteamhp;
	private float reduceteamhp;
	private float hppercent;
	private float damage;

	//for enemy
	public static float enemyhp;
	public static float nowenemyhp;
	private float reduceenemyhp;
	private float enemyhppercent;
	private float enemydamage;

	public UIProgressBar enemyhealth;
	public UILabel EHealth;


	public GameObject Fireattack;
	public GameObject Waterattack;
	public GameObject Earthattack;
	public GameObject Shieldprotect;

	public GameObject Enemyfire;
	public GameObject Enemywater;
	public GameObject Enemyearth;


	public List<Transform> fireelement = new List<Transform>();
	public List<Transform> waterelement = new List<Transform>();
	public List<Transform> earthelement = new List<Transform>();
	public List<Transform> enemyelement = new List<Transform> ();
	public UILabel Health;
	public UIProgressBar hpbar;
	public GameObject HP;

	private float attackrate;

	private float playerhpvalue;
	private float enemyhpvalue;


	public GameObject Leader;
	public GameObject Member1;
	public GameObject Member2;
	public GameObject Member3;

	public static GameObject Leaderset;
	public static GameObject Member1set;
	public static GameObject Member2set;
	public static GameObject Member3set;

	public SoulsController Allsouls;



	public Transform backposition;

	public GameObject SkillShowBlack;

	public bool SkillActive;


	//Set for every wave's enemysummon
	public static int battlewave;
	public static int[] waveenemy;


	void Awake()
	{
				SkillActive = false;
				TweenAlpha.Begin (SkillShowBlack, 0.5f, 0);


				//set for player's soul
		Leaderset = Allsouls.Souls		 [0];
		Allsouls.LeaderSet (0);
		Member1set = Allsouls.Souls [1];
		Allsouls.Member1Set (1);
		Member2set = Allsouls.Souls [2];
		Allsouls.Member2Set (2);
		Member3set = Allsouls.Souls [3];
		Allsouls.Member3Set (3);


		//set player's soul into gameobject position
		GameObject leaders = Instantiate (Leaderset, Leader.transform.position, Leader.transform.rotation) as GameObject;
		leaders.transform.parent = Leader.transform;

		GameObject members1 = Instantiate (Member1set, Member1.transform.position, Member1.transform.rotation) as GameObject;
		members1.transform.parent = Member1.transform;

		GameObject members2 = Instantiate (Member2set, Member2.transform.position, Member2.transform.rotation) as GameObject;
		members2.transform.parent = Member2.transform;

		GameObject members3 = Instantiate (Member3set, Member3.transform.position, Member3.transform.rotation) as GameObject;
		members3.transform.parent = Member3.transform;


		playerhpvalue = 1;
		enemyhpvalue = 1;
	}

	//skill active blackscreen
	public void ShowBlack()
	{
		TweenAlpha.Begin (SkillShowBlack, 0.5f,1);
	}

	//after skill finished 
	public void BlackOut()
	{
		TweenAlpha.Begin (SkillShowBlack, 0.5f,0);
	}


	void Start()
	{

		teamhp = firehp + waterhp + earthhp;
		nowteamhp = teamhp;
		reduceteamhp = teamhp;
		nowenemyhp = enemyhp;
		reduceenemyhp = enemyhp;
		firecharge = 0;
		watercharge = 0;
		earthcharge = 0;
		Shieldcharge = 0;
		defendcount = 0;
		fireelementcount = 0;
		waterelementcount = 0;
		earthelemetcount = 0;

		hppercent = teamhp / 100;
		enemyhppercent = enemyhp / 100;
	}

	void Update()
	{
		Health.text =Mathf.FloorToInt(nowteamhp)+ "/"+ teamhp;
		EHealth.text = Mathf.FloorToInt (nowenemyhp) + "/" + enemyhp;

		hpbar.value = playerhpvalue;
		enemyhealth.value = enemyhpvalue;


		if (nowteamhp < 0)
		{
			nowteamhp =0;
			reduceteamhp =0;
			playerhpvalue = 0;
		}
		if (nowteamhp > teamhp) {
			nowteamhp =teamhp;
			playerhpvalue =1;
			reduceteamhp =teamhp;
		}

		if (nowenemyhp < 0) {
			nowenemyhp =0;
			reduceenemyhp =0;
			enemyhpvalue = 0;
		}


		if (reduceteamhp >= nowteamhp) {
						if (reduceteamhp - nowteamhp >= hppercent) {
								playerhpvalue -= 0.01f;
								reduceteamhp -= hppercent;
						}
				}

		if (reduceteamhp < nowteamhp) {
			if (nowteamhp - reduceteamhp >= hppercent) {
				playerhpvalue += 0.01f;
				reduceteamhp += hppercent;
			}
		}

		if (reduceenemyhp >= nowenemyhp) {
						if (reduceenemyhp - nowenemyhp >= enemyhppercent) {
								enemyhpvalue -= 0.01f;
								reduceenemyhp -= enemyhppercent;
						}
				}
	}

	//Damaged by Enemy
	public void PlayerDamaged(float rate , string elements)
	{
		if (elements == "Fire") {
			nowteamhp -= (enemyfireattack * rate);
		}
		if (elements == "Water") {
			nowteamhp -= (enemywaterattack * rate);
		}
		if (elements == "Earth") {
			nowteamhp -= (enemyearthattack * rate);
		}

	}

	//Damaged by Player
	public void EnemyDamaged(float rate,string elements)
	{
		if (elements == "Fire") {
						nowenemyhp -= (totalfireattack * rate);
				}
		if (elements == "Water") {
			nowenemyhp -= (totalwaterattack * rate);
		}
		if (elements == "Earth") {
			nowenemyhp -= (totalearthattack * rate);
		}


	}

	//enemy position
	public void Enemyelement(Transform enemy)
	{
		enemyelement.Add (enemy);

	}

	//playerposition of fire
	public void Fireelementcheck(Transform fire)
	{
		fireelement.Add (fire);
		fireelementcount ++;

	}

	//playerposition of water
	public void Waterelementcheck(Transform water)
	{
		waterelement.Add (water);
		waterelementcount ++;
	}

	//playerposition of earth
	public void Earthelementcheck(Transform earth)
	{
		earthelement.Add (earth);
		earthelemetcount ++;
	}

	//enemy attack from there position
	public void EnemyFire(float enemyattack)
	{
		GameObject redball = Instantiate (Enemyfire, enemyelement [0].transform.position, enemyelement [0].transform.rotation) as GameObject;
		TweenPosition.Begin (redball, 0.5f, this.transform.position);
	}

	public void EnemyWater(float enemyattack)
	{
		GameObject blueball = Instantiate (Enemywater, enemyelement [0].transform.position, enemyelement [0].transform.rotation) as GameObject;
		TweenPosition.Begin (blueball, 0.5f, this.transform.position);
	}

	public void EnemyEarth(float enemyattack)
	{
	GameObject greenball = Instantiate (Enemyearth, enemyelement [0].transform.position, enemyelement [0].transform.rotation) as GameObject;
	TweenPosition.Begin (greenball, 0.5f, this.transform.position);
	}

	public void EnemySkill(int skill)
	{
	}

	//check charge bar to show the attacker soul
	public IEnumerator RollingAttacks(int attacker, string elements)
	{ 
		switch (attacker)
		{
			//Leader Position
		case 0:
			if (elements == "fire")
			{
				TweenPosition.Begin(Leader,0.1f,this.transform.position);
				TweenPosition.Begin(Member1,0.1f,backposition.position);
				TweenPosition.Begin(Member2,0.1f,backposition.position);
				TweenPosition.Begin(Member3,0.1f,backposition.position);
				yield return new WaitForSeconds(0.1f);
				GameObject redball = Instantiate(Fireattack,Leader.transform.position,Leader.transform.rotation) as GameObject;
				TweenPosition.Begin (redball,0.5f,enemyelement[0].transform.position);
			}
			else if (elements == "water")
			{
				TweenPosition.Begin(Leader,0.1f,this.transform.position);
				TweenPosition.Begin(Member1,0.1f,backposition.position);
				TweenPosition.Begin(Member2,0.1f,backposition.position);
				TweenPosition.Begin(Member3,0.1f,backposition.position);
				yield return new WaitForSeconds(0.1f);
				GameObject blueball = Instantiate(Waterattack,Leader.transform.position,Leader.transform.rotation) as GameObject;
				TweenPosition.Begin(blueball,0.5f,enemyelement[0].transform.position);
			}
			else if (elements == "earth")
			{
				TweenPosition.Begin(Leader,0.1f,this.transform.position);
				TweenPosition.Begin(Member1,0.1f,backposition.position);
				TweenPosition.Begin(Member2,0.1f,backposition.position);
				TweenPosition.Begin(Member3,0.1f,backposition.position);
				yield return new WaitForSeconds(0.1f);
				GameObject greenball = Instantiate(Earthattack,Leader.transform.position,Leader.transform.rotation) as GameObject;
				TweenPosition.Begin(greenball,0.5f,enemyelement[0].transform.position);
			}
			
			break;

			//Member1 Position
		case 1:
			if (elements == "fire")
			{
				TweenPosition.Begin(Leader,0.1f,backposition.position);
				TweenPosition.Begin(Member1,0.1f,this.transform.position);
				TweenPosition.Begin(Member2,0.1f,backposition.position);
				TweenPosition.Begin(Member3,0.1f,backposition.position);
				yield return new WaitForSeconds(0.1f);
				GameObject redball = Instantiate(Fireattack,Leader.transform.position,Leader.transform.rotation) as GameObject;
				TweenPosition.Begin (redball,0.5f,enemyelement[0].transform.position);
			}
			else if (elements == "water")
			{
				TweenPosition.Begin(Leader,0.1f,backposition.position);
				TweenPosition.Begin(Member1,0.1f,this.transform.position);
				TweenPosition.Begin(Member2,0.1f,backposition.position);
				TweenPosition.Begin(Member3,0.1f,backposition.position);
				yield return new WaitForSeconds(0.1f);
				GameObject blueball = Instantiate(Waterattack,Leader.transform.position,Leader.transform.rotation) as GameObject;
				TweenPosition.Begin(blueball,0.5f,enemyelement[0].transform.position);
			}
			else if (elements == "earth")
			{
				TweenPosition.Begin(Leader,0.1f,backposition.position);
				TweenPosition.Begin(Member1,0.1f,this.transform.position);
				TweenPosition.Begin(Member2,0.1f,backposition.position);
				TweenPosition.Begin(Member3,0.1f,backposition.position);
				yield return new WaitForSeconds(0.1f);
				GameObject greenball = Instantiate(Earthattack,Leader.transform.position,Leader.transform.rotation) as GameObject;
				TweenPosition.Begin(greenball,0.5f,enemyelement[0].transform.position);
			}
			
			
			break;

			//Member2 Position
		case 2:
			if (elements == "fire")
			{
				TweenPosition.Begin(Leader,0.1f,backposition.position);
				TweenPosition.Begin(Member1,0.1f,backposition.position);
				TweenPosition.Begin(Member2,0.1f,this.transform.position);
				TweenPosition.Begin(Member3,0.1f,backposition.position);
				yield return new WaitForSeconds(0.1f);
				GameObject redball = Instantiate(Fireattack,Leader.transform.position,Leader.transform.rotation) as GameObject;
				TweenPosition.Begin (redball,0.5f,enemyelement[0].transform.position);
			}
			else if (elements == "water")
			{
				TweenPosition.Begin(Leader,0.1f,backposition.position);
				TweenPosition.Begin(Member1,0.1f,backposition.position);
				TweenPosition.Begin(Member2,0.1f,this.transform.position);
				TweenPosition.Begin(Member3,0.1f,backposition.position);
				yield return new WaitForSeconds(0.1f);
				GameObject blueball = Instantiate(Waterattack,Leader.transform.position,Leader.transform.rotation) as GameObject;
				TweenPosition.Begin(blueball,0.5f,enemyelement[0].transform.position);
			}
			else if (elements == "earth")
			{
				TweenPosition.Begin(Leader,0.1f,backposition.position);
				TweenPosition.Begin(Member1,0.1f,backposition.position);
				TweenPosition.Begin(Member2,0.1f,this.transform.position);
				TweenPosition.Begin(Member3,0.1f,backposition.position);
				yield return new WaitForSeconds(0.1f);
				GameObject greenball = Instantiate(Earthattack,Leader.transform.position,Leader.transform.rotation) as GameObject;
				TweenPosition.Begin(greenball,0.5f,enemyelement[0].transform.position);
			}
			break;

			//Member3 Position
		case 3:
			if (elements == "fire")
			{
				TweenPosition.Begin(Leader,0.1f,backposition.position);
				TweenPosition.Begin(Member1,0.1f,backposition.position);
				TweenPosition.Begin(Member2,0.1f,backposition.position);
				TweenPosition.Begin(Member3,0.1f,this.transform.position);
				yield return new WaitForSeconds(0.1f);
				GameObject redball = Instantiate(Fireattack,Leader.transform.position,Leader.transform.rotation) as GameObject;
				TweenPosition.Begin (redball,0.5f,enemyelement[0].transform.position);
			}
			else if (elements == "water")
			{
				TweenPosition.Begin(Leader,0.1f,backposition.position);
				TweenPosition.Begin(Member1,0.1f,backposition.position);
				TweenPosition.Begin(Member2,0.1f,backposition.position);
				TweenPosition.Begin(Member3,0.1f,this.transform.position);
				yield return new WaitForSeconds(0.1f);
				GameObject blueball = Instantiate(Waterattack,Leader.transform.position,Leader.transform.rotation) as GameObject;
				TweenPosition.Begin(blueball,0.5f,enemyelement[0].transform.position);
			}
			else if (elements == "earth")
			{
				TweenPosition.Begin(Leader,0.1f,backposition.position);
				TweenPosition.Begin(Member1,0.1f,backposition.position);
				TweenPosition.Begin(Member2,0.1f,backposition.position);
				TweenPosition.Begin(Member3,0.1f,this.transform.position);
				yield return new WaitForSeconds(0.1f);
				GameObject greenball = Instantiate(Earthattack,Leader.transform.position,Leader.transform.rotation) as GameObject;
				TweenPosition.Begin(greenball,0.5f,enemyelement[0].transform.position);
			}

			break;
			
			
		}
		
		
		
		yield break;
	}


	//fire attack charge
	public void Fire()
	{
		firecharge += 0.1f;		
	}
	//fire attack
	public void FireAttack(int teamset)
	{	
		/*
		for (int i =0; i<fireelement.Count; i++) {
			GameObject redball = Instantiate (Fireattack, fireelement [i].position, fireelement [i].rotation) as GameObject;
			TweenPosition.Begin (redball, 0.5f, enemyelement[0].transform.position);
		}
		*/


		StartCoroutine (RollingAttacks (teamset,"fire"));

	}



	//water attack charge
	public void Water()
	{
		watercharge += 0.1f;
	}

	//water attack
	public void WaterAttack(int teamset)
	{/*
		for (int i =0; i<waterelement.Count; i++) {
			GameObject blueball = Instantiate(Waterattack,waterelement[i].position,waterelement[i].rotation) as GameObject;	
			TweenPosition.Begin(blueball,0.5f,enemyelement[0].transform.position);
		}*/

		StartCoroutine (RollingAttacks (teamset,"water"));
	
	}

	//earth attack charge 
	public void Earth()
	{
		earthcharge += 0.1f;
	}

	//earth attack
	public void EarthAttack(int teamset)
	{
		/*
		for (int i =0; i<earthelement.Count; i++) {
			GameObject greenball = Instantiate(Earthattack,earthelement[i].position,earthelement[i].rotation) as GameObject;	
			TweenPosition.Begin(greenball,0.5f,enemyelement[0].transform.position);
		}*/

		StartCoroutine (RollingAttacks (teamset,"earth"));
	
	}


	public void Shield()
	{
		Shieldcharge += 0.05f;
	}

	void OnTriggerEnter(Collider other)
	{
		attackrate = 1;
		float rate = 1f;
		if (other.tag.CompareTo("EnemyFire")==0) {



			if (earthelemetcount>0)
			{
				attackrate +=1f*earthelemetcount;
				if (waterelementcount>0)
				{
					for (int i=0;i<waterelementcount;i++)
					{
						rate *=0.5f;
					}
					attackrate -=(1-rate);
				}
			}

			PlayerDamaged(attackrate , "Fire");
		}


		if (other.tag.CompareTo("EnemyWater")==0) {
			if (fireelementcount>0)
			{
				attackrate += 1f*fireelementcount;
				if (earthelemetcount>0)
				{

					for (int i=0;i<earthelemetcount;i++)
					{
						rate *=0.5f;
					}
					
					attackrate -=(1-rate);
					
				}
			}

			PlayerDamaged(attackrate,"Water");
		}


		if (other.tag.CompareTo("EnemyEarth")==0) {


			if (waterelementcount>0)
			{
				attackrate += 1f*waterelementcount;
				if (fireelementcount>0)
				{
					for (int i=0;i<fireelementcount;i++)
					{
						rate *=0.5f;
					}
					
					attackrate -=(1-rate);
				}
			}
			PlayerDamaged(attackrate,"Earth");
		}



	}





}
