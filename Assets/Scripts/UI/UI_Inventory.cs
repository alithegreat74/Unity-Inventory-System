using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

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
        if (_slots.Length>0)
        {
           EventSystem.current.SetSelectedGameObject(_slots[0].gameObject);
        }
        //SetButtons();
    }

    //private void SetButtons()
    //{
    //    if (_slots.Length>0)
    //        _eventSystem.firstSelectedGameObject= _slots[0].gameObject;

        

    //    for (int i =0;i<_slots.Length;i++)
    //    {
            
    //        var navigation = _slots[i].GetComponent<Button>().navigation;
    //        UI_ItemSlot left = i-1>=0 ? _slots[i-1] : null;
    //        UI_ItemSlot right= (i+1)%6!=5 && i+1<_slots.Length ? _slots[i+1] : null;
    //        UI_ItemSlot down = i+6<_slots.Length ? _slots[i+6]:null;
    //        UI_ItemSlot up = i-6>=0 ? _slots[i-6] : null;

    //        navigation.selectOnLeft=left?.GetComponent<Selectable>();
    //        navigation.selectOnRight=right?.GetComponent<Selectable>();
    //        navigation.selectOnDown=down?.GetComponent<Selectable>();
    //        navigation.selectOnUp=up?.GetComponent<Selectable>();
    //    }
    //}
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
