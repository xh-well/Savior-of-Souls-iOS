
/// <summary>
/// Drop object data base.這個用來設計掉落物品的數據庫，有個構造函數通過設置它的種類，來構造一個掉落物品
/// Drop object data base.大家可以在這裡面修改屬性（名稱，值。etc）
/// </summary>
using UnityEngine;
using System.Collections;
using System ;  

public class DropObjectDataBase : MonoBehaviour {
	/// <summary>
	/// DBSPCIES.這個用來設定掉落物品的大種類
	/// </summary>
	public enum DBSPCIES{RedBottles , BlueBottles , Equipments , Others} ; 
	/// <summary>
	/// DBLISTS.這個用來設定掉落物品到底是什麼
	/// </summary>
	public enum DBLISTS{
		redPotion01 , 
		redPotion02 , 
		bluePotion01 , 
		bluePotion02 , 
		hat01 , 
		hat02 , 
		cloth01 , 
		cloth02 , 
		boot01 , 
		boot02 , 
		weapon01 , 
		weapon02 , 
		trousers01 , 
		trousers02  
	} ;
	public DBSPCIES dbspcies ;
	public DBLISTS dblist ;
	public DropBase dropBase ;
	/// <summary>
	/// index arr[].索引和值數組
	/// </summary>
	private int index ; 
	private float[] arr ;
	
	// Use this for initialization
	void Start () {
		/// <summary>
		/// switch.通過一個條件選擇語句初始化DropBase，並通過名稱設置它的大種類
		/// </summary>
		switch(dblist){
		case DBLISTS.redPotion01:
			index = (int)DBLISTS.redPotion01 ;
			arr = new float[5]{ 100 , 0 , 0 , 0 , 0 } ;
			break ;
		case DBLISTS.redPotion02:
			index = (int)DBLISTS.redPotion02 ;
			arr = new float[5]{ 200 , 0 , 0 , 0 , 0 } ;
			break ;
		case DBLISTS.bluePotion01:
			index = (int)DBLISTS.bluePotion01 ;
			arr = new float[5]{ 70 , 0 , 0 , 0 , 0 } ;
			break ;
		case DBLISTS.bluePotion02:
			index = (int)DBLISTS.bluePotion02 ;
			arr = new float[5]{ 140 , 0 , 0 , 0 , 0 } ;
			break ;
		case DBLISTS.hat01:
			index = (int)DBLISTS.hat01 ;
			arr = new float[5]{ 6 , 5 , 3 , 8 , 4 } ;
			break ;
		case DBLISTS.hat02:
			index = (int)DBLISTS.hat02 ;
			arr = new float[5]{ 22 , 14 , 44 , 23 , 32 } ;
			break ;
		case DBLISTS.cloth01:
			index = (int)DBLISTS.cloth01 ;
			arr = new float[5]{ 6 , 5 , 3 , 8 , 4 } ;
			break ;
		case DBLISTS.cloth02:
			index = (int)DBLISTS.cloth02 ;
			arr = new float[5]{ 32 , 24 , 33 , 55 , 22 } ;
			break ;
		case DBLISTS.trousers01:
			index = (int)DBLISTS.trousers01 ;
			arr = new float[5]{ 6 , 5 , 3 , 8 , 4 } ;
			break ;
		case DBLISTS.trousers02:
			index = (int)DBLISTS.trousers02 ;
			arr = new float[5]{ 55 , 33 , 44 , 22 , 11 } ;
			break ;
		case DBLISTS.boot01:
			index = (int)DBLISTS.boot01 ;
			arr = new float[5]{ 6 , 5 , 3 , 8 , 4 } ;
			break ;
		case DBLISTS.boot02:
			index = (int)DBLISTS.boot02 ;
			arr = new float[5]{ 31 , 22 , 41 , 31 , 27 } ;
			break ;
		case DBLISTS.weapon01:
			index = (int)DBLISTS.weapon01 ;
			arr = new float[5]{ 65 , 12 , 33 , 65 , 12 } ;
			break ;
		case DBLISTS.weapon02:
			index = (int)DBLISTS.weapon02 ;
			arr = new float[5]{ 223 , 112 , 445 , 263 , 112 } ;
			break ;
		}
		/// <summary>
		/// new DropBase.構造一個物品
		/// </summary>
		dropBase = new DropBase( index , ((DBLISTS)Enum.ToObject(typeof(DBLISTS),index )).ToString() , "" , arr);
		/// <summary>
		/// if-else.設定它的大種類
		/// </summary>
		if(dblist <= DBLISTS.redPotion02 && dblist >= DBLISTS.redPotion01){
			dbspcies = DBSPCIES.RedBottles ;
		}else if(dblist <= DBLISTS.bluePotion02 && dblist >= DBLISTS.bluePotion01){
			dbspcies = DBSPCIES.BlueBottles ;
		}else if(dblist <= DBLISTS.weapon02 && dblist >= DBLISTS.hat01){
			dbspcies = DBSPCIES.Equipments ;
		}
		//print(dblist +""+ dbspcies);
	}
}