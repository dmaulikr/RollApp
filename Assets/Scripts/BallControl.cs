using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BallControl : MonoBehaviour {

	public static BallControl control { set; get;}

	Rigidbody rigidBody;
	bool StartedShot;
	Vector3 shotStart;
	Vector3 shotEnd;
	Vector3 direction;
	float distance;
	public float forceAdjust = 0.02f;

	void Start () 
	{
		control = this;
		rigidBody = this.GetComponent<Rigidbody> ();
		StartedShot = false;
	}

	void Update () 
	{
		if (Input.GetMouseButtonUp(1))
		{
			rigidBody.velocity = Vector3.zero;
			this.transform.position = Vector3.zero;
			StartedShot = false;
		}

		// Starting shot
		if (!StartedShot && Input.GetMouseButtonDown (0)) 
		{
			StartedShot = true;
			shotStart = Input.mousePosition;
		}

		// Ending shot
		if (StartedShot && Input.GetMouseButtonUp (0)) 
		{
			shotEnd = Input.mousePosition;
			direction = shotEnd - shotStart;
			StartedShot = false;

			Vector3 shootDirection = new Vector3(direction.x, 0.0f, direction.y);

			rigidBody.AddForce(shootDirection * rigidBody.mass * forceAdjust, ForceMode.Impulse);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Goal1")) {
			GameManager.Instance.Level_1 ();
			LevelManager.instance.Win ();
		} else if (other.CompareTag ("Goal2")) {
			GameManager.Instance.Level_2 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal3")) {
			GameManager.Instance.Level_3 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal4")) {
			GameManager.Instance.Level_4 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal5")) {
			GameManager.Instance.Level_5 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal6")) {
			GameManager.Instance.Level_6 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal7")) {
			GameManager.Instance.Level_7 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal8")) {
			GameManager.Instance.Level_8 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal9")) {
			GameManager.Instance.Level_9 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal10")) {
			GameManager.Instance.Level_10 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal11")) {
			GameManager.Instance.Level_11 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal12")) {
			GameManager.Instance.Level_12 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal13")) {
			GameManager.Instance.Level_13 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal14")) {
			GameManager.Instance.Level_14 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal15")) {
			GameManager.Instance.Level_15 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal16")) {
			GameManager.Instance.Level_16 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal17")) {
			GameManager.Instance.Level_17 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal18")) {
			GameManager.Instance.Level_18 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal19")) {
			GameManager.Instance.Level_19 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal20")) {
			GameManager.Instance.Level_20 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal21")) {
			GameManager.Instance.Level_21 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal22")) {
			GameManager.Instance.Level_22 ();
			LevelManager.instance.Win ();
		}else if (other.CompareTag ("Goal23")) {
			GameManager.Instance.Level_23 ();
			LevelManager.instance.Win ();
		}

	}
}