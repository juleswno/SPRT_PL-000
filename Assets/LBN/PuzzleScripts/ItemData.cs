using UnityEngine;

public enum ItemType
{
    None,
    Cube,
    Sphere
}

public class ItemData : MonoBehaviour
{
    public ItemType itemType;
}
