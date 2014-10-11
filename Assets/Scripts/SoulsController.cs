using UnityEngine;
using System.Collections;

public class SoulsController : MonoBehaviour {

	public GameObject[] Souls;
	public Material[] SoulsIcons;
	public Texture[] SoulsShow;



	public No1RedDragon No1;
	public No2BlueDragon No2;
	public No3GreenDragon No3;
	public No4Dark No4;


	public void LeaderSet(int soul)
	{
		switch (soul) 
		{
		case 0:
			No1.teamset =0;
			break;
		case 1:
			No2.teamset =0;
			break;
		case 2:
			No3.teamset =0;
			break;
		case 3:
			No4.teamset =0;
			break;
		}
	}

	public void Member1Set(int soul)
	{
		switch (soul) 
		{
		case 0:
			No1.teamset =1;
			break;
		case 1:
			No2.teamset =1;
			break;
		case 2:
			No3.teamset =1;
			break;
		case 3:
			No4.teamset =1;
			break;
		}
	}

	public void Member2Set(int soul)
	{
		switch (soul) 
		{
		case 0:
			No1.teamset =2;
			break;
		case 1:
			No2.teamset =2;
			break;
		case 2:
			No3.teamset =2;
			break;
		case 3:
			No4.teamset =2;
			break;
		}
	}

	public void Member3Set(int soul)
	{
		switch (soul) 
		{
		case 0:
			No1.teamset =3;
			break;
		case 1:
			No2.teamset =3;
			break;
		case 2:
			No3.teamset =3;
			break;
		case 3:
			No4.teamset =3;
			break;
		}
	}
		
}
