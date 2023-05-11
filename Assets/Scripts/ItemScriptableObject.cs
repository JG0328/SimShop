using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemScriptableObject : ScriptableObject
{
    public int itemId;
    public string itemName = "Default Item Name";
    public string itemDescription = "Default Item Description";
    public Sprite itemIcon;
    public int buyPrice = 0;
    public int sellPrice = 0;
    public Item.Type itemType = Item.Type.None;
}
