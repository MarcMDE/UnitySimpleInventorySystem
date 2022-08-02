using UnityEngine;

[CreateAssetMenu(menuName = "Items/Consumable")]
public class Consumable : Item
{
    [SerializeField]
    int duration;
}