using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemScriptableObject baseItemData;

    // Different item types
    public enum Type
    {
        None = 0,
        Clothes = 1
    }
}
