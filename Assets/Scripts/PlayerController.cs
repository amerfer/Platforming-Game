using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;  //the speed of the player is moving
    public float jumpForce;  // how high the player jumps

    public CharacterController controller;
    private Vector3 moveDriection;

    public float gravityScale;// how fast the player falls

    public Animator animate;

    //Use for the changing the character's view 
    public Transform pivot;
    public float rotateSpeed;

    public GameObject playerModel;

    public float knockBackForce;// how far the knock back of the player
    public float knockBackTime;// how long the player is knocked backed
    private float knockBackCounter;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); // Getting the "CharacterController" that's built in Unity and storing it to this variable
    }

    // Update is called once per frame
    void Update()
    {
        //Player control
        //moveDriection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDriection.y, Input.GetAxis("Vertical") * moveSpeed);

        if (knockBackCounter <= 0) // if the player is not knocked back
        {
            float yStore = moveDriection.y; //stores the current y value

            moveDriection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
            moveDriection = moveDriection.normalized * moveSpeed;
            moveDriection.y = yStore;


            //checks if player is on grounded
            if (controller.isGrounded)
            {
                // this will stop the gravity (the y value) to continously decrecment
                moveDriection.y = 0f;

                if (Input.GetButtonDown("Jump"))
                {
                    moveDriection.y = jumpForce;
                }
            }
        }

        else
        {
            knockBackCounter -= Time.deltaTime;
        }

        moveDriection.y = moveDriection.y + Physics.gravity.y * gravityScale;

        controller.Move(moveDriection * Time.deltaTime); //Controlling the player

        //Move the player  in different direction based on the camera look direction
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDriection.x, 0f, moveDriection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        //Refering to the animation 
        animate.SetBool("isGround", controller.isGrounded); //if player is in the ground, do jump animation
        animate.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal")))); //If there's an input, do animation
    }


    //the function to knockback the character
    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime; 
        moveDriection = direction * knockBackForce;

        moveDriection.y = knockBackForce; // get knocked while in the air
    }
}
