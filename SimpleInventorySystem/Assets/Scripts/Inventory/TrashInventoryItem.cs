using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashInventoryItem : InventoryItem
{
    int weight;

    public TrashInventoryItem(int weight, Item item) : base(item)
    {
        this.weight = weight;
    }

    public override int GetWeight()
    {
        return weight;
    }

}
