using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/InventoryResource")]
public class InventoryResource : InventoryItem
{
    [SerializeField]
    int duration;
    [SerializeField]
    int value;

    int currentValue;
    int currentDuration;

}