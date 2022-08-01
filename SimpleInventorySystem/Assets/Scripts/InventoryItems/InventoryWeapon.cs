using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/InventoryWeapon")]
public class InventoryWeapon : InventoryItem
{
    [SerializeField]
    int dps;
    [SerializeField]
    int value;
    [SerializeField]
    bool ranged = false;
    [SerializeField]
    int ammunitionId = -1;

   

}