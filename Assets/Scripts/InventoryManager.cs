using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : InventorySubject
{
    #region Singleton
    // Making this class a singleton so it can be accessible from any point in the game
    public static InventoryManager instance;

    private void Awake()
    {
        if(instance!=null)
            Destroy(instance.gameObject);
        else
            instance= this;
    }
    #endregion
    [SerializeField] private ItemData _data;
    public List<InventoryItem> inventoryItems=new List<InventoryItem>();
    public Dictionary<ItemData,InventoryItem> inventoryItemsDictionary= new Dictionary<ItemData,InventoryItem>();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
            AddItem(_data);
        if (Input.GetKeyDown(KeyCode.Y))
            RemoveItem(_data);
    }

    //You can add new Items with this function
    public void AddItem(ItemData itemData)
    {
        if(inventoryItemsDictionary.TryGetValue(itemData, out var item))
        {
            item.itemCount++;
        }
        else
        {
            InventoryItem newItem=new InventoryItem(itemData);
            inventoryItems.Add(newItem);
            inventoryItemsDictionary.Add(itemData, newItem);
        }
        NotifyObservers();
    }

    public void RemoveItem(ItemData itemData)
    {
        if(inventoryItemsDictionary.TryGetValue(itemData,out var item))
        {
            if(item.itemCount>1)
                item.itemCount--;
            else
            {
                inventoryItems.Remove(item);
                inventoryItemsDictionary.Remove(itemData);
            }
            NotifyObservers();
        }
        else
        {
            Debug.LogWarning("This Item doesn't exist");
        }
    }

}
