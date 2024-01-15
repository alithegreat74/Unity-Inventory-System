using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Items/Item Data")]
[System.Serializable]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public ItemType itemType;
    public string itemDescription;
}

/*You can configure what kind of data your item is going to hold*/
public enum ItemType
{
    Consumable,
    Equipable
}
