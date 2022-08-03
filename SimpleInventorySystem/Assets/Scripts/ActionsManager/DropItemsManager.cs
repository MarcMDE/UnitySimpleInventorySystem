using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemsManager : ItemsManager
{
    public bool DropItemByIndex(int index)
    {
        Item item = GetItemByIndex(index);
        if (item is null) return false;

        inventory.RemoveItem(index);
        return true;
    }
}
