using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemsManager : MonoBehaviour
{
    [SerializeField] 
    protected Inventory inventory;

    protected Item GetItemByIndex(int index)
    {
        Item item = inventory.GetInventoryItemByIndex(index)?.GetItem();
        return item;
    }
}
