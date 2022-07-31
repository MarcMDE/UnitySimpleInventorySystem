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
        inventory.AddItem(item);
    }

}
