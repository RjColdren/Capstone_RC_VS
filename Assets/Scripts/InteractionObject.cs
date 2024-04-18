using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class InteractionObject : MonoBehaviour
{
    //Forces unity to make a Serialized field for the string in the inspector
    [SerializeField] private string interactionText = "I'm an interactable object!";
    //Instantiates a UnityEvent variable.
    public Item item;
    private void OnEnable()
    {
      
    }


    public string GetInteractionText()
    {
        //returns the interactionText string
        return interactionText;
    }
    
    //when interacted with
    public void Interact()
    {
        //adds the item from the inventory manager
            InventoryManager.Instance.Add(item);
        //destroys the gameobject
            Destroy(gameObject);
    }
}