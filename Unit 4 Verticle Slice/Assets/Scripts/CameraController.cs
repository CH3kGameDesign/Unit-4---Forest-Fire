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
	private float yawOrig;
	private float pitchOrig;

	//Maximum yaw Rotations
	public float yawMax = 60;
	public float yawMin = -120;

    //Maximum pitch Rotations
	public float pitchMax = 60;
	public float pitchMin = -120;

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
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			transform.position = cameraHook.transform.position;

			//Camera Movement
			yaw += hcamspeed * Input.GetAxis ("Mouse X");
			pitch -= vcamspeed * Input.GetAxis ("Mouse Y");

			//Ensure Yaw doesn't exceed constraints
			if (yaw > yawMax) {
				yaw = yawMax;
			}
			if (yaw < yawMin) {
				yaw = yawMin;
			}
			//Ensure Pitch doesn't exceed constraints
			if (pitch > pitchMax) {
				pitch = pitchMax;
			}
			if (pitch < pitchMin) {
				pitch = pitchMin;
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
