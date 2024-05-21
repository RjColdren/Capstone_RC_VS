using CapstoneFps_RC;
using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    //Script references
    public Health health;
    public Shooting shooting;
    public Currency currency;
    public LevelComplete levelComplete;
    private void Start()
    {
        //calls LoadAll
        LoadAll();
    }

    //saves all data
    public void SaveAll()
    {
        SaveSystem.SavePlayer(health, shooting, currency, levelComplete); //, itemController);
    }

    //loads all of the players data
    public void LoadAll()
    {
        //Loads the player
        PlayerData data = SaveSystem.LoadPlayer();
        //sets each variable to the saved data "Loading" it
        health.currentHealth = data.playerHealth;
        shooting.magSize = data.magSize;
        shooting.fullAmmo = data.currentAmmo;
        currency.currentCurrency = data.currentCurrency;
        shooting.reloadAmount = data.reloadAmount;
        levelComplete.level1Complete = data.level1;
        levelComplete.level2Complete = data.level2;

        //Changes the Value on valuedisplay
        ValueDisplay.OnValueChanged.Invoke("fullAmmo", shooting.fullAmmo);
        ValueDisplay.OnValueChanged.Invoke("MagAmmo", shooting.magSize + "/");
        ValueDisplay.OnValueChanged.Invoke("PlayerHealth", health.currentHealth);
        ValueDisplay.OnValueChanged.Invoke("PlayerCurrency", "$" + currency.currentCurrency);

    }
}
