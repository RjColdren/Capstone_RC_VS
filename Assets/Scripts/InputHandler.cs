using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    //Creates references for the scripts 'FirstPersonCamera' and 'CharacterMovement'
    FirstPersonCamera firstPersonCamera;
    CharacterMovement characterMovement;
    PlayerInteraction playerInteraction;

    // Start is called before the first frame update
    void Start()
    {
        //Ensures that both script components are added to the GameObject
        firstPersonCamera = GetComponent<FirstPersonCamera>();
        characterMovement = GetComponent<CharacterMovement>();
        playerInteraction = GetComponent<PlayerInteraction>();


    }

    // Update is called once per frame
    void Update()
    {
        //Calls the methods every frame
        HandleCameraInput();
        HandleMoveInput();
        HandleInteractionInput();

    }

    void HandleCameraInput()
    {
        //Calls upon the method from the 'firstPersonCamera' script and uses
        //the mouses inputs on both the x and y axis with a frame rate
        //independent time variable.
        firstPersonCamera.AddXAxisInput(Input.GetAxis("Mouse Y") * Time.deltaTime);
        firstPersonCamera.AddYAxisInput(Input.GetAxis("Mouse X") * Time.deltaTime);
    }



    void HandleMoveInput()
    {
        //Creates 2 floats to control the characters movement using  
        //vertical and horizontal movement
        float forwardInput = Input.GetAxis("Vertical");
        float rightInput = Input.GetAxis("Horizontal");

        //Calls upon the method from the 'CharacterMovement' script.
        characterMovement.AddMoveInput(forwardInput, rightInput);
    }

    void HandleInteractionInput()
    {
        //if the player presses down 'E'
        if (Input.GetKeyDown(KeyCode.E))
        {
            //calls the 'playerInteraction' scripts method 'TryInteract'
            playerInteraction.TryInteract();
        }
    }



}
