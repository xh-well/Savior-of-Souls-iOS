using UnityEngine;
using System.Collections;

public class No2BlueDragon : MonoBehaviour {

	public BoardController board;
	public bool enemyor;
	public BattleCheck battle;
	
	public float hp=700;
	public float atk=70;
	public string element = "Water";
	public bool skillok;
	private bool activeskill;
	public UILabel Skill;
	public UIProgressBar energybar;
	public ParticleSystem skillstart;
	public int skillcountdown;
	private int skillcount;
	public int teamset;



	void Awake()
	{
		BattleCheck.totalwaterattack += atk;
		BattleCheck.waterhp += hp;
		skillcountdown = 5;
	}
	void Start ()
	{

		switch (teamset)
		{
		case 0:
			GameObject LeaderEnergy = GameObject.Find ("LeaderEnergyBar");
			energybar = LeaderEnergy.GetComponent<UIProgressBar> ();
			GameObject LeaderSkill = GameObject.Find ("LeaderLabel");
			Skill = LeaderSkill.GetComponent<UILabel> ();
			break;
			
		case 1:
			GameObject Member1Energy = GameObject.Find ("Member1EnergyBar");
			energybar = Member1Energy.GetComponent<UIProgressBar> ();
			GameObject Member1Skill = GameObject.Find ("Member1Label");
			Skill = Member1Skill.GetComponent<UILabel> ();
			break;
			
		case 2:
			GameObject Member2Energy = GameObject.Find ("Member2EnergyBar");
			energybar = Member2Energy.GetComponent<UIProgressBar> ();
			GameObject Member2Skill = GameObject.Find ("Member2Label");
			Skill = Member2Skill.GetComponent<UILabel> ();
			break;
			
		case 3:
			GameObject Member3Energy = GameObject.Find ("Member3EnergyBar");
			energybar = Member3Energy.GetComponent<UIProgressBar> ();
			GameObject Member3Skill = GameObject.Find ("Member3Label");
			Skill = Member3Skill.GetComponent<UILabel> ();
			break;
		}

		GameObject boardcontrooler = GameObject.Find ("BoardController");
		GameObject battlecheck = GameObject.Find("Battlecheck");
		battle = battlecheck.GetComponent<BattleCheck> ();
		board = boardcontrooler.GetComponent<BoardController> ();

		battle.Waterelementcheck (this.transform);
		energybar.value = 0;
		skillcount = 0;
		hp = 700;
		skillok = false; 
		activeskill = false;
	}

	IEnumerator Signal()
	{
		Vector3 big = new Vector3 (0.3f, 0, 0.3f);
		Vector3 small = new Vector3 (0.2f, 0, 0.2f);
		Vector3 normal = new Vector3 (0.25f, 0, 0.25f);
		GameObject icon = GameObject.Find ("No2icon");
		
		while (skillok)
		{
			TweenScale.Begin (icon, 0.2f, big);
			yield return new WaitForSeconds (0.2f);
			TweenScale.Begin (icon, 0.2f, small);
			yield return new WaitForSeconds (0.2f);
			TweenScale.Begin (icon, 0.2f, normal);
			yield return new WaitForSeconds (0.2f);
		}
	}

	void Update()
	{
		if (!skillok) {
			Skill.text = "" + skillcountdown;
		} else {
			Skill.text = "OK";		
		}

		if (Input.GetMouseButtonDown (0) && skillok) {
			ClickMouseAction();		
		}

		if (Input.GetMouseButtonDown (0) && activeskill) 
		{
			ClickMouseBreak();
		}
		//Stop Skill
		if (skillcount ==3)
		{
			skillstart.Stop();
		}

		if (skillcount ==4)
		{	
			BoardController.chainbreaker =false;
		}
		if (!BoardController.chainbreaker) {
						
			skillcount =0;
			activeskill = false;

		}
		
		energybar.value = BattleCheck.watercharge;
		
		if (BattleCheck.watercharge >= 1)
		{

			BattleCheck.watercharge =0;
			battle.WaterAttack(teamset);

			if (!skillok) skillcountdown -= 1;
			if (skillcountdown ==0)
			{
				skillok =true;
				skillcountdown = 5;
				StartCoroutine(Signal());
			}
		}
	}

	void ClickMouseAction()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.gameObject.name.Equals ("No2icon"))
			{
				skillok =false;
				GameObject No2icon = GameObject.Find("No2icon");
				skillstart.transform.position = No2icon.transform.position;
				skillstart.Play();
				activeskill = true;
				BoardController.chainbreaker = true;
			}
		}	
	}

	void ClickMouseBreak()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.gameObject.name.Equals ("Brick(Clone)"))
			{
			skillcount +=1;
			}
			}
	}





}
