using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtOrigin : MonoBehaviour {

	private float maxHeight = 4f;
	private float minHeight = 0f;
	private float target;
    private Vector3 origPos;

	public float speed;
    public Camera mainCamera;

	void Start () {
        origPos = transform.localPosition;
		//target = maxHeight;
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

        
        /*
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, new Vector3(transform.position.x, target, transform.position.z), step);
		if (transform.position.y > maxHeight - 0.5f)
			target = minHeight;
		if (transform.position.y < minHeight + 0.5f)
			target = maxHeight;
            */
    }
}
