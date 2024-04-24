 using CapstoneFps_RC;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Code created by SoloGameDev, edited by me. Link: https://www.youtube.com/watch?v=AoD_F1fSFFg


public class Chest : MonoBehaviour
{
}
    /*public static Chest Instance;
    public List<Item> items = new List<Item>();

    public Transform itemContent;
    public GameObject chestItem;



    public ChestItemController[] chestItems;

    public GameObject chestUI;

    public Shooting shooting;

    public Button chestButton;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        shooting = FindObjectOfType<Shooting>();
    }
    private void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.X))
        {
            chestUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            shooting.enabled = true;
        }
    }
    public void Add(Item item)
    {
        items.Add(item);

    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            GameObject obj = Instantiate(chestItem, itemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

        }

        SetChestItems();
    }

 

    public void SetChestItems()
    {

       chestItems = itemContent.GetComponentsInChildren<ChestItemController>();

        for (int i = 0; i < items.Count; i++)
        {
            chestItems[i].AddItem(items[i]);
        }
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenChest()
    {
        chestUI.SetActive(true);
        ListItems();

        Cursor.lockState = CursorLockMode.None;
        shooting.enabled = false;
    }

    // public void MoveItems()
    //{
       
   // }
}


*/