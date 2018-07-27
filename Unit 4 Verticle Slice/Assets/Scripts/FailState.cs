using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailState : MonoBehaviour {

	public GameObject human;
    public GameObject player;

    public AudioSource boom;

	// Use this for initialization
	void Start () {
		
	}
	

	void OnTriggerStay (Collider player) {
		if (player.tag == "Player") {
			human.GetComponent<Animator> ().Play ("HumanFall");
			player.GetComponent<Animator> ().Play ("Slide");
            player.GetComponent<Movement>().canMove = false;
			Invoke ("startCredits", 0.668f);
		}
	}

	public void startCredits() {
		Debug.Log ("DOOOOONE");
        boom.Play();
        player.GetComponent<Movement>().slideAudio.Pause();
        player.GetComponent<Movement>().enabled = false;
        SceneManager.LoadScene(1);
	}
}
