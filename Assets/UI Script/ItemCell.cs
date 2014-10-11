
/// <summary>
/// Item cell.
/// </summary>
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DropObjectDataBase))]
public class ItemCell : MonoBehaviour {
	/// <summary>
	/// The cell DES.這個用來顯示背包格子裡面的信息，比如裝備的屬性之類的
	/// </summary>
	private GameObject cellDes ;
	/// <summary>
	/// The _cell D.這個用來獲取格子身上的數據庫腳本。因為需要用到裡面的數值
	/// </summary>
	private DropObjectDataBase _cellDB ;
	// Use this for initialization
	void Start () {
		_cellDB = gameObject.GetComponent<DropObjectDataBase>();
		cellDes = GameObject.Find("InventoryItemCellDescribe");
		/// <summary>
		/// cellDes.transform.position.這句話用來設置屬性描述框的初始位置，就是放到看不到的位置
		/// </summary>
		cellDes.transform.position = new Vector3(0,10000,0);
	}
	/// <summary>
	/// Raises the click event.當鼠標點擊物品的時候先判斷物品的數量是否大於1個，如果大於1個的話就數量上減去1，否則剛好有一個的話就把它從背包刪除
	/// </summary>
	void OnClick(){
		if(gameObject.GetComponent<DropObjectDataBase>().dropBase.amount > 1){
			gameObject.GetComponent<DropObjectDataBase>().dropBase.amount -- ;
		}else{
			this.transform.parent.GetComponent<Inventory>().RemoveItem(this.gameObject);
			/// <summary>
			/// DesHide.刪除物品的同時將物品介紹面板隱藏
			/// </summary>
			DesHide();
		}
		this.transform.parent.GetComponent<Inventory>().ReFreshInventory();
	}
	/// <summary>
	/// Raises the hover event.鼠標懸浮在物品上面的時候調用，接受一個參數，
	/// </summary>
	/// <param name="isOver">If set to <c>true</c> is over.</param>

	void OnHover(bool isOver){
		if(isOver){
			DesShow();
		}else{
			DesHide();
		}
	}

	/// <summary>
	/// DESs the show.將屬性顯示面板的位置設置到物品的位置，並設置屬性面板內容，從數據庫腳本中讀取
	/// </summary>
	void DesShow(){
		cellDes.transform.position = gameObject.transform.position ;
		cellDes.GetComponentInChildren<UILabel>().text = _cellDB.dropBase.name + "\n" +
			_cellDB.dropBase.describe + "\n" +
				_cellDB.dropBase.valuses[0] ;
	}
	/// <summary>
	/// DESs the hide.將面板的y值設置到一個看不到的敵方，來實現面板隱藏
	/// </summary>
	void DesHide(){
		cellDes.transform.position = new Vector3(0,10000,0);
	}
	
	void OnPress(){
		
	}
}