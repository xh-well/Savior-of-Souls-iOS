using UnityEngine;
using System.Collections;

public class CheckSoulCollection : MonoBehaviour {

	public bool[] soulcheck;
	public int[] soulcounts;
	public int x=40;

	void Start()
	{
		soulcounts = new int[x];
	}

}
