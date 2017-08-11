using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelData{
	public LevelData(string levelName)
	{
		string data = PlayerPrefs.GetString (levelName);
		if (data == "")
			return;

		string[] allData = data.Split ('&');
		BestTime = float.Parse (allData [0]);
	}
	public float BestTime{ set; get; }
}
public class MenuManager : MonoBehaviour {
	public static MenuManager Instance { set; get;}
	
	public Text currencyText;
	public Text lifeText;

	public Sprite[] borders;

	public GameObject levelButtonPrefab;
	public GameObject levelButtonContainer;
	public GameObject shopButtonPrefab;
	public GameObject shopButtonContainer;

	public GameObject levelUI;
	public GameObject shopUI;
	public GameObject toShopBtn;
	public GameObject toExtraLivesBtn;
	public GameObject adLifeUI;
	public GameObject exitUI;

	public Material playerMat;

	private bool nextLevelLocked = false;

	//COSTS
	private int[] costs = {	
		0, 30, 60, 80,
		200, 200, 200, 200,
		200, 200, 200, 200,
		200, 200, 200, 500
	};

	void Start () 
	{
		Instance = this;
		GameControl.Instance.Load ();
		ChangePlayerSkin (GameManager.Instance.currentSkinIndex);
		lifeText.text = GameManager.Instance.life.ToString ();
		currencyText.text = GameManager.Instance.currency.ToString ();
		
		levelUI.SetActive (true);
		shopUI.SetActive (false);
		adLifeUI.SetActive (false);
		exitUI.SetActive (false);
		AdManager.Instance.ShowBanner ();
//LEVEL_SELECT 
		Sprite[] thumbnails = Resources.LoadAll<Sprite> ("Levels");
		foreach (Sprite thumbnail in thumbnails) 
		{
			GameObject container = Instantiate (levelButtonPrefab) as GameObject;
			container.GetComponent<Image> ().sprite = thumbnail;
			container.transform.SetParent (levelButtonContainer.transform, false);
			LevelData level = new LevelData (thumbnail.name);

			string minutes = ((int) level.BestTime / 60).ToString("00");
			string seconds = (level.BestTime % 60).ToString("00.00");

			GameObject bottomPanel = container.transform.GetChild (0).GetChild (0).gameObject;

			bottomPanel.GetComponent<Text>().text = (level.BestTime != 0.0f) 
				? minutes + ":" + seconds 
				: "empty";

			container.transform.GetChild (1).GetComponent<Image> ().enabled = nextLevelLocked;
			container.GetComponent<Button> ().interactable = !nextLevelLocked;

			if (level.BestTime == 0.0f) 
				nextLevelLocked = true;
			
			string sceneName = thumbnail.name;
			container.GetComponent<Button>().onClick.AddListener(() => LoadLevel(sceneName));
		}
//SHOP_SELECT
		int textureIndex = 0;
		Sprite[] textures = Resources.LoadAll<Sprite> ("Player");
		foreach (Sprite texture in textures) 
		{
			GameObject container = Instantiate (shopButtonPrefab) as GameObject;
			container.GetComponent<Image> ().sprite = texture;
			container.transform.SetParent (shopButtonContainer.transform, false);

			int index = textureIndex;
			container.GetComponent<Button>().onClick.AddListener(() => ChangePlayerSkin(index));
			container.transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = costs [index].ToString ();
			if((GameManager.Instance.skinAvailability & 1 << index) == 1 << index)
			{
			container.transform.GetChild (0).gameObject.SetActive(false);
			}
			textureIndex++;
		}
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape))
			exitUI.SetActive (true);
	}

	public void YesBtnExit(){
		Application.Quit();
	}
	public void NoBtnExit(){
		exitUI.SetActive (false);
	}

//LOAD_LEVEL
	private void LoadLevel(string sceneName)
	{
		if (GameManager.Instance.life >= 1)
		{
			SceneManager.LoadScene (sceneName);
			AdManager.Instance.ShowBanner ();
		}
		else
			adLifeUI.SetActive (true);
	}
//BACK_BUTTON
	public void BackToMenu()
	{
		shopUI.SetActive (false);
		adLifeUI.SetActive (false);
		levelUI.SetActive (true);
		toShopBtn.SetActive (true);
		toExtraLivesBtn.SetActive (true);
	}
//SHOP_BUTTON
	public void ShopMenu()
	{
		shopUI.SetActive (true);
		levelUI.SetActive (false);
		toShopBtn.SetActive (false);
		toExtraLivesBtn.SetActive (false);
	}
// ####### REWARD ####### //
	public void GiveThreeLives()
	{
		AdManager.Instance.ShowAd ();
	}
	public void RewardLives()
	{
		GameManager.Instance.life += 5;
		GameManager.Instance.currency += 5;
		GameControl.Instance.Save ();
		Debug.Log ("Give Lives + Gems");
		SceneManager.LoadScene ("MAINMENU");
	}

	public void GiveGemsLives()
	{
		PurchaseScript.Instance.BuyLivesGems ();
	}

//CHANGE_PLAYER_SKIN
	private void ChangePlayerSkin (int index)
	{
		if ((GameManager.Instance.skinAvailability & 1 << index) == 1 << index) 
		{
			float x = (index % 4) * 0.25f;
			float y = ((int)index / 4) * 0.25f;

			if (y == 0.0f)
				y = 0.75f;
			else if (y == 0.25f)
				y = 0.5f;
			else if (y == 0.50f)
				y = 0.25f;
			else if (y == 0.75f)
				y = 0f;
				
			playerMat.SetTextureOffset ("_MainTex", new Vector2 (x, y));
			GameManager.Instance.currentSkinIndex = index;
			GameManager.Instance.Save ();
		} 
		else 
		{
			int cost = costs [index];
			if (GameManager.Instance.currency >= cost) 
			{
				GameManager.Instance.currency -= cost;
				GameManager.Instance.skinAvailability += 1 << index;
				GameManager.Instance.Save ();
				currencyText.text = GameManager.Instance.currency.ToString();
				shopButtonContainer.transform.GetChild (index).GetChild (0).gameObject.SetActive (false);
				ChangePlayerSkin (index);
			}
		}
	}
}