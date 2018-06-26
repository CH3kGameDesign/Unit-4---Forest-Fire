using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtOrigin : MonoBehaviour {

	private float maxHeight = 12.5f;
	private float minHeight = -8.5f;
	private float target;

	public float speed;
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, new Vector3(transform.position.x, target, transform.position.z), step);
		if (transform.position.y > maxHeight - 0.05f)
			target = minHeight;
		if (transform.position.y < minHeight + 0.05f)
			target = maxHeight;
	}
}
