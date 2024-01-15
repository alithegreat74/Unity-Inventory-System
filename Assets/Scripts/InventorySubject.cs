using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum InventoryNotification{
    InventoryModified,
    EquipmentModified,
}
public abstract class InventorySubject : MonoBehaviour
{
    private List<IInventoryObserver> _observers= new List<IInventoryObserver>();

    public void AddObserver(IInventoryObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IInventoryObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers(InventoryNotification notif)
    {
        foreach(IInventoryObserver observer in _observers)
        {
            observer?.Notify(notif);
        }
    }
}
