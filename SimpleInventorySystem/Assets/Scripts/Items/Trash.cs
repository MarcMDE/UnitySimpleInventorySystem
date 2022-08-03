using UnityEngine;

[CreateAssetMenu(menuName = "Items/Trash")]
public class Trash : Item
{
    public override ItemTypes GetItemType()
    {
        return ItemTypes.TRASH;
    }
}