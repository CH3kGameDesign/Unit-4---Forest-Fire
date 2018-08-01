using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    /*
     Is responsible for:
     - Using Main Menu
     */

    public GameObject player;                       //Player Controlled Character
	public GameObject mainMenu;                     //All the Main Menu UI Elements
    public Image start;                             //Any UI Element

    private bool fade = false;                      //Whether to Fade

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    void Update()
    {
        if (fade == true)
        start.GetComponentInParent<CanvasGroup>().alpha = Mathf.Lerp(start.GetComponentInParent<CanvasGroup>().alpha, 0f, 0.1f);
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Music"));
    }

    public void gameStart () {

		player.SetActive (true);
        Cursor.visible = false;
        fade = true;
	}

	public void gameCredits () {
        SceneManager.LoadScene(1);
	}

	public void gameQuit () {
		Application.Quit ();
	}
}
