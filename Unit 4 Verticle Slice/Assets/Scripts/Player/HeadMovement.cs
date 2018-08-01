using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour {

    /*
     Is responsible for:
     - Actually Move the Head
     - Make Sure Head Stays On Body
     */

    public GameObject lookAt;               //Where To Look
    public GameObject headTransform;        //Where the Head should be

	// Update is called once per frame
	void Update () {
		transform.LookAt (lookAt.transform.position);
        transform.position = headTransform.transform.position;
	}
}
