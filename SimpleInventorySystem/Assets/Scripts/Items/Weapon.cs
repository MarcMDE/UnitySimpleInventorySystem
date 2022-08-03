using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon")]
public class Weapon : Item
{
    [SerializeField]
    int dps = 0;
    [SerializeField]
    int value = 0;
    [SerializeField][TextArea]
    string attackDescription = string.Empty;
    [SerializeField]
    bool ranged = false;
    [SerializeField]
    Resource ammunition = null;

    string fullDescription = string.Empty;

    public override string GetFullDescription()
    {
        if (fullDescription == string.Empty)
        {
            fullDescription = $"{description}. It has a dps of {dps}.";
        
            if (ranged)
            {
                fullDescription += $" It requires a {ammunition.DisplayName} to be shot.";
            }
        }

        return fullDescription;
    }

    public override ItemTypes GetItemType()
    {
        return ItemTypes.WEAPON;
    }

    public override int GetValue()
    {
        return value;
    }

    public override string OnUseMessage()
    {
        return $"{attackDescription}, dealing {dps} dps.";
    }

    public int GetDPS()
    {
        return dps;
    }

    public bool IsRanged()
    {
        return ranged;
    }

    public Resource GetAmmunition()
    {
        return ammunition;
    }
}