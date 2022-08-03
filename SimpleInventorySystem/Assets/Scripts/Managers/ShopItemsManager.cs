using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemsManager : ItemsManager
{
    /// <summary>
    /// Sells the item (if possible) in the given slot
    /// </summary>
    /// <param name="index">Slot index</param>
    /// <returns>True if the item could be sold, False otherwise</returns>
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
