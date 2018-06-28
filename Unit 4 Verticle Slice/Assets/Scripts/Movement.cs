using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    /*
    WHAT SCRIPT DOES:
    -   Moves Player
    -   Jump
    -   Restarts
    */

    public float jumpForce = 10;                    //How Much Force is Applied When Jumping
	public float speed = 2;                         //Character Speed
	public float maxspeed = 2;                      //Character MaxSpeed

    public GameObject model;                        //Player Model
    public GameObject jumpParticles;                //Particles on Jump
    
	private float distanceOfRay = 0.2f;             //Raycheck distance for whether can jump

	public Rigidbody rb;                            //Rigidbody Reference

	private bool isGrounded;                        //Whether touching Ground or not

    private float lastZPosition;                    //For Change Direction

    private float directionFace;                    //Which Direction Facing, 0 null, 1 right, 2 left

	// Use this for initialization
	void Start () {
        //Set Variables
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
        //Movement

		Vector3 moveX = transform.forward * Input.GetAxis("Horizontal") * speed;
			Vector3 moveZ = Vector3.zero;

            //Vector3 moveZ = cameraObject.transform.forward * Input.GetAxis("Vertical") * speed;

            Vector3 movement = moveX + moveZ;

            rb.MovePosition(transform.position + movement);

            
            //////////////////////////////////////////
                        

            //Raycast If Grounded
            if (Physics.Raycast((transform.position + new Vector3(0.35f, 0.1f, 0.35f)), -transform.up, distanceOfRay))
            {
                isGrounded = true;
            }
		else if (Physics.Raycast((transform.position + new Vector3(-0.35f, 0.1f, 0.35f)), -transform.up, distanceOfRay))
            {
                isGrounded = true;
            }
		else if (Physics.Raycast((transform.position + new Vector3(-0.35f, 0.1f, -0.35f)), -transform.up, distanceOfRay))
            {
                isGrounded = true;
            }
		else if (Physics.Raycast((transform.position + new Vector3(0.35f, 0.1f, -0.35f)), -transform.up, distanceOfRay))
            {
                isGrounded = true;
            }
		else if (Physics.Raycast((transform.position + new Vector3(0, 0.1f, 0)), -transform.up, distanceOfRay))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }

            //Raycast Lines
		Debug.DrawLine(transform.position + new Vector3(0, 0.1f, 0), transform.position + new Vector3(0, -0.1f, 0));
		Debug.DrawLine(transform.position + new Vector3(0.35f, 0.1f, 0.35f), transform.position + new Vector3(0.35f, -0.1f, 0.35f));
		Debug.DrawLine(transform.position + new Vector3(-0.35f, 0.1f, 0.35f), transform.position + new Vector3(-0.35f, -0.1f, 0.35f));
		Debug.DrawLine(transform.position + new Vector3(-0.35f, 0.1f, -0.35f), transform.position + new Vector3(-0.35f, -0.1f, -0.35f));
		Debug.DrawLine(transform.position + new Vector3(0.35f, 0.1f, -0.35f), transform.position + new Vector3(0.35f, -0.1f, -0.35f));

            //Jump
            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, jumpForce, gameObject.GetComponent<Rigidbody>().velocity.z);
                Instantiate(jumpParticles, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            }
            if (Input.GetKey(KeyCode.JoystickButton0) && isGrounded)
            {
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, jumpForce, gameObject.GetComponent<Rigidbody>().velocity.z);
                Instantiate(jumpParticles, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            }
        
	
	}

	void Update () {
		//Respawn Input
		if (Input.GetKeyDown (KeyCode.R)) {
			Restart ();
		}
		if (Input.GetKeyDown (KeyCode.JoystickButton3)) {
			Restart ();
		}

        //directionFace Variable
        
        if (lastZPosition + 0.01f < transform.position.z)
        {
            directionFace = 1;
            GetComponent<Animator>().SetBool("Run", true);
        } else if (lastZPosition - 0.01f > transform.position.z)
        {
            directionFace = 2;
            GetComponent<Animator>().SetBool("Run", true);
        }
        else
        {
            directionFace = 0;
            GetComponent<Animator>().SetBool("Run", false);
        }
        Debug.Log(lastZPosition - transform.position.z);
        lastZPosition = transform.position.z;
	}


    //Respawn
	void Restart () {
		SceneManager.LoadScene (0);
	}
}
