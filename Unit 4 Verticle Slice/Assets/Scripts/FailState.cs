using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailState : MonoBehaviour {

	public GameObject human;

	// Use this for initialization
	void Start () {
		
	}
	

	void OnTriggerEnter (Collider player) {
		if (player.tag == "Player") {
			human.GetComponent<Animator> ().Play ("HumanFall");
			player.GetComponent<Animator> ().Play ("Slide");
			player.GetComponent<Movement> ().canMove = false;
			Invoke ("startCredits", 0.334f);
		}
	}

	public void startCredits() {
		Debug.Log ("DOOOOONE");
	}
}
