using System.ComponentModel;
using UnityEngine;


//Creates an asset menu/Scriptable Object for Items
[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    //variables and Sprite.
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;
    public ItemType itemType;

        public enum ItemType
    {
        HealthPotion,
        Artifact,
        AmmoCrate
    }
}
