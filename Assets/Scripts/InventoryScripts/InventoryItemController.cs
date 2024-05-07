using CapstoneFps_RC;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TowerDefense;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

//Code created by SoloGameDev, Partially edited by me. Link: https://www.youtube.com/watch?v=AoD_F1fSFFg
[System.Serializable]
public class InventoryItemController : MonoBehaviour
{
    InventoryItemController instance;
    public InventoryManager inventorymanager;
    public Health health;
    public Shooting ammo;

    //instance of item
    public Item item;

    //creates a button reference
    public Button RemoveButton;
    public GameObject fullHealthUI;
    public GameObject fullAmmoUI;
    private void Awake()
    {
        if (instance)
        {
            Destroy(this);

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

       inventorymanager = FindAnyObjectByType<InventoryManager>();
       ammo = FindAnyObjectByType<Shooting>();

        fullHealthUI = inventorymanager.fullHealthUI;
        fullAmmoUI = inventorymanager.fullAmmoUI;

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

                if(health.currentHealth < 100)
                {  
                    //Call increase health from PlayerObjectInteraction
                    PlayerObjectInteraction.instance.IncreaseHealth(item.value);
                    //Remove the item from the list
                    RemoveItem();
                    break;

                }
                if (health.currentHealth >= 100)
                {
                    fullHealthUI.SetActive(true);
                    Invoke("ResetHealthUI", 2);
                    break;
                }
                else
                {
                    break;
                }
            
                //if it is an artifact, do nothing
            case Item.ItemType.Artifact1:
                PlayerObjectInteraction.instance.IncreaseCash(item.value);
                RemoveItem();
                break;
         

            case Item.ItemType.AmmoCrate:
                PlayerObjectInteraction.instance.AddAmmo(item.value);
                RemoveItem();
                break;

                //default do nothing
            default: 
                break;
        }

        
    }

    public void ResetHealthUI()
    {
        fullHealthUI.SetActive(false);
    }

    public void ResetAmmoUI()
    {
        fullAmmoUI.SetActive(false);
    }
}
