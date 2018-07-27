using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsFade : MonoBehaviour {

    public int fadeOut = 0;
    public Image blackness;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (fadeOut >= 20)
            blackness.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(blackness.GetComponent<CanvasGroup>().alpha, 0, 0.01f);

        fadeOut++;
	}
}
