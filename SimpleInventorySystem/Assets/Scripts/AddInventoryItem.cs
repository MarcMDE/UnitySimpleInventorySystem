using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddInventoryItem : MonoBehaviour
{
    [SerializeField]
    Inventory inventory;
    [SerializeField]
    InventoryItem item;
    
    public void Add()
    {
        if (!inventory.AddItem(item))
        {
            print($"The item '{item.DisplayName}' could not be added to the inventory.");
        }
    }

}
