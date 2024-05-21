using UnityEngine;
using UnityEngine.Events;

public class InteractionObject : MonoBehaviour
{
    //Forces unity to make a Serialized field for the string in the inspector
    [SerializeField] private string interactionText = "I'm an interactable object!";
    //Initializes a UnityEvent variable, and references to other scripts.
    public Item item;
    public Currency currency;
    public int cost;
    public GameObject noCurrency;

    public UnityEvent extra = new UnityEvent();
    private void Start()
    {
        //finds currency in the scene
        currency = FindAnyObjectByType<Currency>();
    }

    //Gets the interaction text
    public string GetInteractionText()
    {
        //returns the interactionText string
        return interactionText;
    }
    
    //when interacted with
    public void Interact()
    {
        //IF cost is lessthan or equal to currency
        if (cost <= currency.currentCurrency)
        {
            //remove the currency that this object costs
            currency.RemoveCurrency(cost);
            //adds the item from the inventory manager
            InventoryManager.Instance.Add(item);

            extra.Invoke();
            //destroys the gameobject
            Destroy(gameObject);
        }
        //IF anything ELSE
        else
        {
            //set the UI that tells the player that they have no currency to true
            noCurrency.SetActive(true);
            Invoke("DisableUI", 1);
        }
        

    }

    //Disables the UI
    public void DisableUI()
    {
        noCurrency.SetActive(false);
    }
}