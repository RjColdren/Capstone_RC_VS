using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Code created by SoloGameDev, Partially edited by me. Link: https://www.youtube.com/watch?v=AoD_F1fSFFg

public class ChestItemController : MonoBehaviour
{
    //instance of item
    Item item;

    //creates a reference to a button
    public Button RemoveButton;

    //removes the item from the list
    public void RemoveItem()
    {
        //Removes the item from the list
        InventoryManager.Instance.Remove(item);
        
        //Destroys the gameObject.
        Destroy(gameObject);
    }

    //Adds an item to the list
    public void AddItem(Item newItem)
    {
        //sets item as whatever the newItem is.
        item = newItem;
    }
}
