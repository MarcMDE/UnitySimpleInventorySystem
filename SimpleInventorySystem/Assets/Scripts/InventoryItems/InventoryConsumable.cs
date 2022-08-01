using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/InventoryConsumable")]
public class InventoryConsumable : InventoryItem
{
    [SerializeField]
    int duration;

    int currentDuration;

}