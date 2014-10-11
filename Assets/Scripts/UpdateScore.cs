using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UpdateScore : MonoBehaviour {

	public string path = "http://fgamer.net/PlayerData/PlayerDataCreate.php";
	public string downloadPath = "http://fgamer.net/PlayerData/PlayerDataUpdate.php";

	public string name;
	public string score; 

	void OnGUI()
	{

		name = GUILayout.TextField (name, 10);
		score = GUILayout.TextField (score, 10);

		if (GUILayout.Button ("Update")) 
		{
			StartCoroutine("ScoreUpdate");
		}

		if (GUILayout.Button ("Download")) 
		{
			StartCoroutine("ScoreDownload");	
		}
	}

	public IEnumerator ScoreUpdate()
	{
		WWWForm form = new WWWForm ();

		Dictionary<string,string> data = new Dictionary<string,string > ();
		data.Add ("name", name);
		data.Add ("score", score);

		foreach (KeyValuePair<string,string>post in data) 
		{
			form.AddField(post.Key,post.Value);

		}

		WWW www = new WWW (path, form);
		yield return www;
		Debug.Log (www.text);

	}

	public IEnumerator ScoreDownload()
	{
		WWWForm form = new WWWForm ();

		Dictionary<string,string> data = new Dictionary<string, string> ();

		data.Add ("download", "1");

		foreach (KeyValuePair<string,string> post in data) {
			form.AddField(post.Key,post.Value);		
		}

		WWW www = new WWW (downloadPath, form);
		yield return www;
		Debug.Log (www.text);

	}



}
