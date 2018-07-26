using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject cameraHook;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (GetComponentInChildren<CameraController>().mainMenu == false)
        {
            transform.position = Vector3.Lerp(transform.position, cameraHook.transform.position, 0.075f);
        }
	}
}
