using UnityEngine;
using System.Collections;

public class ShowSouls : MonoBehaviour {

	public GameObject[,] souls;
	public SoulsController soulscontroller;
	public int boardSize;
	public int boardSizew;
	public GameObject soul;


	void BuildBoard(){
		for (int it1=0;it1<boardSize;it1+=1){
			for(int it2=0;it2<boardSizew;it2+=1){
				souls[it1,it2]=Instantiate (soul,new Vector3(-6f+it1,-10F+it2,0F),Quaternion.identity) as GameObject;

			}
		}
	}



}
