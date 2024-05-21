using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class ShopSystem : MonoBehaviour
{
    //Instances, lists, events and gameobjects
    public static ShopSystem instance;
    public Event useShop = new Event();
    public List<Item> shopItems = new List<Item>();
    public GameObject shopUI;


    //Adds an item to the list
    public void Add(Item item)
    {
        //adds the item to the list
       shopItems.Add(item);

    }

    //removes an item from the list
    public void Remove(Item item)
    {
        //removes the item from the list
        shopItems.Remove(item);
    }


}
