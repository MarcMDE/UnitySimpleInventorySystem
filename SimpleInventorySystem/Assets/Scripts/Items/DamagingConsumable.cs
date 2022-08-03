using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/DamagingConsumable")]
public class DamagingConsumable : Consumable
{
    [SerializeField]
    int damage;

    public override string OnUseMessage()
    {
        return $"You deal {damage} damage points.";
    }
}