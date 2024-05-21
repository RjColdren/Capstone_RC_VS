using CapstoneFps_RC;
using TowerDefense;
using UnityEngine;
using UnityEngine.UI;

//Code created by SoloGameDev, Partially edited by me. Link: https://www.youtube.com/watch?v=AoD_F1fSFFg
[System.Serializable]
public class InventoryItemController : MonoBehaviour
{
    //Instances of scripts
    InventoryItemController instance;
    public InventoryManager inventorymanager;
    public Health health;
    public Shooting ammo;

    //Bool Variable
    public bool artifactGrabbed;

    //instance of item
    public Item item;


    //creates a button reference
    public Button RemoveButton;
    public GameObject fullHealthUI;
    public GameObject fullAmmoUI;

    private void Awake()
    {
        //Ensures there is only ever one instance of the class
        if (instance)
        {
            //Will destroy this script if there already is an instance
            Destroy(this);

        }
        //else
        else
        {
            //Will create an instance that will not be destroyed on each scene
            instance = this;
            DontDestroyOnLoad(this);
        }


        //Finds the objects in the scenes for these scripts
       inventorymanager = FindAnyObjectByType<InventoryManager>();
       ammo = FindAnyObjectByType<Shooting>();

        //sets the UI to the inventory manager buttons
        fullHealthUI = inventorymanager.fullHealthUI;
        fullAmmoUI = inventorymanager.fullAmmoUI;

        //automatically sets the artifact grabbed to false
        artifactGrabbed = false;
    }

    //removes the item from the list
    public void RemoveItem()
    {
        //removes the item from the list
        InventoryManager.Instance.Remove(item);
        //destroys the gameObject
        Destroy(gameObject);
    }

    //adds an item to the list
    public void AddItem(Item newItem)
    {
        //sets item to whatever newItem is
        
        item = newItem;
}
    
    //"Uses" the item 
    public void UseItem()
    {
        //Checks which item type the item is
      switch (item.itemType)
        {
            //if it is a health potion
            case Item.ItemType.HealthPotion:
                //IF the players health is less than 100
                if(health.currentHealth < 100)
                {  
                    //Call increase health from PlayerObjectInteraction
                    PlayerObjectInteraction.instance.IncreaseHealth(item.value);

                    //Remove the item from the list
                    RemoveItem();
                    break;

                }
                //ELSE IF health is equal to 100
                else if (health.currentHealth == 100)
                {
                    //Set the UI active and Invoke ResetHealth UI after 2 seconds
                    fullHealthUI.SetActive(true);
                    Invoke("ResetHealthUI", 2);
                    break;
                }
                else
                {
                    break;
                }
            
                //if it is an artifact
            case Item.ItemType.Artifact:
                //Find the value of the item and give the player that in cash
                PlayerObjectInteraction.instance.IncreaseCash(item.value);
                //artifactGrabbed is equal to true
                artifactGrabbed = true;
                //Removes the Item from the list
                RemoveItem();
                break;

                //if it's an ammocrate
            case Item.ItemType.AmmoCrate:
                //add the amount of ammo the item has as value
                PlayerObjectInteraction.instance.AddAmmo(item.value);
                //remove the item from the list
                RemoveItem();
                break;

                //default do nothing
            default: 
                break;
        }

        
    }

    //Resets the health UI
    public void ResetHealthUI()
    {
        //sets the fullHealthUI to false
        fullHealthUI.SetActive(false);
    }
    //Resets the Ammo UI
    public void ResetAmmoUI()
    {
        //sets the fullAmmoUI to false
        fullAmmoUI.SetActive(false);
    }
}
