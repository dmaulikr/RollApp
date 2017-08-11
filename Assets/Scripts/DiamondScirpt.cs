using UnityEngine;
using System.Collections;

public class DiamondScirpt : MonoBehaviour {

	float rotSpeed = 60; // degrees per second
	void Update(){
		transform.Rotate(0, rotSpeed * Time.deltaTime, 0, Space.World);
	}
}