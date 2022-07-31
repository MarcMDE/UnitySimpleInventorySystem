using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/InventoryItem")]
public class InventoryItem : ScriptableObject
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
    public string Description { get { return description; } }
    public Sprite Icon { get { return icon; } }

}