using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject player;
	public GameObject mainMenu;
    public Image start;

    private bool fade = false;

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        if (fade == true)
        start.GetComponentInParent<CanvasGroup>().alpha = Mathf.Lerp(start.GetComponentInParent<CanvasGroup>().alpha, 0f, 0.1f);
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Music"));
    }

    public void gameStart () {

		player.SetActive (true);
        fade = true;
	}

	public void gameCredits () {
        SceneManager.LoadScene(1);
	}

	public void gameQuit () {
		Application.Quit ();
	}
}
