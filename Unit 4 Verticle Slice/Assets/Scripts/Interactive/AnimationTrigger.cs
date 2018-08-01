using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour {

    /*
     Is responsible for:
     - Forcing Animation At Trigger Point
     */

    public string animationName;        //Which Animation

    private void OnTriggerStay(Collider other)
    {
         if (other.tag == "Player")
        {
            other.GetComponent<Animator>().Play(animationName);
            other.GetComponent<Movement>().canMove = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Movement>().canMove = true;
        }
    }
}
