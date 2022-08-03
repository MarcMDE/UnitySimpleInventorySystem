using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemsManager : ItemsManager
{
    public bool SellItemByIndex(int index)
    {
        Item item = GetItemByIndex(index);
        if (item is null) return false;

        ItemTypes itemType = item.GetItemType();
        if (itemType == ItemTypes.RESOURCE || itemType == ItemTypes.WEAPON)
        {
            inventory.RemoveItem(index);
            inventory.AddGold(item.GetValue());
            return true;
        }

        return false;
    }
}
