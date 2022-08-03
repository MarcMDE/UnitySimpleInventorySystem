using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [SerializeField][Tooltip("Number of slots")]
    int nSlots = 5;
    [SerializeField]
    int maxWeight = 20;

    [SerializeField] Trash trash;

    InventoryItem[] slots;

    // A dictionary could be used to additionaly store the amount of items of each type present in the inventory.
    // It has not been implemented due to the time restrictions and the poor improvements it offers given
    // the project requirements (The only useful case would be when trying to find the ranged weapons ammunition)
    //Dictionary<int, int> itemsAmount;
    //Dictionary<Item, int> itemsAmount;


    int currentWeight = 0;
    int gold = 0;

    public int Gold { get { return gold; } }
    public int Weight { get { return currentWeight; } }
    public int MaxWeight { get { return maxWeight; } }
    public int Size { get { return nSlots; } }

    // Called every time a slot is updated (paramter = slot index)
    public event Action<int> slotUpdated;

    void Awake()
    {
        slots = new InventoryItem[nSlots];

        ClearSlots();
    }

    /// <summary>
    /// Sets every slot to null (empty)
    /// </summary>
    void ClearSlots()
    {
        for (int i = 0; i < nSlots; i++)
        {
            slots[i] = null;
        }
    }

    /// <summary>
    /// Replaces a item by a trash item with the same weight
    /// </summary>
    /// <param name="index">Slot index</param>
    void ReplaceItemByTrash(int index)
    {
        if (slots[index] is null) return;

        int itemWeight = slots[index].GetWeight();

        RemoveItem(index);
        currentWeight += itemWeight;

        slots[index] = new TrashInventoryItem(itemWeight, trash);

        slotUpdated.Invoke(index);
    }

    /// <summary>
    /// Adds an item to the inventory
    /// </summary>
    /// <param name="item">Item to be added</param>
    /// <returns>Returns true if the item could be added and false otherwise</returns>
    public bool AddItem(Item item)
    {
        // Trash can not be added
        if (item.GetItemType() == ItemTypes.TRASH) return false;
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
    public void RemoveItem(int index)
    {
        if (slots[index] != null)
        {
            // Subtract item weight
            currentWeight -= slots[index].GetWeight();
        }

        slots[index] = null;

        slotUpdated.Invoke(index);
    }

    /// <summary>
    /// </summary>
    /// <param name="index">Slot index</param>
    /// <returns>Item stored in the slot with the parameter index</returns>
    public InventoryItem GetInventoryItemByIndex(int index)
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
        while (i < nSlots && (slots[i] == null || slots[i].GetItem().Id != item.Id))
            i++;

        // Item found
        if (i < nSlots)
            return i;

        // Item not found
        return -1;
    }

    /// <summary>
    /// Adds gold to the inventory
    /// </summary>
    /// <param name="gold">Gold ammount</param>
    public void AddGold(int gold)
    {
        if (gold < 0) return;
        this.gold += gold;

        slotUpdated.Invoke(-1);
    }

    /// <summary>
    /// Subtracts gold to the inventory
    /// </summary>
    /// <param name="gold">Gold ammount</param>
    public void SubtractGold(int gold)
    {
        if (gold < 0) return;

        this.gold -= gold;
        if (this.gold < 0) this.gold = 0;

        slotUpdated.Invoke(-1);
    }

    /// <summary>
    /// Called every time the game time changes. Updates the duration of the inventory items
    /// </summary>
    /// <param name="t">Amount of time change</param>
    public void OnTimeChange(int t)
    {
        for (int i=0; i<nSlots; i++)
        {
            if (slots[i] != null)
            {
                slots[i].UpdateCurrentDuration(t);
                if (slots[i].GetCurrentDuration()==0)
                {
                    ReplaceItemByTrash(i);
                }
                slotUpdated.Invoke(i);
            }
        }
    }

}
