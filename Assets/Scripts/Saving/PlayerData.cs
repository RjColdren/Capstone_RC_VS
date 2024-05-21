using TowerDefense;


namespace CapstoneFps_RC
{
    [System.Serializable]
    public class PlayerData
    {
        //Variables
        public int magSize;
        public int currentAmmo;
        public int playerHealth;
        public int currentCurrency;
        public int reloadAmount;
        public bool level1;
        public bool level2;
        public int artifact1, artifact2, artifact3;

        //creates a save for the data
        public PlayerData(Health health, Shooting ammo, Currency currency, LevelComplete complete) //, InventoryItemController itemController)
        {
            //Saves all of the data
            magSize = ammo.magSize;
            currentAmmo = ammo.fullAmmo;
            playerHealth = health.currentHealth;
            currentCurrency = currency.currentCurrency;
            reloadAmount = ammo.reloadAmount;
            complete.level1Complete = level1;
            complete.level2Complete = level2;
            //item = itemController.item;
           // currentItems = inventory.items;
        }
    }
}
