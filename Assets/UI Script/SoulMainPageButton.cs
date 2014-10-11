using UnityEngine;
using System.Collections;

public class SoulMainPageButton : MonoBehaviour {
	//Check for Button Type
	public enum SoulsButton {TeamEdit,Evolution,PowerUp,Release,Collection,EvoItem,TeamBackButton};
	
	public SoulsButton soulsbutton;

	//check for the playstate 
	public GameObject SoulsWindows;
	public SoulsWindowState soulswindowstate;

	public GameObject TeamsWindow;
	public GameObject SoulsMainPage;




	void Start()
	{

		SoulsWindows = GameObject.Find ("SoulsWindow");
		soulswindowstate = SoulsWindows.GetComponent<SoulsWindowState> ();

		TeamsWindow = GameObject.Find ("TeamsWindow");
		SoulsMainPage = GameObject.Find ("SoulsMainPage");
	}




	void OnClick()
	{
		switch (soulsbutton) {

		case SoulsButton.TeamEdit:

			TweenPosition.Begin(TeamsWindow,0.3f,new Vector3 (0,0,0));
			TweenPosition.Begin(SoulsMainPage,0.3f,new Vector3 (-1000,0,0));
			soulswindowstate.playstate = SoulsWindowState.PlayState.Edit;
			Debug.Log("TeamEdit");
			break;

		case SoulsButton.TeamBackButton:
			TweenPosition.Begin(TeamsWindow,0.3f,new Vector3 (1000,0,0));
			TweenPosition.Begin(SoulsMainPage,0.3f,new Vector3(0,0,0));
			break;

		case SoulsButton.Collection:
			Debug.Log("Collection");
			break;
		
		case SoulsButton.EvoItem:
			Debug.Log("EvoItem");
			break;

		case SoulsButton.Evolution:

			soulswindowstate.playstate = SoulsWindowState.PlayState.Evo;
			Debug.Log("Evolution");
			break;

		case SoulsButton.PowerUp:

			soulswindowstate.playstate = SoulsWindowState.PlayState.Upgrade;
			Debug.Log("PowerUp");
			break;

		case SoulsButton.Release:

			soulswindowstate.playstate = SoulsWindowState.PlayState.Sell;
			Debug.Log("Release");
			break;
		}
	}

}
