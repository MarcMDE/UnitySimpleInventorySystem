using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveItemsManager : ItemsManager
{
    public bool UseItemByIndex(int index)
    {
        bool isItemUsed = false;

        Item item = GetItemByIndex(index);
        if (item is null) return isItemUsed;

        ItemTypes itemType = item.GetItemType();

        switch (itemType)
        {
            case ItemTypes.CONSUMABLE:
                inventory.RemoveItem(index);
                Debug.Log(item.OnUseMessage());
                isItemUsed = true;
                break;
            case ItemTypes.WEAPON:
                Weapon weapon = item as Weapon;
                if (weapon.IsRanged())
                {
                    Resource ammunition = weapon.GetAmmunition();
                    int ammunitionSlotIndex = inventory.GetItemSlot(ammunition);
                    if (ammunitionSlotIndex > -1)
                    {
                        inventory.RemoveItem(ammunitionSlotIndex);
                        Debug.Log(item.OnUseMessage());
                        isItemUsed = true;
                    }
                    else
                    {
                        Debug.Log($"You do not have any {ammunition.DisplayName} to shoot");
                    }
                }
                else
                {
                    Debug.Log(item.OnUseMessage());
                    isItemUsed = true;
                }
                break;
            default:
                break;
        }

        return isItemUsed;
    }
}
