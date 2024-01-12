using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem 
{
    public ItemData data;
    public int itemCount;

    public InventoryItem(ItemData _data)
    {
        this.data = _data;
        this.itemCount = 1;
    }

}
