using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] 
    GameObject inventoryContentUI;
    [SerializeField] 
    int maxWeight = 20;

    InventoryItem[] slots;
    InventorySlotUI[] slotsUI;

    int currentWeight = 0;

    void Awake()
    {
        slotsUI = inventoryContentUI.GetComponentsInChildren<InventorySlotUI>();
        slots = new InventoryItem[slotsUI.Length];

        ClearSlots();
    }

    void ClearSlots()
    {
        for (int i=0; i<slots.Length; i++)
        {
            slots[i] = null;
        }
    }

    public bool AddItem(InventoryItem item)
    {
        // Too much weight
        if (currentWeight + item.Weight > maxWeight) return false;

        // Search for the first empty slot
        int i = 0;
        while (i < slots.Length && slots[i] != null) i++;

        // Empty slot found
        if (i < slots.Length)
        {
            slots[i] = item;
            slotsUI[i].SetNewItem(slots[i].Icon, 5);
            return true;
        }

        // No empty slot found
        return false;
    }


    public void DropItem(int index)
    {

    }

    public void RemoveItem(InventoryItem item, int n = 1)
    {

    }
}
