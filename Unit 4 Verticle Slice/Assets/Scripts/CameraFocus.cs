using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class CameraFocus : MonoBehaviour {
	
	private bool focus = false;
	public GameObject camera;
	public PostProcessingProfile camFocusProfile;
	/*
	// Update is called once per frame
	void Update () {
		camFocusProfile = camera.GetComponent<PostProcessingBehaviour> ().profile;

		if (focus == true) {
			if (camera.GetComponent<PostProcessingBehaviour> ().profile.depthOfField.settings.focusDistance < 9)
				camFocusProfile.depthOfField.settings.focusDistance += 0.1f;
		} else {
			if (camera.GetComponent<PostProcessingBehaviour> ().profile.depthOfField.settings.focusDistance > 5.9f)
				camFocusProfile.depthOfField.settings.focusDistance -= 0.1f;
		}
		camera.GetComponent<PostProcessingBehaviour> ().profile = camFocusProfile;
	}

	void OnTriggerEnter () {
		focus = true;
	}

	void OnTriggerExit () {
		focus = false;
	}
	*/
}
