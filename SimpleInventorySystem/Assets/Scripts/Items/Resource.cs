using UnityEngine;

[CreateAssetMenu(menuName = "Items/Resource")]
public class Resource : Item
{
    [SerializeField]
    int duration;
    [SerializeField]
    int value;
}