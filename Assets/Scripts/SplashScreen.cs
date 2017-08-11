using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

	public float delayTime = 3;

	IEnumerator Start () 
	{
		yield return new WaitForSeconds (delayTime);

		SceneManager.LoadScene ("MAINMENU");
	}
}
