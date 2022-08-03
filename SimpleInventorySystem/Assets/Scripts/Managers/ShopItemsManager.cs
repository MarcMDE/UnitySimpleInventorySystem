using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemsManager : ItemsManager
{
    public bool SellItemByIndex(int index)
    {
        InventoryItem invItem = inventory.GetInventoryItemByIndex(index);
        if (invItem is null) return false;

        ItemTypes itemType = invItem.GetItem().GetItemType();
        if (itemType == ItemTypes.RESOURCE || itemType == ItemTypes.WEAPON)
        {
            inventory.RemoveItem(index);
            inventory.AddGold(invItem.GetCurrentValue());
            return true;
        }

        return false;
    }
}
