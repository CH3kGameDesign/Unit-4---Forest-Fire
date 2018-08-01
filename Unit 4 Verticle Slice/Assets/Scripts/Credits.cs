using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {
    	

	// Update is called once per frame
	void Update () {
        Cursor.visible = false;
        if (Input.anyKey)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            SceneManager.LoadScene(0);
        }
	}
}
