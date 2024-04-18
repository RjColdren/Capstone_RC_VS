/*
  
        *IMPLEMENT LATER*
        Allows the player to jump to get to higher areas, will also allow the player to vault/grab onto other objects.

 using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    public float jumpPower = 20f;
    public float gravity = -20f;
    public bool hasJumped;
    public LayerMask whatIsGround;
    Vector3 moveVelocity;

    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {

        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.includeLayers == whatIsGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveVelocity.y = jumpPower;
            }
        }
        moveVelocity.y += gravity * Time.deltaTime;
    }

    

    
}
*/