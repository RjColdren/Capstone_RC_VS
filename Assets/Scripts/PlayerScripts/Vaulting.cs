using System.Collections;
using UnityEngine;


public class Vaulting : MonoBehaviour
{
    //This Script was created by JonDevTutorials -- https://www.youtube.com/watch?v=9k7iBucBV7s&t=18s

    //Variables and a reference to the camera
    private int vaultLayer;
    public Camera cam;
    private float playerHeight = 3f;
    private float playerRadius = 1f;
    public GameObject vaultingUI;
    void Start()
    {
        //Makes "vaultLayer" equal to the "VaultLayer" in unity
        vaultLayer = LayerMask.NameToLayer("VaultLayer");
        //vault layer is equal to 
        vaultLayer = ~vaultLayer;
    }

    // Update is called once per frame
    void Update()
    {
        //calls vault every update
        Vault();
        //vaultingUI.SetActive(false);
    }
    
    //Allows the player to "Latch" onto objects and "Pull" themselves ontop of them

    private void Vault()
    {
        //if space is pushed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out var firstHit, 1f, vaultLayer))
            {

                //  print("vaultable in front");
               // vaultingUI.SetActive(true);

                if (Physics.Raycast(firstHit.point + (cam.transform.forward * playerRadius) + (Vector3.up * 0.6f * playerHeight), Vector3.down, out var secondHit, playerHeight))
                {
                    //  print("found place to land");
                    //
                    
                    StartCoroutine(LerpVault(secondHit.point, 0.5f));
                   // 
                }

               
            }
        }

    }

    //Actually performs the vault
    IEnumerator LerpVault(Vector3 targetPosition, float duration)
    {
        //Variables and Vectors
        float time = 0;
        Vector3 startPosition = transform.position;

        //While time is less than duration
        while (time < duration)
        {
            //Vaults the player on top of the object
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            //increases the time 
            time += Time.deltaTime;
            //yield return statement
            yield return null;
        }
        //makes the transform position the target position
        transform.position = targetPosition;

        //vaultingUI.SetActive(false);
    }
}