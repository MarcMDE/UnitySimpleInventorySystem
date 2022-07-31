using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryContentUI;

    InventoryItem[] slots;
    InventorySlotUI[] slotsUI;

    void Awake()
    {
        slotsUI = inventoryContentUI.GetComponentsInChildren<InventorySlotUI>();
        slots = new InventoryItem[slotsUI.Length];

        ClearSlots();

        print(slots.Length);
    }

    void ClearSlots()
    {
        for (int i=0; i<slots.Length; i++)
        {
            slots[i] = null;
        }
    }

    public void AddItem(InventoryItem item)
    {
        int i = 0;

        // Search for the first empty slot
        while (i < slots.Length && slots[i] != null) i++;

        // Empty slot found
        if (i < slots.Length)
        {
            slots[i] = item;
            slotsUI[i].SetNewItem(slots[i].Icon, 5);
            //return true;
        }

        // No empty slot found
        //return false;
    }

    public void AddItem(InventoryItem item, int n=1)
    {

    }

    public void DropItem(int index)
    {

    }

    public void RemoveItem(InventoryItem item, int n = 1)
    {

    }
}
