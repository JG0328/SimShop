using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int coins = 1000000;

    public GameObject inventoryObj;

    public int equippedItem;

    public List<int> items = new();

    public static Inventory Instance;

    private void Awake()
    {
        Instance = this;

        // Make sure the Inventory starts closed
        inventoryObj.SetActive(false);
    }

    public void OpenInventory()
    {
        PlayerController.Instance.canMove = false;
        inventoryObj.SetActive(true);
    }

    public void CloseInventory()
    {
        PlayerController.Instance.canMove = true;
        inventoryObj.SetActive(false);
    }

    public void AddItem(ItemScriptableObject item)
    {
        items.Add(item.itemId);
        coins -= item.buyPrice;
    }

    public void RemoveItem(ItemScriptableObject item)
    {
        items.Remove(item.itemId);
        coins += item.sellPrice;
    }
}
