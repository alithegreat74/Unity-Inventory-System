using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryObserver 
{
    public void Notify(InventoryNotification notif);
}
