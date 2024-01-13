using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class UI_Inventory : MonoBehaviour,IInventoryObserver
{
    [Header("Game Objects")]
    [SerializeField] private GameObject _itemSlotPrefab;
    [SerializeField] private GameObject _slotsGrid;
    private UI_ItemSlot[] _slots;
    private UI_EquipmentSlot[] _equipmentSlots;
    
    private void OnEnable()
    {
        InventoryManager.instance.AddObserver(this);
        _slots=GetComponentsInChildren<UI_ItemSlot>();
        _equipmentSlots=GetComponentsInChildren<UI_EquipmentSlot>();
        LoadItems();
    }
    private void LoadItems()
    {
        List<InventoryItem> items = InventoryManager.instance.inventoryItems;
        while(_slots.Length > items.Count) 
        {
            Destroy(_slots[_slots.Length-1].gameObject);
            Array.Resize(ref _slots,_slots.Length-1);
        }

        for (int i = 0; i<items.Count; i++)
        {
            if (_slots.Length==i)
            {
                GameObject newGameObject = Instantiate(_itemSlotPrefab, _slotsGrid.transform);
                Array.Resize(ref _slots, i+1);
                _slots[i]=newGameObject.GetComponent<UI_ItemSlot>();
            }
            _slots[i].gameObject.SetActive(true);
            _slots[i].Initialize(items[i]);

        }
    }

    private void OnDisable()
    {
        InventoryManager.instance.RemoveObserver(this);
        foreach(UI_ItemSlot slot in _slots)
        {
            slot.gameObject.SetActive(false);
        }
    }

    public void Notify(InventoryNotification notif)
    {
        if(notif==InventoryNotification.InventoryModified)
            LoadItems();
        else
            LoadEquipments();
        
    }

    private void LoadEquipments()
    {
        List<InventoryEquipment> list = InventoryManager.instance.inventoryEquipments;
        for (int i = 0; i<_equipmentSlots.Length; i++)
        {
            if (list.Count>i)
                _equipmentSlots[i].GetComponent<UI_EquipmentSlot>().SetInfo(list[i].itemData);
            else
                _equipmentSlots[i].GetComponent<UI_EquipmentSlot>().SetInfo(null);
        }
    }
}
