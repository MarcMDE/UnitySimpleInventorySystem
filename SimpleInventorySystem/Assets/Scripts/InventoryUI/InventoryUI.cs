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

    void Update()
    {
        
    }

    void UpdateGenericData()
    {
        goldText.text = inventory.Gold.ToString();
        weightText.text = $"{inventory.Weight}/{inventory.MaxWeight}";
    }

    void UpdateSlotData(int i)
    {
        if (i>=0)
        {
            InventoryItem item = inventory.GetInventoryItemByIndex(i);

            if (item == null)
                slotsUI[i].Clear();
            else
            {
                slotsUI[i].SetItem(item);
            }
        }

        UpdateGenericData();
    }
}
