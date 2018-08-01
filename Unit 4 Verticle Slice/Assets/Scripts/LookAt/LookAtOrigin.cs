using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtOrigin : MonoBehaviour {

    /*
     Is responsible for:
     - Moving LookAtOrigin In accordance with mouse position
     */

    private Vector3 origPos;                //Original Location

    public Camera mainCamera;               //Camera Object

	void Start () {
        origPos = transform.localPosition;
	}

	// Update is called once per frame
	void Update () {
        float yaw = mainCamera.GetComponent<CameraController>().yaw;
        float yawOrig = mainCamera.GetComponent<CameraController>().yawOrig;

        float pitch = mainCamera.GetComponent<CameraController>().pitch;
        float pitchOrig = mainCamera.GetComponent<CameraController>().pitchOrig;

        if (yaw > yawOrig - 1 && yaw < yawOrig + 1)
        {
            yaw = 0;
        } else
        {
            yaw = yaw - yawOrig;
        }
        if (pitch > pitchOrig - 1 && pitch < pitchOrig + 1)
        {
            pitch = 0;
        } else
        {
            pitch = pitch - pitchOrig;
        }

        transform.localPosition = new Vector3(transform.localPosition.x, origPos.y - pitch, transform.localPosition.z);
    }
}
