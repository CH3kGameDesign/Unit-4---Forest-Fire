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
    public GameObject landParticles;                //Particles on Land
    public GameObject glideParticles;               //Particles whilst Gliding
    public GameObject bodyRotate;                   //For Rotating with Movement
    
	private float distanceOfRay = 0.2f;             //Raycheck distance for whether can jump

	public Rigidbody rb;                            //Rigidbody Reference
	public GameObject cameraObject;

	private bool isGrounded;                        //Whether touching Ground or not
	private bool jumping;							//Whether Jumping Up

    private float lastZPosition;                    //For Change Direction
    
    private int jumpTimer;                          //FOR JUMP ANIMATION
	private int glideTimer;							//So you can't glide indefinitely

	public bool canMove = true;						//Whether you're allowed to move

	// Use this for initialization
	void Start () {
        //Set Variables
		rb = GetComponent<Rigidbody> ();
		jumping = false;
	}

	// Update is called once per frame
	void FixedUpdate () {
        //Movement
		Vector3 movement = Vector3.zero;
		if (cameraObject.GetComponent<CameraController> ().mainMenu == false && canMove == true) {
			movement = transform.forward * Input.GetAxis ("Horizontal") * speed;
		}

			if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Run")) {
				if (isGrounded == true) {
					if (movement.z < 0) {
						movement = Vector3.zero;
					}
				}
			}
			if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Run 2")) {
				if (isGrounded == true) {
					if (movement.z > 0) {
						movement = Vector3.zero;
					}
				}
			}

		if (jumping == false) {
			rb.MovePosition (transform.position + movement);
		}

        

        //directionFace Variable

        if (lastZPosition + 0.01f < transform.position.z)
        {
            if (movement.z != 0)
            {
                GetComponent<Animator>().SetBool("Run", true);
            }

        }
        else if (lastZPosition - 0.01f > transform.position.z)
        {
            if (movement.z != 0)
            {
                GetComponent<Animator>().SetBool("Run 2", true);
            }

        }
        else
        {
            GetComponent<Animator>().SetBool("Run", false);
            GetComponent<Animator>().SetBool("Run 2", false);
        }
        lastZPosition = transform.position.z;

        if (GetComponent<Animator>().GetBool("Jump") == true)
        {
            if (jumpTimer > 5)
            {
                GetComponent<Animator>().SetBool("Jump", false);
            }
            jumpTimer += 1;
        }
        else jumpTimer = 0;


        //////////////////////////////////////////


        //Raycast If Grounded
        if (Physics.Raycast((transform.position + new Vector3(0.35f, 0.1f, 0.35f)), -transform.up, distanceOfRay))
            {
                if (isGrounded == false)
                {
                    Instantiate(landParticles, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                }
                isGrounded = true;
			glideTimer = 0;
            }
		else if (Physics.Raycast((transform.position + new Vector3(-0.35f, 0.1f, 0.35f)), -transform.up, distanceOfRay))
            {
            if (isGrounded == false)
            {
                Instantiate(landParticles, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            }
            isGrounded = true;
			glideTimer = 0;
            }
		else if (Physics.Raycast((transform.position + new Vector3(-0.35f, 0.1f, -0.35f)), -transform.up, distanceOfRay))
            {
            if (isGrounded == false)
            {
                Instantiate(landParticles, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            }
            isGrounded = true;
			glideTimer = 0;
            }
		else if (Physics.Raycast((transform.position + new Vector3(0.35f, 0.1f, -0.35f)), -transform.up, distanceOfRay))
            {
            if (isGrounded == false)
            {
                Instantiate(landParticles, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            }
            isGrounded = true;
			glideTimer = 0;
            }
		else if (Physics.Raycast((transform.position + new Vector3(0, 0.1f, 0)), -transform.up, distanceOfRay))
            {
            if (isGrounded == false)
            {
                Instantiate(landParticles, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            }
            isGrounded = true;
			glideTimer = 0;
            }
            else
            {
                isGrounded = false;
			//Gliding
			if (cameraObject.GetComponent<CameraController> ().mainMenu == false && canMove == true) {
				if (gameObject.GetComponent<Rigidbody> ().velocity.y <= 0) {
					jumping = false;
					if (Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.JoystickButton0)) {
						if (glideTimer < 60) {
							if (gameObject.GetComponent<Rigidbody> ().velocity.y < -0.5f) {
								gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (gameObject.GetComponent<Rigidbody> ().velocity.x, -0.5f, gameObject.GetComponent<Rigidbody> ().velocity.z);
								glideTimer++;
                                Instantiate (glideParticles, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                            }
						}
					}
				}
			}
            }

            //Raycast Lines
		Debug.DrawLine(transform.position + new Vector3(0, 0.1f, 0), transform.position + new Vector3(0, -0.1f, 0));
		Debug.DrawLine(transform.position + new Vector3(0.35f, 0.1f, 0.35f), transform.position + new Vector3(0.35f, -0.1f, 0.35f));
		Debug.DrawLine(transform.position + new Vector3(-0.35f, 0.1f, 0.35f), transform.position + new Vector3(-0.35f, -0.1f, 0.35f));
		Debug.DrawLine(transform.position + new Vector3(-0.35f, 0.1f, -0.35f), transform.position + new Vector3(-0.35f, -0.1f, -0.35f));
		Debug.DrawLine(transform.position + new Vector3(0.35f, 0.1f, -0.35f), transform.position + new Vector3(0.35f, -0.1f, -0.35f));

            //Jump
		if (cameraObject.GetComponent<CameraController> ().mainMenu == false && canMove == true) {
			if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
				gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (gameObject.GetComponent<Rigidbody> ().velocity.x, jumpForce, gameObject.GetComponent<Rigidbody> ().velocity.z);
				Instantiate (jumpParticles, new Vector3 (transform.position.x, transform.position.y, transform.position.z), transform.rotation);
				GetComponent<Animator> ().SetBool ("Jump", true);
				jumping = true;
			}
			if (Input.GetKeyDown (KeyCode.JoystickButton0) && isGrounded) {
				gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (gameObject.GetComponent<Rigidbody> ().velocity.x, jumpForce, gameObject.GetComponent<Rigidbody> ().velocity.z);
				Instantiate (jumpParticles, new Vector3 (transform.position.x, transform.position.y, transform.position.z), transform.rotation);
				GetComponent<Animator> ().SetBool ("Jump", true);
				jumping = true;
			}
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

       
	}


    //Respawn
	void Restart () {
		SceneManager.LoadScene (0);
	}
}
