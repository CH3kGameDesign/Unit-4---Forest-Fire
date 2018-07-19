using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class CameraFocus : MonoBehaviour {
	
	private bool focus = false;
    public Camera myCamera;
	public PostProcessingProfile camFocusProfile;
    public float maxZoom;
    public float zoomSpeed;
    public float maxDOF;
    public float DOFSpeed;

    private float defaultZoom;
    public float targetZoom;
    private float defaultDOF;
    private float targetDOF;

    void Start()
    {
        defaultZoom = myCamera.fieldOfView;
        defaultDOF = 5.9f;
        camFocusProfile = myCamera.GetComponent<PostProcessingBehaviour>().profile;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(1) || Input.GetAxis("Controller Triggers") != 0)
        {
            targetZoom = maxZoom;
            targetDOF = maxDOF;
        }
        else
        {
            targetZoom = defaultZoom;
            targetDOF = defaultDOF;
        }
        myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, targetZoom, Time.fixedDeltaTime * zoomSpeed);
        var dof = camFocusProfile.depthOfField.settings;

        dof.focusDistance = Mathf.Lerp(dof.focusDistance, targetDOF, Time.fixedDeltaTime * DOFSpeed);

        camFocusProfile.depthOfField.settings = dof;
    }

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
