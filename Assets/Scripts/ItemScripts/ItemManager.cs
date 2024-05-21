using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Item;

public class ItemManager : MonoBehaviour
{
    Item item;
    public List<Item> items = new List<Item>();
    public int itemCount;
    InventoryManager inventoryItems;

    //variables and Sprite.
    public List<int> id = new List<int>();
    public List<string> itemName = new List<string>();
    public List<int> value = new List<int>();

    private void Update()
    {
        //creates a list equal to the amount of items in items
        foreach (var item in inventoryItems.items)
        {
           items = inventoryItems.items;
        }
    }

    //
    public void ItemList()
    {
        //adds each items id, name and value to a list
       foreach (Item item in inventoryItems.items) 
        { 
        id.Add(item.id);
        itemName.Add(item.name);
        value.Add(item.value);
        }
    }

    public void FindItem()
    {
       
    }
    
}
