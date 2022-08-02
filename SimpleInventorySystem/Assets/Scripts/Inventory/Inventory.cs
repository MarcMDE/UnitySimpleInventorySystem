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

    int currentWeight = 0;
    int gold = 0;

    // Called every time a slot is updated (paramter = slot index)
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
    public bool AddItem(Item item)
    {
        // Too much weight
        if (currentWeight + item.Weight > maxWeight) return false;

        // Search for the first empty slot
        int i = 0;
        while (i < nSlots && slots[i] != null) i++;

        // Empty slot found
        if (i < nSlots)
        {
            slots[i] = new InventoryItem(item);
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
            currentWeight -= slots[index].GetItem().Weight;
        }

        slots[index] = null;

        slotUpdated.Invoke(index);
    }

    /// <summary>
    /// </summary>
    /// <param name="index">Slot index</param>
    /// <returns>Item stored in the slot with the parameter index</returns>
    public InventoryItem GetItemInSlot(int index)
    {
        return slots[index];
    }

    /// <summary>
    /// Searches for the first slot containing the parameter item
    /// </summary>
    /// <param name="item">Item to find</param>
    /// <returns>Index of the first slot containing the item or -1 otherwise</returns>
    public int GetItemSlot(Item item)
    {
        // Search for the item by Id
        int i = 0;
        while (i < nSlots && slots[i] == null || slots[i].GetItem().Id != item.Id)
            i++;

        // Item found
        if (i < nSlots)
            return i;

        // Item not found
        return -1;
    }

}
