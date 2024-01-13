using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryEquipment
{
    public ItemData itemData;
    public InventoryEquipment(ItemData itemData)
    {
        this.itemData = itemData;
    }
}
