using CapstoneFps_RC;
using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public Health health;
    //public InventoryManager inventoryManager;
    public Shooting shooting;

    public void SaveAll()
    {
        SaveSystem.SavePlayer(health, shooting); // inventoryManager);
    }

    public void LoadAll()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        health.currentHealth = data.playerHealth;
       // inventoryManager.items = data.currentItems;
        shooting.magSize = data.magSize;
        shooting.fullAmmo = data.currentAmmo;

        ValueDisplay.OnValueChanged.Invoke("fullAmmo", shooting.fullAmmo);
        ValueDisplay.OnValueChanged.Invoke("MagAmmo", shooting.magSize + "/");
        ValueDisplay.OnValueChanged.Invoke("PlayerHealth", health.currentHealth);

    }
}
