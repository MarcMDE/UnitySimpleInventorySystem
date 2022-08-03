using UnityEngine;

[CreateAssetMenu(menuName = "Items/Consumable")]
public abstract class Consumable : Item
{
    [SerializeField]
    int duration;

    public override ItemTypes GetItemType()
    {
        return ItemTypes.CONSUMABLE;
    }

    public override int GetDuration()
    {
        return duration;
    }
}