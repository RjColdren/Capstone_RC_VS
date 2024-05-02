using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

//Code created by SoloGameDev, Partially edited by me. Link: https://www.youtube.com/watch?v=AoD_F1fSFFg
[System.Serializable]
public class InventoryItemController : MonoBehaviour
{

    //instance of item
    public Item item;

    //creates a button reference
    public Button RemoveButton;
    
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
                //Call increase health from PlayerObjectInteraction
                PlayerObjectInteraction.instance.IncreaseHealth(item.value);
                //Remove the item from the list
                RemoveItem();
                break;
                //if it is an artifact, do nothing
            case Item.ItemType.Artifact:
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
}
