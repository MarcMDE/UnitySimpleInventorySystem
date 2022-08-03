using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    int currentValue;
    int currentDuration;
    readonly Item item;

    public InventoryItem(Item item)
    {
        this.item = item;
        currentDuration = item.GetDuration();
        currentValue = item.GetValue();
    }

    public virtual int GetWeight()
    {
        return item.Weight;
    }

    void UpdateCurrentValue()
    {
        int itemValue = item.GetValue();
        int itemDuration = item.GetDuration();

        // The item has no value or the value is not related with the duration
        if (itemValue < 0 || itemDuration < 0) return;

        currentValue = (int)(itemValue * currentDuration / (float)itemDuration);
    }

    public int GetCurrentValue()
    {
        return currentValue;
    }
    public int GetCurrentDuration()
    {
        return currentDuration;
    }
    public Item GetItem()
    {
        return item;
    }
   
    public void UpdateCurrentDuration(int step=1)
    {
        // Invalid input
        if (step < 1) return;
        
        // Item has no duration
        if (currentDuration < 0) return;

        // Update duration
        currentDuration -= step;
        if (currentDuration < 0) currentDuration = 0;

        // Update value
        UpdateCurrentValue();
    }
}
