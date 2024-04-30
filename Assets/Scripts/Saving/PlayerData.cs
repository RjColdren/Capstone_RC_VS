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
        public List<Item> currentItems;

        public PlayerData(Health health, InventoryManager items, Shooting ammo)
        {
            magSize = ammo.magSize;
            currentAmmo = ammo.fullAmmo;
            playerHealth = health.currentHealth;
            currentItems = items.items;
        }
    }
}
