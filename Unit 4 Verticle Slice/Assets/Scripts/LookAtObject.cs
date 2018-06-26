using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour {

	public GameObject lookAt;
	public GameObject lookAtOrigin;

	public float speed;

	// Update is called once per frame
	void Start () {
		lookAt = lookAtOrigin;
	}

	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, lookAt.transform.position, step);
	}
}
