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
    public int id;
    public string itemName;
    public int value;

    private void Update()
    {
        items = inventoryItems.items;
    }
    public void ItemList()
    {
       foreach (Item item in items) 
        { 
        id = item.id;
        itemName = item.name;
        value = item.value;
        }
    }

    public void FindItem()
    {
       
    }
    
}
