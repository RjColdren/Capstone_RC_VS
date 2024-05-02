using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class ShopSystem : MonoBehaviour
{
    public static ShopSystem instance;
    public Event useShop = new Event();
    public List<Item> shopItems = new List<Item>();
    public GameObject shopUI;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
