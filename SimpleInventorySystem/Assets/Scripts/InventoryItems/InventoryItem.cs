using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/InventoryItem")]
public abstract class InventoryItem : ScriptableObject
{
    [SerializeField]
    int id;
    [SerializeField]
    string displayName;
    [SerializeField][TextArea]
    string description;
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
    public virtual void UpdateDuration()
    {

    }
    public virtual void Use()
    {

    }

}