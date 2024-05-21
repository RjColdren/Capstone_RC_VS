using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TowerDefense;

namespace CapstoneFps_RC
{
    [System.Serializable]
    public static class SaveSystem
    {
        //Saves the player to a formatter
       public static void SavePlayer (Health health, Shooting ammo, Currency currency, LevelComplete complete) //, InventoryItemController items) //InventoryItemController itemController)
        {
            //Creates a binary formatter to format the code into binary (so it cannot be editted)
            BinaryFormatter formatter = new BinaryFormatter();
            //creates a path in the players computer to store the data
            string path = Application.persistentDataPath + "/player.Capstone";
            //creates a path with the data
            FileStream stream = new FileStream(path, FileMode.Create);
            //instance of the data with all of the saved data
            PlayerData data = new PlayerData(health, ammo, currency, complete); //, items); //itemController);
            //InventoryData invData = new InventoryData(itemController);

            //puts the data into the stream and serializes it
            formatter.Serialize(stream, data);
            //closes the stream
            stream.Close();
        }
        //loads the player
        public static PlayerData LoadPlayer()
        {
            //checks if there is already a path
            string path = Application.persistentDataPath + "/player.Capstone";
            if (File.Exists(path))
            {
                //creates a new formatter
                BinaryFormatter formatter = new BinaryFormatter();
                //finds the path and opens it
                FileStream stream = new FileStream(path, FileMode.Open);
                //deserializes the stream
                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                //closes the stream
                stream.Close();
                //returns the data
                return data;

            }
            //IF there is no save file, create an error
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }
        }
    }

    
}