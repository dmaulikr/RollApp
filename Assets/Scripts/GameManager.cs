using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private static GameManager instance;
	public static GameManager Instance{get { return instance; } }

	public int currentSkinIndex = 0;
	public int currency = 0;
	public int skinAvailability =1;

	public int life = 5;

	private int Lvl1, Lvl2, Lvl3, Lvl4, Lvl5, Lvl6, Lvl7, Lvl8, 
				Lvl9, Lvl10, Lvl11, Lvl12, Lvl13, Lvl14, Lvl15, 
				Lvl16, Lvl17, Lvl18, Lvl19, Lvl20, Lvl21, Lvl22, 
				Lvl23;

	private void Awake(){
//		PlayerPrefs.DeleteAll ();
		if (instance == null) 
		{
			DontDestroyOnLoad (gameObject);
			instance = this;
		} 
		else if (instance != this) 
		{
			Destroy (gameObject);
		}

		if(PlayerPrefs.HasKey("CurrentSkin"))
		{
			currentSkinIndex = PlayerPrefs.GetInt ("CurrentSkin");
			currency = PlayerPrefs.GetInt ("Currency");
			skinAvailability = PlayerPrefs.GetInt ("SkinAvailability");
		}
		else
		{
			Save ();
		}
		Lvl1 = PlayerPrefs.GetInt ("Lvl1Gems");
		Lvl2 = PlayerPrefs.GetInt ("Lvl2Gems");
		Lvl3 = PlayerPrefs.GetInt ("Lvl3Gems");
		Lvl4 = PlayerPrefs.GetInt ("Lvl4Gems");
		Lvl5 = PlayerPrefs.GetInt ("Lvl5Gems");
		Lvl6 = PlayerPrefs.GetInt ("Lvl6Gems");
		Lvl7 = PlayerPrefs.GetInt ("Lvl7Gems");
		Lvl8 = PlayerPrefs.GetInt ("Lvl8Gems");
		Lvl9 = PlayerPrefs.GetInt ("Lvl9Gems");
		Lvl10 = PlayerPrefs.GetInt ("Lvl10Gems");
		Lvl11 = PlayerPrefs.GetInt ("Lvl11Gems");
		Lvl12 = PlayerPrefs.GetInt ("Lvl12Gems");
		Lvl13 = PlayerPrefs.GetInt ("Lvl13Gems");
		Lvl14 = PlayerPrefs.GetInt ("Lvl14Gems");
		Lvl15 = PlayerPrefs.GetInt ("Lvl15Gems");
		Lvl16 = PlayerPrefs.GetInt ("Lvl16Gems");
		Lvl17 = PlayerPrefs.GetInt ("Lvl17Gems");
		Lvl18 = PlayerPrefs.GetInt ("Lvl18Gems");
		Lvl19 = PlayerPrefs.GetInt ("Lvl19Gems");
		Lvl20 = PlayerPrefs.GetInt ("Lvl20Gems");
		Lvl21 = PlayerPrefs.GetInt ("Lvl21Gems");
		Lvl22 = PlayerPrefs.GetInt ("Lvl22Gems");
		Lvl23 = PlayerPrefs.GetInt ("Lvl23Gems");
	}
		
	public void TakeLife ()
	{
		life -= 1;
		GameControl.Instance.Save ();
		Debug.Log ("Take 1 Life");
	}

	public void Save (){
		PlayerPrefs.SetInt ("CurrentSkin", currentSkinIndex);
		PlayerPrefs.SetInt ("Currency", currency);
		PlayerPrefs.SetInt ("SkinAvailability", skinAvailability);
		GameControl.Instance.Save ();
	}

