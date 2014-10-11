using UnityEngine;
using System.Collections;

public class No1RedDragon : MonoBehaviour {

	public BattleCheck battle;
	public BoardController board;

	public int Soul_No=1;
	private string Soul_ID ="嵐蛟龍";

	public float hp=500;
	public float atk=100;
	public string element = "Fire";


	public bool skillok;
	public UILabel Skill;
	public int skillcountdown;
	public UIProgressBar energybar;

	public int teamset;




	void Awake()
	{	
		BattleCheck.totalfireattack += atk;
		BattleCheck.firehp += hp;
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
		



		GameObject battlecheck = GameObject.Find("Battlecheck");
		GameObject boardcontroller = GameObject.Find ("BoardController");
		board = boardcontroller.GetComponent<BoardController> ();
		battle = battlecheck.GetComponent<BattleCheck> ();

		battle.Fireelementcheck (this.transform);
		energybar.value = 0;
		hp = 500;
		skillok = false; 


	}

	IEnumerator Signal()
	{
		Vector3 big = new Vector3 (0.3f, 0, 0.3f);
		Vector3 small = new Vector3 (0.2f, 0, 0.2f);
		Vector3 normal = new Vector3 (0.25f, 0, 0.25f);

		GameObject icon = GameObject.Find ("No1icon");


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
				Skill.text= "" + skillcountdown;
				} else {
			Skill.text = "OK";		
		}

		energybar.value = BattleCheck.firecharge;

		if (Input.GetMouseButtonDown (0) && skillok) {
			ClickMouseAction();
		}

		if (BattleCheck.firecharge >= 1)
		{
			BattleCheck.firecharge =0;
			battle.FireAttack(teamset);
			//StartCoroutine(battle.FireAttacks());
			if (!skillok)
			{
			skillcountdown -= 1;
			}
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
			if (hit.transform.gameObject.name.Equals ("No1icon"))
			{
				skillok = false;
				board.RuneChangeFire();
			}
		}
		
	}


}
