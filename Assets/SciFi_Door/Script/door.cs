using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
	GameObject thedoor;
    public InventoryItemController inventoryItemController;
    public SphereCollider sphereCollider;

    private void Awake()
    {
        sphereCollider.enabled = false;
     
        sphereCollider = GetComponent<SphereCollider>();
    }
    private void Update()
    {
        inventoryItemController = FindAnyObjectByType<InventoryItemController>();
        if (inventoryItemController.artifactGrabbed == true)
        {
            sphereCollider.enabled = true;
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