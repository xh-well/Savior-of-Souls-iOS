using UnityEngine;
using System.Collections;

public class FirstTimeSet : MonoBehaviour {


	private int firsttime;
	private int[] firstteamset;


	void Awake()
	{
		firsttime = 0;
	}


	// Use this for initialization
	void Start () {
				if (!ES2.Exists ("FirstTimePlay")) 
				{
						ES2.Save (firsttime, "FirstTimePlay");
						SetFirstSoulTeam(1,2,3,4);
				}
		SetFirstSoulTeam(1,2,3,4);
	}


	void SetFirstSoulTeam(int a,int b,int c,int d)
	{
		int e = 1;

		ES2.Save (a, "LeaderSet?tag=Team1");
		ES2.Save (b, "Member1Set?tag=Team1");
		ES2.Save (c, "Member2Set?tag=Team1");
		ES2.Save (d, "Member3Set?tag=Team1");

		ES2.Save (true, "1?tag=Soul");
		ES2.Save (e, "1?tag=Count");

		ES2.Save (true, "2?tag=Soul");
		ES2.Save (e, "2?tag=Count");

		ES2.Save (true, "3?tag=Soul");
		ES2.Save (e, "3?tag=Count");

		ES2.Save (true, "4?tag=Soul");
		ES2.Save (e, "4?tag=Count");
	}

}
