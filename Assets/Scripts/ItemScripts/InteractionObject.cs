using UnityEngine;
using UnityEngine.Events;

public class InteractionObject : MonoBehaviour
{
    //Forces unity to make a Serialized field for the string in the inspector
    [SerializeField] private string interactionText = "I'm an interactable object!";
    //Instantiates a UnityEvent variable.
    public Item item;
    public Currency currency;
    public int cost;
    public GameObject noCurrency;

    public UnityEvent extra = new UnityEvent();
    private void Start()
    {
        currency = FindAnyObjectByType<Currency>();
    }

    public string GetInteractionText()
    {
        //returns the interactionText string
        return interactionText;
    }
    
    //when interacted with
    public void Interact()
    {
        if (cost <= currency.currentCurrency)
        {
            currency.RemoveCurrency(cost);
            //adds the item from the inventory manager
            InventoryManager.Instance.Add(item);

            extra.Invoke();
            //destroys the gameobject
            Destroy(gameObject);
        }

        else
        {
            noCurrency.SetActive(true);
            Invoke("DisableUI", 1);
        }
        

    }

    public void DisableUI()
    {
        noCurrency.SetActive(false);
    }
}