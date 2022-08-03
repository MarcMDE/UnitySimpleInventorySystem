using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/HealingConsumable")]
public class HealingConsumable : Consumable
{ 
    [SerializeField]
    int healing;

    public override string OnUseMessage()
    {
        return $"You heal yourself {healing} hp.";
    }
}
