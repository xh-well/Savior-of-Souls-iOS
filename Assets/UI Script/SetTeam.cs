using UnityEngine;
using System.Collections;

public class SetTeam : MonoBehaviour {

	public enum TeamSet {Team1,Team2,Team3,Team4,Team5};
	public enum TeamMembers{Leader,Member1,Member2};

	public TeamSet teamset;
	public TeamMembers teammembers;

	public GameObject TeamsWindow;
	public GameObject SoulsWindow;

	void Start()
	{
		TeamsWindow = GameObject.Find("TeamsWindow");
		SoulsWindow = GameObject.Find ("SoulsWindow");
	}



	void OnClick()
	{
		switch (teamset)
		{
		case TeamSet.Team1:

			switch (teammembers)
			{
			case TeamMembers.Leader:
				TweenPosition.Begin(TeamsWindow,0.3f,new Vector3 (1000,0,0));
				TweenPosition.Begin(SoulsWindow,0.3f,new Vector3 (0,0,0));
				break;

			case TeamMembers.Member1:
				TweenPosition.Begin(TeamsWindow,0.3f,new Vector3 (1000,0,0));
				TweenPosition.Begin(SoulsWindow,0.3f,new Vector3 (0,0,0));
				break;

			case TeamMembers.Member2:
				TweenPosition.Begin(TeamsWindow,0.3f,new Vector3 (1000,0,0));
				TweenPosition.Begin(SoulsWindow,0.3f,new Vector3 (0,0,0));
				break;
			}

			break;

		case TeamSet.Team2:

			switch (teammembers)
			{
			case TeamMembers.Leader:
				TweenPosition.Begin(TeamsWindow,0.3f,new Vector3 (1000,0,0));
				TweenPosition.Begin(SoulsWindow,0.3f,new Vector3 (0,0,0));
				break;
				
			case TeamMembers.Member1:
				TweenPosition.Begin(TeamsWindow,0.3f,new Vector3 (1000,0,0));
				TweenPosition.Begin(SoulsWindow,0.3f,new Vector3 (0,0,0));
				break;
				
			case TeamMembers.Member2:
				TweenPosition.Begin(TeamsWindow,0.3f,new Vector3 (1000,0,0));
				TweenPosition.Begin(SoulsWindow,0.3f,new Vector3 (0,0,0));
				break;
			}
			break;

		case TeamSet.Team3:

			switch (teammembers)
			{
			case TeamMembers.Leader:
				TweenPosition.Begin(TeamsWindow,0.3f,new Vector3 (1000,0,0));
				TweenPosition.Begin(SoulsWindow,0.3f,new Vector3 (0,0,0));
				break;
				
			case TeamMembers.Member1:
				TweenPosition.Begin(TeamsWindow,0.3f,new Vector3 (1000,0,0));
				TweenPosition.Begin(SoulsWindow,0.3f,new Vector3 (0,0,0));
				break;
				
			case TeamMembers.Member2:
				TweenPosition.Begin(TeamsWindow,0.3f,new Vector3 (1000,0,0));
				TweenPosition.Begin(SoulsWindow,0.3f,new Vector3 (0,0,0));
				break;
			}
			break;

		case TeamSet.Team4:

			switch (teammembers)
			{
			case TeamMembers.Leader:
				TweenPosition.Begin(TeamsWindow,0.3f,new Vector3 (1000,0,0));
				TweenPosition.Begin(SoulsWindow,0.3f,new Vector3 (0,0,0));
				break;
				
			case TeamMembers.Member1:
				TweenPosition.Begin(TeamsWindow,0.3f,new Vector3 (1000,0,0));
				TweenPosition.Begin(SoulsWindow,0.3f,new Vector3 (0,0,0));
				break;
				
			case TeamMembers.Member2:
				TweenPosition.Begin(TeamsWindow,0.3f,new Vector3 (1000,0,0));
				TweenPosition.Begin(SoulsWindow,0.3f,new Vector3 (0,0,0));
				break;
			}
			break;

		case TeamSet.Team5:

			switch (teammembers)
			{
			case TeamMembers.Leader:
				TweenPosition.Begin(TeamsWindow,0.3f,new Vector3 (1000,0,0));
				TweenPosition.Begin(SoulsWindow,0.3f,new Vector3 (0,0,0));
				break;
				
			case TeamMembers.Member1:
				TweenPosition.Begin(TeamsWindow,0.3f,new Vector3 (1000,0,0));
				TweenPosition.Begin(SoulsWindow,0.3f,new Vector3 (0,0,0));
				break;
				
			case TeamMembers.Member2:
				TweenPosition.Begin(TeamsWindow,0.3f,new Vector3 (1000,0,0));
				TweenPosition.Begin(SoulsWindow,0.3f,new Vector3 (0,0,0));
				break;
			}
			break;

		}
	}


}
