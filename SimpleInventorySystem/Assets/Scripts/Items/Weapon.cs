using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon")]
public class Weapon : Item
{
    [SerializeField]
    int dps;
    [SerializeField]
    int value;
    [SerializeField][TextArea]
    string attackDescription;
    [SerializeField]
    bool ranged = false;
    [SerializeField]
    Item ammunition = null;

    string fullDescription = string.Empty;

    public override string GetFullDescription()
    {
        if (fullDescription == string.Empty)
        {
            fullDescription = $"{description}. It has a dps of {dps}.";
        
            if (ranged)
            {
                fullDescription += $"It requires a {ammunition.DisplayName} to be shoot.";
            }
        }

        return fullDescription;
    }

    public override int GetValue()
    {
        return value;
    }

    public override void Use()
    {
        Debug.Log($"{attackDescription}, dealing {dps} dps.");
    }

    public int GetDPS()
    {
        return dps;
    }
}