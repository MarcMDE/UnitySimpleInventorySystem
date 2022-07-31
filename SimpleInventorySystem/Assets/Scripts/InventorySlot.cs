using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot
{
    int amount;
    InventoryItem item;

    public void DropItem()
    {
        item = null;
        amount = 0;
    }

    public void SetItem(InventoryItem item)
    {
        this.item = item;
        amount = 1;
    }

    public void Increase()
    {
        
        amount += 1;
    }

}
