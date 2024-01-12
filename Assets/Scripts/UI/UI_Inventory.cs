using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private GameObject _itemSlotPrefab;
    [SerializeField] private GameObject _slotsGrid;
    private UI_ItemSlot[] _slots;
    
    private void OnEnable()
    {
       _slots=GetComponentsInChildren<UI_ItemSlot>();
       List<InventoryItem> items=InventoryManager.instance.inventoryItems;

        for(int i = 0; i<items.Count; i++)
        {
            if (_slots.Length==i)
            {
                GameObject newGameObject=Instantiate(_itemSlotPrefab,_slotsGrid.transform);
                Array.Resize(ref _slots, i+1);
                _slots[i]=newGameObject.GetComponent<UI_ItemSlot>();
            }
            _slots[i].gameObject.SetActive(true);
            _slots[i].Initialize(items[i]);

        }
    }
    private void OnDisable()
    {
        foreach(UI_ItemSlot slot in _slots)
        {
            slot.gameObject.SetActive(false);
        }
    }

}
