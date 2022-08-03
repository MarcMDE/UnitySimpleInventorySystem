using UnityEngine;

[CreateAssetMenu(menuName = "Items/Resource")]
public class Resource : Item
{
    [SerializeField]
    int duration;
    [SerializeField]
    int value;

    public override ItemTypes GetItemType()
    {
        return ItemTypes.RESOURCE;
    }

    public override int GetDuration()
    {
        return duration;
    }

    public override int GetValue()
    {
        return value;
    }
}