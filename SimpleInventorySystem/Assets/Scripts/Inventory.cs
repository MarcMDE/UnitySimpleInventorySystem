using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    int nSlots = 5;
    [SerializeField]
    int maxWeight = 20;

    InventoryItem[] slots;
    InventorySlotUI[] slotsUI;

    int currentWeight = 0;

    public event Action<int> slotUpdated;

    void Awake()
    {
        slots = new InventoryItem[nSlots];

        ClearSlots();
    }

    void ClearSlots()
    {
        for (int i = 0; i < nSlots; i++)
        {
            slots[i] = null;
        }
    }

    /// <summary>
    /// Adds an item to the inventory
    /// </summary>
    /// <param name="item">Item to be added</param>
    /// <returns>Returns true if the item could be added and false otherwise</returns>
    public bool AddItem(InventoryItem item)
    {
        // Too much weight
        if (currentWeight + item.Weight > maxWeight) return false;

        // Search for the first empty slot
        int i = 0;
        while (i < nSlots && slots[i] != null) i++;

        // Empty slot found
        if (i < nSlots)
        {
            slots[i] = item;
            currentWeight += item.Weight;

            slotUpdated.Invoke(i);

            return true;
        }

        // No empty slot found
        return false;
    }

    /// <summary>
    /// Removes an item from a inventory slot
    /// </summary>
    /// <param name="index">Slot index</param>
    public void DropItem(int index)
    {
        if (slots[index] != null)
        {
            currentWeight -= slots[index].Weight;
        }

        slots[index] = null;

        slotUpdated.Invoke(index);
    }

    public InventoryItem GetItemInSlot(int index)
    {
        return slots[index];
    }

}
