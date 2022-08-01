using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    Inventory inventory;

    [SerializeField]
    GameObject inventoryContent;

    InventorySlotUI[] slotsUI;

    void Awake()
    {
        slotsUI = inventoryContent.GetComponentsInChildren<InventorySlotUI>();
        inventory.slotUpdated += UpdateSlotData;
    }

    void Update()
    {
        
    }

    void UpdateSlotData(int i)
    {
        InventoryItem item = inventory.GetItemInSlot(i);

        if (item == null)
            slotsUI[i].Clear();
        else
        {
            slotsUI[i].SetItem(item);
        }
    }
}
