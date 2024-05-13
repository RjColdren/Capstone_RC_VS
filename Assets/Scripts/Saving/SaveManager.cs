using CapstoneFps_RC;
using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public Health health;
   // public InventoryItemController itemController;
    public Shooting shooting;
    public Currency currency;
    public LevelComplete levelComplete;
   // public InventoryItemController itemController;
    private void Start()
    {
        LoadAll();
    }

    public void SaveAll()
    {
        SaveSystem.SavePlayer(health, shooting, currency, levelComplete); //, itemController);
    }

    public void LoadAll()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        health.currentHealth = data.playerHealth;
       // itemController.AddItem(data.item);
        shooting.magSize = data.magSize;
        shooting.fullAmmo = data.currentAmmo;
        currency.currentCurrency = data.currentCurrency;
        shooting.reloadAmount = data.reloadAmount;
        levelComplete.level1Complete = data.level1;
        levelComplete.level2Complete = data.level2;


        ValueDisplay.OnValueChanged.Invoke("fullAmmo", shooting.fullAmmo);
        ValueDisplay.OnValueChanged.Invoke("MagAmmo", shooting.magSize + "/");
        ValueDisplay.OnValueChanged.Invoke("PlayerHealth", health.currentHealth);
        ValueDisplay.OnValueChanged.Invoke("PlayerCurrency", "$" + currency.currentCurrency);

    }
}