// ############################# LEVELS ############################## //
	public void Level_1(){
		Lvl1++;
		if(Lvl1 == 1)
		{
			currency += 10;
			life += 2;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl1Gems", Lvl1);
		}
	}
	public void Level_2(){
		Lvl2++;
		if(Lvl2 == 1)
		{
			currency += 10;
			life += 2;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl2Gems", Lvl2);
		}
	}	
	public void Level_3(){
		Lvl3++;
		if(Lvl3 == 1)
		{
			currency += 10;
			life += 2;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl3Gems", Lvl3);
		}
	}
	public void Level_4(){
		Lvl4++;
		if(Lvl4 == 1)
		{
			currency += 10;
			life += 3;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl4Gems", Lvl4);
		}
	}	
	public void Level_5(){
		Lvl5++;
		if(Lvl5 == 1)
		{
			currency += 10;
			life += 3;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl5Gems", Lvl5);
		}
	}
	public void Level_6(){
		Lvl6++;
		if(Lvl6 == 1)
		{
			currency += 15;
			life += 3;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl6Gems", Lvl6);
		}
	}	
	public void Level_7(){
		Lvl7++;
		if(Lvl7 == 1)
		{
			currency += 15;
			life += 5;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl7Gems", Lvl7);
		}
	}
	public void Level_8(){
		Lvl8++;
		if(Lvl8 == 1)
		{
			currency += 15;
			life += 5;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl8Gems", Lvl8);
		}
	}	
	public void Level_9(){
		Lvl9++;
		if(Lvl9 == 1)
		{
			currency += 15;
			life += 5;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl9Gems", Lvl9);
		}
	}
	public void Level_10(){
		Lvl10++;
		if(Lvl10 == 1)
		{
			currency += 15;
			life += 5;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl10Gems", Lvl10);
		}
	}	
	public void Level_11(){
		Lvl11++;
		if(Lvl11 == 1)
		{
			currency += 20;
			life += 5;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl11Gems", Lvl11);
		}
	}
	public void Level_12(){
		Lvl12++;
		if(Lvl12 == 1)
		{
			currency += 20;
			life += 5;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl12Gems", Lvl12);
		}
	}	
	public void Level_13(){
		Lvl13++;
		if(Lvl13 == 1)
		{
			currency += 20;
			life += 5;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl13Gems", Lvl13);
		}
	}
	public void Level_14(){
		Lvl14++;
		if(Lvl14 == 1)
		{
			currency += 20;
			life += 5;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl14Gems", Lvl14);
		}
	}	
	public void Level_15(){
		Lvl15++;
		if(Lvl15 == 1)
		{
			currency += 20;
			life += 10;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl15Gems", Lvl15);
		}
	}
	public void Level_16(){
		Lvl16++;
		if(Lvl16 == 1)
		{
			currency += 20;
			life += 10;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl16Gems", Lvl16);
		}
	}	
	public void Level_17(){
		Lvl17++;
		if(Lvl17 == 1)
		{
			currency += 50;
			life += 10;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl17Gems", Lvl17);
		}
	}
	public void Level_18(){
		Lvl18++;
		if(Lvl18 == 1)
		{
			currency += 50;
			life += 10;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl18Gems", Lvl18);
		}
	}	
	public void Level_19(){
		Lvl19++;
		if(Lvl19 == 1)
		{
			currency += 50;
			life += 10;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl19Gems", Lvl19);
		}
	}
	public void Level_20(){
		Lvl20++;
		if(Lvl20 == 1)
		{
			currency += 50;
			life += 10;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl20Gems", Lvl20);
		}
	}
	public void Level_21(){
		Lvl21++;
		if(Lvl21 == 1)
		{
			currency += 50;
			life += 10;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl21Gems", Lvl21);
		}
	}
	public void Level_22(){
		Lvl22++;
		if(Lvl22 == 1)
		{
			currency += 50;
			life += 10;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl22Gems", Lvl22);
		}
	}
	public void Level_23(){
		Lvl23++;
		if(Lvl23 == 1)
		{
			currency += 50;
			life += 10;
			GameControl.Instance.Save ();
			PlayerPrefs.SetInt ("Lvl23Gems", Lvl23);
		}
	}
}