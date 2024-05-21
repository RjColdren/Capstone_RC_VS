using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Jump : MonoBehaviour
{
    //variables, vectors and script references
    public CharacterController controller;
    public float jumpPower;
    public float gravity = -9.81f;
    private Vector3 direction;
    public bool isGrounded() => controller.isGrounded;

    private void Awake()
    {
        //finds the component in the gameobject
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //if the object controller is grounded
        if (controller.isGrounded)
        { 
            //IF the jump button is pressed
         if (Input.GetButtonDown("Jump"))
            {
                //jump (increase the players position upwards
                direction.y = jumpPower;
            }
        }
        //adds gravity to the direction
        direction.y += gravity * Time.deltaTime;
        //moves the controller towards the direction
        controller.Move(direction * Time.deltaTime);

    }

}
