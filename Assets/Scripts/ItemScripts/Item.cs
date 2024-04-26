using UnityEngine;


//Creates an asset menu/Scriptable Object for Items
[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    //variables and Sprite.
    public int id;
    public string itemName;
    public int value;
    public int costValue;
    public Sprite icon;
    public ItemType itemType;

    //Creates a list of different ItemTypes.
        public enum ItemType
    {
        HealthPotion,
        Artifact,
        AmmoCrate
    }
}
