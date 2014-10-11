using UnityEngine;
using System.Collections;

public class No4Dark : MonoBehaviour {

	public BattleCheck battle;
	public BoardController board;
	public string element = "Earth";
	
	
	public int skillok;
	public UILabel Skill;
	public UIProgressBar energybar;
	
	private bool skillsign;

	public int teamset;

	public GameObject SkillCutShow;

	public GameObject CutScenePos;

	void Awake()
	{
		CutScenePos = GameObject.Find ("CutScenePos");
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

		skillsign = false;
		GameObject battlecheck = GameObject.Find("Battlecheck");
		GameObject boardcontroller = GameObject.Find ("BoardController");
		board = boardcontroller.GetComponent<BoardController> ();
		battle = battlecheck.GetComponent<BattleCheck> ();
		energybar.value = 0;
		skillok = 0;

	}


	IEnumerator Signal()
	{
		Vector3 big = new Vector3 (0.3f, 0, 0.3f);
		Vector3 small = new Vector3 (0.2f, 0, 0.2f);
		Vector3 normal = new Vector3 (0.25f, 0, 0.25f);
		GameObject icon = GameObject.Find ("No4icon");
		while (skillsign)
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
		skillok = BattleCheck.defendcount;
		if (!skillsign)Skill.text = "" + skillok;
		else Skill.text = "OK";
			energybar.value = BattleCheck.Shieldcharge;
		if (Input.GetMouseButtonDown (0) && BattleCheck.defendcount >= 1) {
			ClickMouseAction();
		}

		if (BattleCheck.Shieldcharge >= 1)
		{
			skillsign = true;
			if (BattleCheck.defendcount<1)
			{
			BattleCheck.defendcount +=1;
			StartCoroutine (Signal ());
			}
			BattleCheck.Shieldcharge =0;
		}		




	}




	void ClickMouseAction()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.gameObject.name.Equals ("No4icon"))
			{
				skillsign =false;
				StartCoroutine(SkillActive());
				BattleCheck.defendcount -=1;
			}
		}

	}

	IEnumerator SkillActive()
	{
		battle.SkillActive = true;
		battle.ShowBlack ();
		GameObject cutshow = Instantiate (SkillCutShow, CutScenePos.transform.position, CutScenePos.transform.rotation) as GameObject;
		TweenPosition.Begin (cutshow, 0.3f, new Vector3 (0, 25, 0));
		yield return new WaitForSeconds(2f);
		battle.BlackOut ();
		Destroy (cutshow.gameObject);
		StartCoroutine(board.SetBlockRegular());
		battle.SkillActive = false;
		yield break;

	}


}
