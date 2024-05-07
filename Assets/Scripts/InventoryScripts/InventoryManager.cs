using CapstoneFps_RC;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Code created by SoloGameDev, Partially edited by me. Link: https://www.youtube.com/watch?v=AoD_F1fSFFg
[System.Serializable]
public class InventoryManager : MonoBehaviour
{
    //Scripts, Lists, transforms, gameObjects, toggles, arrays and buttons.
    public static InventoryManager Instance;
    public List<Item> items = new List<Item>();

    public Transform itemContent;
    public GameObject inventoryItem;

    public Toggle enableRemove;

    public InventoryItemController[] inventoryItems;

    public GameObject inventoryUI;

    public Shooting shooting;

    public Button inventoryButton;

    public GameObject fullHealthUI;
    public GameObject fullAmmoUI;
    public void Awake()
    {

        {
            //makes this the Instance of the Script
            Instance = this;
        }
    }
    private void Start()
        
    {
        //finds whatever object has the shooting script
        shooting = FindObjectOfType<Shooting>();
    }
    private void Update()
    {
        //IF the I key is pressed down
        if (Input.GetKeyDown(KeyCode.I))
        {
            //Set the UI to active
             inventoryUI.SetActive(true);
            //call ListItems
            ListItems();
            
            //turn off the cursor lock mode
            Cursor.lockState = CursorLockMode.None;
            //turn the shooting script off
            shooting.enabled = false;
        }
        
        //IF the X key is pushed down
        if (Input.GetKeyDown(KeyCode.X))
        {
            //set the inventory UI to inactive
            inventoryUI.SetActive(false);
            //lock the cursor
            Cursor.lockState = CursorLockMode.Locked;
            //disable shooting
            shooting.enabled = true;
        }
    }
    //Adds an item to the list
    public void Add(Item item)
    {
        //adds the item to the list
        items.Add(item);

    }

    //removes an item from the list
    public void Remove(Item item) 
    {
        //removes the item from the list
        items.Remove(item);
    }

    //Lists the items 
    public void ListItems()
    {
        //Destroys any excess GameObjects that are appear in the menu
        foreach (Transform item in itemContent)
        {
            //destroys the gameobject
            Destroy(item.gameObject);
        }

        //makes sure that when an item is added to the list, it gets a spot on the list
        foreach(var item in items)
        {
            //Instantiates the gameObject
            GameObject obj = Instantiate(inventoryItem, itemContent);
            //Makes sure that all of the UI is attached to a value
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

            //sets the item text to the item name
            itemName.text = item.itemName;
            //sets the items sprite to the icon picked for the item
            itemIcon.sprite = item.icon;

            //If the remove trigger is checked off
            if(enableRemove.isOn)
            {
                //set the remove button to true
                removeButton.gameObject.SetActive(true);
            }
        }

        //Calls to set the inventory items
        SetInventoryItems();
    }

    //Enables the items to be removed
    public void EnableItemsRemove()
    {
        //IF the trigger is on
        if(enableRemove.isOn)
        {

            foreach (Transform item in itemContent)
            {
                //Find the remove button and set it to true
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in itemContent)
            {
                //Find the remove button and set it to false
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }

    //Sets the inventory items
    public void SetInventoryItems()
    {
        //Gets the InventoryItemController in the children
        inventoryItems = itemContent.GetComponentsInChildren<InventoryItemController>();

        
        for (int i = 0; i < items.Count; i++)
        {
            //adds the inventory items to the list
            inventoryItems[i].AddItem(items[i]);
        }
    }

    //unlocks the cursor when called
    public void UnlockCursor()
    {
        //Unlocks the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

   
   /* public void WipeItems()
    {
        foreach (Item item in itemContent)
        {
            //Find the remove button and set it to true
            items.Remove(item);
        }
    }
   */
}
