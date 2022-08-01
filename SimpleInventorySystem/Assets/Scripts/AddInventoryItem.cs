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
        InventoryItem itemInstance = Instantiate(item);

        if (!inventory.AddItem(itemInstance))
        {
            print($"The item '{itemInstance.DisplayName}' could not be added to the inventory.");
        }
    }

}
