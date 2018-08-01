using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

    /*
     Is responsible for:
     - Making The Player Start Playing When Player Model hits Trigger
     */

    public GameObject Camera;                   //Camera Controller Object
	public GameObject Ramp;                     //Ramp that the player slides down

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			Camera.GetComponent<CameraController> ().mainMenu = false;
			Ramp.SetActive (false);
		}
	}
}
