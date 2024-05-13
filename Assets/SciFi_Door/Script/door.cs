using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
	GameObject thedoor;
    //public InventoryItemController inventoryItemController;
    public SphereCollider sphereCollider;
    public GameObject artifact;
    public GameObject openDoor;
    public GameObject useItems;
    private void Awake()
    {
     //   sphereCollider.enabled = false;
     
        sphereCollider = GetComponent<SphereCollider>();
    }
    private void Update()
    {
       
        if (artifact)
        {
            sphereCollider.enabled = false;
        }

        if (!artifact)
        {
            sphereCollider.enabled = true;
            openDoor.SetActive(true);
            useItems.SetActive(true);
        }
    }
   

    void OnTriggerEnter (Collider obj)
    {
	thedoor = GameObject.FindWithTag("SF_Door");
	thedoor.GetComponent<Animation>().Play("open");
}

void OnTriggerExit (Collider obj)
    {
	thedoor = GameObject.FindWithTag("SF_Door");
	thedoor.GetComponent<Animation>().Play("close");
}
}