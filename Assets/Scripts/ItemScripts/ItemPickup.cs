using UnityEngine;


//Code created by SoloGameDev, Partially edited by me. Link: https://www.youtube.com/watch?v=AoD_F1fSFFg
[System.Serializable]
public class ItemPickup : MonoBehaviour
{
    //Variables, Vectors, Scripts and Raycast
    [SerializeField] private float maxDistance = 2f;
    public Item item;
    RaycastHit raycastHit = new RaycastHit();
    Vector3 origin;
    Vector3 direction;
    private InteractionObject targetInteraction;

    private void Awake()
    
    {
        //Creates a Vector3 for where the Camera is looking at
         origin = Camera.main.transform.position;
        //creates a vector3 for what the main camera is currently looking at.
         direction = Camera.main.transform.forward;

    }

    //"PickUp" the object
    public void Pickup()
    {
        //Adds the item into the InventoryManager
        InventoryManager.Instance.Add(item);
        //Destroys the gameObject
        Destroy(gameObject);
    }

    private void Update()
    {
        //sets target interaction to null
        targetInteraction = null;

      //IF it is in the bounds of the raycast
        if (Physics.Raycast(origin, direction, out raycastHit, maxDistance))
        {
            //sets targetInteraction to the Interaction object of the object in sight.
            targetInteraction = raycastHit.collider.gameObject.GetComponent<InteractionObject>();
        }
      
    }

}
