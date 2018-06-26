using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

	public GameObject playerLook;
	public GameObject lookAt;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			playerLook.GetComponent<LookAtObject> ().lookAt = lookAt;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			playerLook.GetComponent<LookAtObject> ().lookAt = playerLook.GetComponent<LookAtObject> ().lookAtOrigin;
		}
	}
}
