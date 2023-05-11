using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int coins = 1000000;

    public GameObject inventoryObj;

    public Item equippedItem;

    public List<Item> items = new();

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
}
