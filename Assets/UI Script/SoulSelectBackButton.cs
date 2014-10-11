using UnityEngine;
using System.Collections;

public class SoulSelectBackButton : MonoBehaviour {


	public GameObject soulswindow;
	public SoulsWindowState soulswindowstate;

	public GameObject teamwindow;


	void Start()
	{
		soulswindow = GameObject.Find ("SoulsWindow");
		soulswindowstate = soulswindow.GetComponent<SoulsWindowState> ();

		teamwindow = GameObject.Find ("TeamsWindow");
	}

	void OnClick()
	{
		switch (soulswindowstate.playstate) {
		
			case SoulsWindowState.PlayState.Edit:
			TweenPosition.Begin(teamwindow,0.2f,new Vector3 (0,0,0));
			TweenPosition.Begin(soulswindow,0.2f,new Vector3 (1000,0,0));
				break;

			case SoulsWindowState.PlayState.Evo:
				break;

			case SoulsWindowState.PlayState.Sell:
				break;

			case SoulsWindowState.PlayState.Upgrade:
				break;
		}
	}

}
