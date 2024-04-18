using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    //Creates a SerializeField in unity for the private variables.
    [SerializeField] private float maxDistance = 2f;
    [SerializeField] private Text interactableName;

    private InteractionObject targetInteraction;

    // Update is called once per frame
    void Update()
    {
        //creates a vector3 for the main cameras current position.
        Vector3 origin = Camera.main.transform.position;
        //creates a vector3 for what the main camera is currently looking at.
        Vector3 direction = Camera.main.transform.forward;
        //Creates a reference to 'RaycastHit' and initializes. 
        RaycastHit raycastHit = new RaycastHit();
        //string variable called 'objectName' with no input
        string interactionText = "";
        //Sets 'targetInteraction' to null.
        targetInteraction = null;

        if (Physics.Raycast(origin, direction, out raycastHit, maxDistance))
        {
            //objectName becomes the name of whatever gameObject that has
            //a collider the main camera is looking at

            targetInteraction = raycastHit.collider.gameObject.GetComponent<InteractionObject>();
        }

        if (targetInteraction && targetInteraction.enabled)
        {
            //makes interactionText equal to the GetInteractionText method
            interactionText = targetInteraction.GetInteractionText();
        }

        //Calls the method with the objectName as the text.
        SetInteractableNameText(interactionText);
    }

    //Method with 1 parameter
    private void SetInteractableNameText(string newText)
    {
        //ensures interactableName is not null
        if (interactableName)
        {
            //makes the text for interactable name equal to whatever
            //'newText' is
            interactableName.text = newText;
        }
    }

    public void TryInteract()
    {
        //if targetInteraction is not null
        if (targetInteraction && targetInteraction.enabled)
        {
            //call targetInteraction's 'Interact' method
            targetInteraction.Interact();
        }
    }
}
