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
        public int reloadAmount;
      //  public Item item = ScriptableObject.CreateInstance<Item>();

        public int artifact1, artifact2, artifact3;
        //public List<Item> currentItems = new List<Item>();


        public PlayerData(Health health, Shooting ammo, Currency currency) //, InventoryItemController itemController)
        {
            magSize = ammo.magSize;
            currentAmmo = ammo.fullAmmo;
            playerHealth = health.currentHealth;
            currentCurrency = currency.currentCurrency;
            reloadAmount = ammo.reloadAmount;
            //item = itemController.item;
           // currentItems = inventory.items;
        }
    }
}
