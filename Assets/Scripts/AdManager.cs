using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using admob;

public class AdManager : MonoBehaviour {
	public static AdManager Instance{ set; get; }

	[SerializeField] string gameID = "1134078";
	[SerializeField] string bannerId = "ca-app-pub-5370294750089958/3173763425";
	[SerializeField] string videoId = "ca-app-pub-5370294750089958/6127229829";

	void Awake ()
	{
		Instance = this;
		Advertisement.Initialize (gameID, true);
		DontDestroyOnLoad (gameObject);

		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		Admob.Instance ().initAdmob (bannerId, videoId);
		Admob.Instance ().loadInterstitial ();
		#endif
	}

	public void ShowBanner(){
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		Admob.Instance().showBannerRelative (AdSize.Banner, AdPosition.BOTTOM_CENTER, 1);
		#endif
	}

	public void ShowVideo(){
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		if (Admob.Instance ().isInterstitialReady ()) {
			Admob.Instance ().showInterstitial ();		
		}
		#endif
	}

	public void ShowAd(string zone = "")
	{
		#if UNITY_EDITOR || UNITY_ANDROID
		StartCoroutine(WaitForAd ());
		#endif

		if (string.Equals (zone, ""))
			zone = null;

		ShowOptions options = new ShowOptions ();
		options.resultCallback = AdCallbackhandler;

		if (Advertisement.IsReady (zone))
			Advertisement.Show (zone, options);
	}

	void AdCallbackhandler (ShowResult result)
	{
		switch(result)
		{
		case ShowResult.Finished:
			MenuManager.Instance.RewardLives ();
			break;
		case ShowResult.Skipped:
			Debug.Log ("Ad skipped");
			break;
		case ShowResult.Failed:
			Debug.Log("Ad Failed");
			break;
		}
	}

	IEnumerator WaitForAd()
	{
		float currentTimeScale = Time.timeScale;
		Time.timeScale = 0f;
		yield return null;

		while (Advertisement.isShowing)
			yield return null;

		Time.timeScale = currentTimeScale;
	}
}