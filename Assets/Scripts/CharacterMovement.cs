using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Creates a reference to the CharacterController named "characterController"
    CharacterController characterController;
    //creates a public float called 'moveSpeed' with a value of 5
    public float moveSpeed = 5f;

    public float sprintSpeed = 50f;

    Vector3 moveDirection;

    Vector3 jumpDirection;

    public float jumpPower = 5f;

    public bool falling;

    Rigidbody rb;

    public LayerMask whatIsGround;
    // Start is called before the first frame update
    void Start()
    {
        //ensures that the component CharacterController is apart of the gameobject
        //and if not, adds it.
        characterController = GetComponent<CharacterController>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //Sets the length of the vector to a value of 1
        moveDirection.Normalize();
        //Ensures that the player will be pulled back to the ground
        moveDirection.y = -1f;

        //actually moves/calls the ability for the player to move.
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

       /* if (!falling)
        {
            if ( )
        }
       */
      
    }

    public void AddMoveInput(float forwardInput, float rightInput)
    {
        //Creates a Vector3 named "forward" and retrieves the main cameras
        //forward transform
        Vector3 forward = Camera.main.transform.forward;
        //Creates a Vector3 named "right" and retrieves the main cameras
        //right transform
        Vector3 right = Camera.main.transform.right;

        //Ensures that there is no up or down movement
        forward.y = 0f;
        //Ensures that there is no up or down movement
        right.y = 0f;

        //Sets the length of the vector to a value of 1
        forward.Normalize();
        //Sets the length of the vector to a value of 1
        right.Normalize();

        //sets the players movement in the directions specified
        moveDirection = (forwardInput * forward) + (rightInput * right);

      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            falling = false; 

        }
    }

    private void OnCollisionExit(Collision collision) 
    { 
      if (collision.gameObject.tag == "Ground")
        {
            falling = true;
        }
    }
}
