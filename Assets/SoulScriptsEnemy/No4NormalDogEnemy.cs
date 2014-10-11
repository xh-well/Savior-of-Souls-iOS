using UnityEngine;
using System.Collections;

public class No4NormalDogEnemy : MonoBehaviour {

	public BattleCheck battle;
	
	public float hp=2000;
	public float atk=100;
	public string element = "Earth";
	public UIProgressBar energybar;
	public UIProgressBar HP;
	public bool enemyset;
	public int skillboost;

	private float rate;
	void Awake()
	{
		rate = 1;
		skillboost = 5;
		if (enemyset) 
		{
			BattleCheck.enemyearthattack +=atk;
			BattleCheck.enemyhp+=hp;
		}
	}
	void Start ()
	{
		if (enemyset) {
						GameObject battlecheck = GameObject.Find ("Battlecheck");
						battle = battlecheck.GetComponent<BattleCheck> ();
						battle.Enemyelement (this.transform);
						energybar.value = 0;
						
				}
	}

	void Update()
	{
		if (enemyset && !battle.SkillActive) {
			energybar.value += 0.1f * Time.deltaTime;
				if (energybar.value ==1)
				{
				battle.EnemyEarth(atk);
				energybar.value =0;
				skillboost-=1;
					if (skillboost ==0)
					{
					battle.EnemySkill(0);
					skillboost = 5;
					}
				}
			}
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.tag.CompareTo("Fire")==0) {
			rate = 2;
			battle.EnemyDamaged(rate,"Fire");
			StartCoroutine(scalechange());
		}
		if (other.tag.CompareTo("Water")==0) {
			rate = 0.5f;
			battle.EnemyDamaged(rate,"Water");	
			StartCoroutine(scalechange());
		}
		if (other.tag.CompareTo("Earth")==0) {
			rate = 1;
			battle.EnemyDamaged(rate,"Earth");
			StartCoroutine(scalechange());
		}	
	}

	IEnumerator scalechange()
	{
		Vector3 big = new Vector3 (1.5f, 1, 1f);
		Vector3 small = new Vector3 (0.5f, 1, 0.3f);
		Vector3 normal = new Vector3 (1, 1, 0.7f);
		
		TweenScale.Begin (this.gameObject, 0.2f, big);
		yield return new WaitForSeconds (0.2f);
		TweenScale.Begin (this.gameObject, 0.2f, small);
		yield return new WaitForSeconds (0.2f);
		TweenScale.Begin (this.gameObject, 0.2f, normal);
		yield return new WaitForSeconds (0.2f);
		yield break;
	}



}

