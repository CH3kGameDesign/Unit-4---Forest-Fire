using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    /*
     Is responsible for:
     - Look at Objects In Distance when Player Enters Trigger
     */

    public GameObject playerLook;           //Look at GameObject
	public GameObject lookAt;               //Where To Look
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			playerLook.GetComponent<LookAtObject> ().lookAt = lookAt;
            Debug.Log("yep");
		}
	}
    
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			playerLook.GetComponent<LookAtObject> ().lookAt = playerLook.GetComponent<LookAtObject> ().lookAtOrigin;
		}
	}
    
}
