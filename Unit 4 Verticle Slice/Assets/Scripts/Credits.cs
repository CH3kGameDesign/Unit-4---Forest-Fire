using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {
    	

	// Update is called once per frame
	void Update () {
		if (Input.anyKey)
        {
            Cursor.visible = false;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            SceneManager.LoadScene(0);
        }
	}
}
