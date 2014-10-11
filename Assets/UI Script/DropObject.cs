
/// <summary>
/// Drop object.怪物死亡後會掉落物品
/// </summary>
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DropObjectDataBase))]
public class DropObject : MonoBehaviour {  
	/// <summary>
	/// Prefab.通過預設生成一個背包裡面的格子
	/// </summary>
	public GameObject itemCellPrefab ;  
	/// <summary>
	/// Cellcontainer.背包格子父容器
	/// </summary>
	private GameObject Cellcontainer ;                
	// Use this for initialization
	void Start () {
		Cellcontainer = GameObject.Find("CellContainer");        
	}
	/// <summary>
	/// Raises the mouse down event.這裡設定的是鼠標點選，大家可以設置trigger觸發器觸發揀選
	/// </summary>
	void OnMouseDown(){
		CellCreation();
	}
	/// <summary>
	/// Cells the creation.通過Instantiate克隆出一個格子預設，調用背包腳本的AddItem函數將這個clone出來的物體加到背包裡面去
	/// Cells the creation.把掉落的物品的三個屬性傳給clone出來的物品，並設定它的圖集圖標
	/// </summary>
	void CellCreation(){
		GameObject cellClone = (GameObject)Instantiate(itemCellPrefab);
		cellClone.GetComponent<DropObjectDataBase>().dblist = gameObject.GetComponent<DropObjectDataBase>().dblist ;
		cellClone.GetComponent<DropObjectDataBase>().dropBase = gameObject.GetComponent<DropObjectDataBase>().dropBase ;
		cellClone.GetComponent<DropObjectDataBase>().dbspcies = gameObject.GetComponent<DropObjectDataBase>().dbspcies ;
		cellClone.GetComponentInChildren<UISprite>().spriteName = cellClone.GetComponent<DropObjectDataBase>().dropBase.iconname ;
		if(Cellcontainer){
			Cellcontainer.GetComponent<Inventory>().AddItem(cellClone);
		}else{
			print ("Failed to Instantiate.......");
		}
	}
}

