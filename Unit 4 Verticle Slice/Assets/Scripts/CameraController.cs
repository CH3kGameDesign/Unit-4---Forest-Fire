using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    /*
    WHAT SCRIPT DOES:
    -   Move Camera
    -   Hide Cursor
    */

    public float hcamspeed = 2;         //Speed Rotating Horizontally
	public float vcamspeed = 2;         //Speed Rotating Vertically

	//public so you can rotate player start rotation
	public float yaw = 0;
	public float pitch = 0;
	public float yawOrig;
	public float pitchOrig;

	//Maximum yaw Rotations
	public float yawMax = 60;
	public float yawMin = -120;

    public float yawZoom = 2;

    //Maximum pitch Rotations
	public float pitchMax = 60;
	public float pitchMin = -120;

    public float pitchZoom = 2;

	public GameObject cameraHook;
	public bool mainMenu = true;

	void Start () {
		//Set Cursor to be locked to window
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
		yawOrig = yaw;
        pitchOrig = pitch;
	}


	void Update () {
		if (mainMenu == false) {
            float zoomReal = GetComponent<CameraFocus>().myCamera.fieldOfView;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			transform.position = cameraHook.transform.position;

			//Camera Movement
			yaw += hcamspeed * Input.GetAxis ("Mouse X");
			pitch -= vcamspeed * Input.GetAxis ("Mouse Y");

			//Ensure Yaw doesn't exceed constraints
			if (yaw > (yawMax + (((zoomReal - 60) * -1) * yawZoom))) {
				yaw = yawMax + (((zoomReal - 60) * -1) * yawZoom);
			}
			if (yaw < (yawMin - (((zoomReal - 60) * -1) * yawZoom))) {
				yaw = yawMin - (((zoomReal - 60) * -1) * yawZoom);
			}
			//Ensure Pitch doesn't exceed constraints
			if (pitch > (pitchMax + (((zoomReal - 60) * -1) * pitchZoom))) {
				pitch = pitchMax + (((zoomReal - 60) * -1) * pitchZoom);
			}
			if (pitch < (pitchMin - (((zoomReal - 60) * -1) * pitchZoom))) {
				pitch = pitchMin - (((zoomReal - 60) * -1) * pitchZoom);
			}

			if (yaw > yawOrig + 10f) {
				yaw += -0.2f;
			}
			if (yaw < yawOrig - 10f) {
				yaw += 0.2f;
			}
			if (pitch > pitchOrig + 5f) {
				pitch += -0.1f;
			}
			if (pitch < pitchOrig - 5f) {
				pitch += 0.1f;
			}

			//Actually Move Camera
			transform.eulerAngles = new Vector3 (pitch, yaw, 0.0f);
		}
	}
}
