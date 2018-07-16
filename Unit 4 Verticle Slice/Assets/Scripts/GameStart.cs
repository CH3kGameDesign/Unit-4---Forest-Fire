using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

	public GameObject Camera;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			Camera.GetComponent<CameraController> ().mainMenu = false;
		}
	}
}
