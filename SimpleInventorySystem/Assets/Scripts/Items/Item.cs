using UnityEngine;

public enum ItemTypes { RESOURCE, CONSUMABLE, WEAPON, TRASH, UNDEFINED }

[CreateAssetMenu(menuName = "Items/Item")]
public abstract class Item : ScriptableObject
{
    [SerializeField]
    int id = -1;
    [SerializeField]
    string displayName = string.Empty;
    [SerializeField][TextArea]
    protected string description = string.Empty;
    [SerializeField]
    protected int weight = 0;
    [SerializeField]
    Sprite icon = null;

    public int Id { get { return id; } }
    public string DisplayName { get { return displayName; } }
    public int Weight { get { return weight; } }
    public Sprite Icon { get { return icon; } }

    public virtual ItemTypes GetItemType()
    {
        return ItemTypes.UNDEFINED;
    }
    public virtual string GetFullDescription()
    {
        return description;
    }
    public virtual int GetValue()
    {
        return -1;
    }
    public virtual int GetDuration()
    {
        return -1;
    }
    public virtual string OnUseMessage()
    {
        return "This item can not be used";
    }
}