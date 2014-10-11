using UnityEngine;
using System.Collections;

public class TeamCenterCheck : MonoBehaviour {



	public GameObject RightArrow;
	public GameObject LeftArrow;
	public GameObject center;
	public UICenterOnChild CenterCheck;

	void Start()
	{
		center = GameObject.Find("TeamPanel");
		CenterCheck = center.GetComponent<UICenterOnChild> ();
		RightArrow = GameObject.Find ("RightArrow");
		LeftArrow = GameObject.Find ("LeftArrow");
	}
	void Update()
	{
		if (CenterCheck.centeredObject == GameObject.Find("Team1")) {
			TweenAlpha.Begin (LeftArrow, 0, 0);
		} else {
			TweenAlpha.Begin (LeftArrow, 0, 1);
		}
		
		if (CenterCheck.centeredObject == GameObject.Find ("Team5")) {
			TweenAlpha.Begin (RightArrow, 0, 0);		
		} else {
			TweenAlpha.Begin(RightArrow,0,1);		
		}
		
		
	}
}
