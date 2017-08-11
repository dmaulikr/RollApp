using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.EventSystems;

public class GameControl : MonoBehaviour {

	public static GameControl Instance{ set; get; }

	public int life;
	public int gem;

	void Awake (){
		Instance = this;
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream stream = new FileStream (Application.persistentDataPath + "/playerInfo.sa", FileMode.Create);

		PlayerData data = new PlayerData ();
		data.life = GameManager.Instance.life;
		data.gem = GameManager.Instance.currency;

		bf.Serialize (stream, data);
		stream.Close ();
	}

	public void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.sa")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/playerInfo.sa", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (stream);

			GameManager.Instance.life = data.life;
			GameManager.Instance.currency = data.gem;

			stream.Close ();
		} else {
			Debug.Log ("File does not exist.");
		}
	}
}

[Serializable]
class PlayerData
{
	public int life;
	public int gem;
}