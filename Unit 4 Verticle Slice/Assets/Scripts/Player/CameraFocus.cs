using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class CameraFocus : MonoBehaviour {

    /*
     Is responsible for:
     - Zooming In the Camera
     */

    private bool focus = false;                         //Zoom in or not
    public Camera myCamera;                             //Main Camera Object
	public PostProcessingProfile camFocusProfile;       //Camera's Post Processing Profile

    public float maxZoom;                               //Max Zoom It Can Zoom
    public float zoomSpeed;                             //Speed of the zoom
    public float maxDOF;                                //Max Depth of Field
    public float DOFSpeed;                              //Speed of Depth of Field

    //Original and Current Floats
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
}
