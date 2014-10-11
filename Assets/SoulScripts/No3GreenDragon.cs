using UnityEngine;
using System.Collections;

public class No3GreenDragon : MonoBehaviour {
	
	public BattleCheck battle;
	public BoardController board;
	
	public float hp=900;
	public float atk=50;
	public string element = "Earth";
	
	
	public bool skillok;
	public UILabel Skill;
	public UIProgressBar energybar;

	public int skillcountdown;

	public int teamset;




	public GameObject SkillCutShow;
	public GameObject CutScenePos;



	void Awake()
	{
		BattleCheck.totalearthattack += atk;
		BattleCheck.earthhp += hp;
		skillcountdown = 5;
	}

	void Start ()
	{




		GameObject boardcontroller = GameObject.Find ("BoardController");
		board = boardcontroller.GetComponent<BoardController> ();

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
		battle = battlecheck.GetComponent<BattleCheck> ();
		battle.Earthelementcheck (this.transform);
		energybar.value = 0;
		hp = 900;
		skillok = false; 

	}


	
	IEnumerator Signal()
	{
		Vector3 big = new Vector3 (0.3f, 0, 0.3f);
		Vector3 small = new Vector3 (0.2f, 0, 0.2f);
		Vector3 normal = new Vector3 (0.25f, 0, 0.25f);
		GameObject icon = GameObject.Find ("No3icon");
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

		energybar.value = BattleCheck.earthcharge;
		
		if (BattleCheck.earthcharge >= 1)
		{

			BattleCheck.earthcharge =0;
			battle.EarthAttack(teamset);
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
			if (hit.transform.gameObject.name.Equals ("No3icon"))
			{
				skillok = false;
				StartCoroutine(SkillActive());

			}
		}
		
	}


	IEnumerator SkillActive()
	{

		yield break;
		
	}






}
