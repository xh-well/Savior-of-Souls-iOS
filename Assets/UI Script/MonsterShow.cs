using UnityEngine;
using System.Collections;

public class MonsterShow : MonoBehaviour {

	public UITexture[] MonsterShow1;
	public Texture[] Monsters;
	public Texture[] Elements;
	public int Set;
	public string Colors;

	public GameObject ShowEffect;
	public GameObject MagicShow;

	void Start()
	{
		ShowEffect = GameObject.Find ("MonsterShow");
		MagicShow = GameObject.Find ("MagicCircle");
		if (Set == 0) 
		{
			OnClick();
		}
	}

	void Update()
	{



	}

	void OnClick()
	{
		StartCoroutine (Alphashow ());

	}

	IEnumerator Alphashow()
	{
		if (Set == 0) {
			TweenColor.Begin (MagicShow, 0.3f, Color.red);
		} else if (Set == 1) {
			TweenColor.Begin (MagicShow, 0.3f, Color.blue);	
		} else if (Set == 2) {
			TweenColor.Begin (MagicShow, 0.3f, Color.green);
		} else if (Set == 3) {
			TweenColor.Begin (MagicShow, 0.3f, Color.cyan);
		} else if (Set == 4) {
			TweenColor.Begin (MagicShow, 0.3f, Color.yellow);
		}
		TweenScale.Begin (ShowEffect, 0.1f, new Vector3(0.3f,0.3f,0.3f));
		TweenAlpha.Begin (ShowEffect, 0.1f, 0);
		yield return new WaitForSeconds(0.1f);
		MonsterShow1 [0].mainTexture = Monsters [Set];
		MonsterShow1 [1].mainTexture = Elements [Set];
		TweenAlpha.Begin (ShowEffect, 0.3f, 1);
		TweenScale.Begin (ShowEffect, 0.3f, new Vector3(1,1,1));
		yield break;
	}
	

}
