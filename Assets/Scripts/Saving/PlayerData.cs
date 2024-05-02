using CapstoneFps_RC;
using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;

namespace CapstoneFps_RC
{
    [System.Serializable]
    public class PlayerData
    {
        public int magSize;
        public int currentAmmo;
        public int playerHealth;
        public int currentCurrency;
        //public List<Item> currentItems = new List<Item>();


        public PlayerData(Health health, Shooting ammo, Currency currency) //InventoryManager inventory)
        {
            magSize = ammo.magSize;
            currentAmmo = ammo.fullAmmo;
            playerHealth = health.currentHealth;
            currentCurrency = currency.currentCurrency;
           // currentItems = inventory.items;
        }
    }
}
