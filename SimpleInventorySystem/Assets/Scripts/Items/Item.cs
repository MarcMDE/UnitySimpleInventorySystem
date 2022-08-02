using UnityEngine;

public enum ItemTypes { RESOURCE, CONSUMABLE, WEAPON, TRASH }

[CreateAssetMenu(menuName = "Items/Item")]
public abstract class Item : ScriptableObject
{
    [SerializeField]
    int id;
    [SerializeField]
    string displayName;
    [SerializeField][TextArea]
    protected string description;
    [SerializeField]
    int weight;
    [SerializeField]
    Sprite icon;

    public int Id { get { return id; } }
    public string DisplayName { get { return displayName; } }
    public int Weight { get { return weight; } }
    public Sprite Icon { get { return icon; } }

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
    public virtual void Use()
    {
        Debug.Log("This item can not be used");
    }
}