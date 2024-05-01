using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TowerDefense;

namespace CapstoneFps_RC
{
    public static class SaveSystem
    {
       public static void SavePlayer (Health health, Shooting ammo) //InventoryManager inventory)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/player.Capstone";
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData(health, ammo); //inventory);

            formatter.Serialize(stream, data);
            stream.Close();
        }
        public static PlayerData LoadPlayer()
        {
            string path = Application.persistentDataPath + "/player.Capstone";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                stream.Close();

                return data;

            }
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }
        }
    }

    
}