using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    int currentValue;
    int currentDuration;
    Item item;

    public InventoryItem(Item item)
    {
        this.item = item;
        currentDuration = item.GetDuration();
        currentValue = item.GetValue();
    }

    /// <summary>
    /// Returns the weight of the item when stored in the inventory
    /// </summary>
    /// <returns>Item current weight</returns>
    public virtual int GetWeight()
    {
        return item.Weight;
    }

    /// <summary>
    /// Computes the item value depending on the item duration
    /// </summary>
    void UpdateCurrentValue()
    {
        int itemValue = item.GetValue();
        int itemDuration = item.GetDuration();

        // The item has no value or the value is not related with the duration
        if (itemValue < 0 || itemDuration < 0) return;

        currentValue = Mathf.RoundToInt(itemValue * (currentDuration / (float)itemDuration));
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
   
    /// <summary>
    /// Updates the item duration and its value
    /// </summary>
    /// <param name="step">Time increment</param>
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
