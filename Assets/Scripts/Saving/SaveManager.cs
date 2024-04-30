using CapstoneFps_RC;
using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public Health health;
    public InventoryManager inventoryManager;
    public Shooting shooting;

    public void SaveAll()
    {
        SaveSystem.SavePlayer(health.currentHealth, inventoryManager.items, shooting.magSize);
    }

    public void LoadAll()
    {
        PlayerData data = SaveSystem.LoadPlayer();


    }
}
