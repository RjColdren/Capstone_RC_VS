
//*IMPLEMENT LATER*
// Allows the player to jump to get to higher areas, will also allow the player to vault/grab onto other objects.

using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Jump : MonoBehaviour
{
    public CharacterController controller;
    public float jumpPower;
    public float gravity = -9.81f;
    private Vector3 direction;
    public bool isGrounded() => controller.isGrounded;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (controller.isGrounded)
        { 
         if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpPower;
            }
        }
        direction.y += gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);

    }

}
