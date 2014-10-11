
/// <summary>
/// Inventory.背包的核心類，背包操作
/// </summary>
using UnityEngine;
using System.Collections;
/// <summary>
/// Inventory.要使用List線性表，需要引入這個Generic
/// </summary>
using System.Collections.Generic ;  

public class Inventory : MonoBehaviour {
	/// <summary>
	/// The inventory list.定義一個存放gameobject的線性表
	/// </summary>
	private List<GameObject> inventoryList ; 
	// Use this for initialization
	void Start () {
		inventoryList = new List<GameObject>() ;   
	}
	
	/// <summary>
	/// Adds the item.物品進入背包函數，接受一個gameobject參數
	/// </summary>
	/// <param name="_goadd">_goadd.</param>
	public void AddItem(GameObject _goadd){ 
		/// <summary>
		/// if-else.先通過CheckExisted函數判斷背包裡面是否存在這個物品如果有就把傳過來的gameobject銷毀在CheckExisted函數里面將數量加1
		/// </summary>
		if(CheckExisted(_goadd)){
			Destroy(_goadd) ;
		}else{
			/// <summary>
			/// if-else.背包裡面如果存在這個物品，就把傳過來的gameobject添加到線性表裡去，並且把傳過來的gameobject設定為背包的子物體
			/// </summary>
			inventoryList.Add(_goadd);
			_goadd.transform.parent = gameObject.transform ;
			/// <summary>
			/// localScale.設定它的縮放，不然它會很巨大
			/// </summary>
			_goadd.transform.localScale = new Vector3(1,1,1);
		}
		
		ReFreshInventory();
	}
	/// <summary>
	/// Removes the item.將物品從背包刪除，先從線性表裡刪除，然後再更新背包界面，最後銷毀物體
	/// </summary>
	/// <param name="_goremove">_goremove.</param>
	public void RemoveItem(GameObject _goremove){ 
		inventoryList.Remove(_goremove);
		ReFreshInventory();
		Destroy(_goremove);
	}
	/// <summary>
	/// Res the fresh inventory.更新背包界面，從線性表讀取物品信息並刷新界面
	/// </summary>
	public void ReFreshInventory(){ 
		foreach(GameObject g in inventoryList){
			g.GetComponentInChildren<UILabel>().text = g.GetComponent<DropObjectDataBase>().dropBase.amount + "" ;
		}
		/// <summary>
		/// Reposition.重新調整背包物品排列，UIGird的函數
		/// </summary>
		gameObject.GetComponent<UIGrid>().Reposition() ;
	}
	/// <summary>
	/// Checks the existed.檢測背包物品list裡面的物體是否存在，通過比較物品名稱種類實現判斷，如果有就將數量加1，函數返回一個bool值
	/// </summary>
	/// <returns><c>true</c>, if existed was checked, <c>false</c> otherwise.</returns>
	/// <param name="_go">_go.</param>
	bool CheckExisted(GameObject _go){ 
		bool flag = false ;
		foreach(GameObject _obje in inventoryList){
			if(_go.GetComponent<DropObjectDataBase>().dblist == _obje.GetComponent<DropObjectDataBase>().dblist){
				_obje.GetComponent<DropObjectDataBase>().dropBase.amount ++ ;
				flag = true ;
				break ;
			}else{
				flag = false ;
			}
		}
		return flag ;
	}
}
