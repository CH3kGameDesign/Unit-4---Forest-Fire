﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject player;
	public GameObject mainMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	public void gameStart () {
		player.SetActive (true);
		mainMenu.SetActive (false);
	}

	public void gameCredits () {
        SceneManager.LoadScene(1);
	}

	public void gameQuit () {
		Application.Quit ();
	}
}
