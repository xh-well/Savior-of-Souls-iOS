using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	public enum MenuButtons {MainPage,SoulsPage,ShopPage,FriendsPage,SummonPage,MapPage};

	public MenuButtons menubuttons;


	void OnClick()
	{
		switch (menubuttons) {
		
		case MenuButtons.MainPage:
			Application.LoadLevel("MainPage");
			break;

		case MenuButtons.FriendsPage:
			Application.LoadLevel("FriendsPage");
			break;

		case MenuButtons.MapPage:
			Application.LoadLevel("MapPage");
			break;

		case MenuButtons.ShopPage:
			Application.LoadLevel("ShopPage");
			break;

		case MenuButtons.SoulsPage:
			Application.LoadLevel("SoulPage");
			break;

		case MenuButtons.SummonPage:
			Application.LoadLevel("SummonPage");
			break;
		}


	}

}
