/// <summary>
/// Drop base.第一個類，用來描述掉落物品的信息（id編號->可用做數據庫id索引，掉落物品名，圖標名稱->後面要從圖集裡面選取圖標，
/// Drop base.物品的描述->寫個小故事，物品的值比如對自身屬性的加成和紅藥藍藥的效果）
/// </summary>
public class DropBase {
	public int id ;                         
	public string name ;                    
	public string iconname ;                
	public string describe ;                                
	public float[] valuses ;                                
	public int amount ;                                                
	/// <summary>
	/// Initializes a new instance of the <see cref="DropBase"/> class.構造函數
	/// </summary>
	/// <param name="_id">_id.</param>
	/// <param name="_name">_name.</param>
	/// <param name="_describe">_describe.</param>
	/// <param name="_val">_val.</param>
	public DropBase(int _id , string _name , string _describe , float[] _val){
		valuses = new float[5] ;
		id = _id ;
		name = _name ;
		iconname = _name ;
		describe = _describe ;
		valuses = _val ;
		amount = 1 ;
	}
}
