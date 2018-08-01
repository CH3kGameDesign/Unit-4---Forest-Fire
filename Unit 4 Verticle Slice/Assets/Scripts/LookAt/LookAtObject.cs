using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour {

    /*
     Is responsible for:
     - Where The Player Looks
     - Moving where the Player Looks
     */

    public GameObject lookAt;               //Where To Move To
	public GameObject lookAtOrigin;         //Original Position

	public float speed;                     //How Fast To Move

	void Start () {
		lookAt = lookAtOrigin;
	}

	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, lookAt.transform.position, step);
	}
}
