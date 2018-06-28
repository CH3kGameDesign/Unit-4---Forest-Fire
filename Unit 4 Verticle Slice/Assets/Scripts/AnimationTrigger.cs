using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour {

    public string animationName;

    private void OnTriggerStay(Collider other)
    {
         if (other.tag == "Player")
        {
            other.GetComponent<Animator>().Play(animationName);
        }
    }
}
