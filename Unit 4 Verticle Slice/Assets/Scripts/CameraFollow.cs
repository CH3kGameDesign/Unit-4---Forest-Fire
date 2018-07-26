using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject cameraHook;

	
	
	// Update is called once per frame
	void Update () {
        if (GetComponentInChildren<CameraController>().mainMenu == false)
        {
            transform.position = Vector3.Lerp(transform.position, cameraHook.transform.position, 0.075f);
        }
	}
}
