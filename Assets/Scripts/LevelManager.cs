using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour {
	public static LevelManager instance { set; get;}

	private float startTime;
	private float levelDuration;

	public Transform spawnPosition;
	public Transform playerTransform;

	public Text lifeText;
	public Text timerText;
	public Text endTimerText;

	public GameObject endMenu;
	private GameObject player;
	public GameObject pauseMenu;

	private void Awake(){
		instance = this;
		lifeText.text = GameManager.Instance.life.ToString ();

		startTime = Time.time;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Start()
	{
		endMenu.SetActive (false);
		pauseMenu.SetActive (false);
	}

	void Update () {
		if (playerTransform.position.y < -10)
			Death ();

		levelDuration = Time.time - startTime;
		string minutes = ((int) levelDuration  / 60).ToString("00");
		string seconds = (levelDuration % 60).ToString("00.00");

		timerText.text = minutes + ":" + seconds;
	}

	public void Win(){
		foreach (Transform t in endMenu.transform.parent)
			t.gameObject.SetActive (false);
		
		Rigidbody rigid = player.GetComponent<Rigidbody> ();
		rigid.constraints = RigidbodyConstraints.FreezeAll;


		levelDuration = Time.time - startTime;
		string minutes = ((int) levelDuration  / 60).ToString("00");
		string seconds = (levelDuration % 60).ToString("00.00");
		endTimerText.text = minutes + ":" + seconds;

		string saveString = "";
		LevelData level = new LevelData (SceneManager.GetActiveScene ().name);
 		saveString += (level.BestTime > levelDuration || level.BestTime == 0.0f) ? levelDuration.ToString () : level.BestTime.ToString();
		PlayerPrefs.SetString (SceneManager.GetActiveScene ().name, saveString);	

		AdManager.Instance.ShowVideo ();

		endMenu.SetActive (true);
	}

	public void Death()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

		GameManager.Instance.TakeLife ();
		lifeText.text = GameManager.Instance.life.ToString ();

		if (GameManager.Instance.life <= 0) 
		{
			SceneManager.LoadScene ("MAINMENU");
		}
	}

	public void TogglePauseMenu()
	{
		pauseMenu.SetActive (!pauseMenu.activeSelf);
		Time.timeScale = (pauseMenu.activeSelf) ? 0 : 1;
	}

	public void EndMainMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene ("MAINMENU");
	}

	public void ToMenu()
	{
		Time.timeScale = 1;
		GameManager.Instance.TakeLife();
		SceneManager.LoadScene ("MAINMENU");
	}
}