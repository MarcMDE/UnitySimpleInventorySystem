using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    Inventory inventory;

    [SerializeField]
    GameObject inventoryContentUI;

    [SerializeField]
    TextMeshProUGUI goldText, weightText;

    [SerializeField] GameObject slotUIPrefab;

    InventorySlotUI[] slotsUI;

    void Awake()
    {
        for (int i=0; i<inventory.Size; i++)
        {
            GameObject slotUI = Instantiate(slotUIPrefab, inventoryContentUI.transform);
        }

        inventory.slotUpdated += UpdateSlotData;
    }

    void Start()
    {
        slotsUI = inventoryContentUI.GetComponentsInChildren<InventorySlotUI>();
        UpdateGenericData();
    }

    /// <summary>
    /// Updates the inventory gold and weight displayed
    /// </summary>
    void UpdateGenericData()
    {
        goldText.text = inventory.Gold.ToString();
        weightText.text = $"{inventory.Weight}/{inventory.MaxWeight}";
    }

    /// <summary>
    /// Updates the data of a slotUI (weight, duration, value...) and the generic data
    /// </summary>
    /// <param name="index"></param>
    void UpdateSlotData(int index)
    {
        if (index >= 0)
        {
            InventoryItem item = inventory.GetInventoryItemByIndex(index);

            if (item == null)
                slotsUI[index].Clear();
            else
            {
                slotsUI[index].SetItem(item);
            }
        }

        UpdateGenericData();
    }
}
