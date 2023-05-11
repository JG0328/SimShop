using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int coins = 1000000;

    public GameObject inventoryObj;

    public Transform itemsContainer;

    public ItemButton equipButton;

    public int equippedItem;

    public List<int> items = new();

    public List<ItemButton> equipButtons = new();

    public static Inventory Instance;

    public bool isOpen = false;

    private void Awake()
    {
        Instance = this;

        // Make sure the Inventory starts closed
        inventoryObj.SetActive(false);
    }

    public void OpenInventory()
    {
        PlayerController.Instance.canMove = false;

        UpdateInventory();

        inventoryObj.SetActive(true);
        isOpen = true;
    }

    public void CloseInventory()
    {
        PlayerController.Instance.canMove = true;
        inventoryObj.SetActive(false);
        isOpen = false;
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

    public void EquipItem(int itemId)
    {
        equippedItem = itemId;
        UpdateInventory();
        PlayerController.Instance.UpdateClothes();
    }

    public void UnequipItem()
    {
        equippedItem = 0;
        UpdateInventory();
        PlayerController.Instance.UpdateClothes();
    }

    public void UpdateInventory()
    {
        foreach (ItemButton button in equipButtons)
        {
            Destroy(button.gameObject);
        }

        equipButtons.Clear();

        IEnumerable<ItemScriptableObject> itemData = ShopManager.Instance.items.Where(i => items.Contains(i.itemId)).OrderBy(i => i.itemId);
        foreach (ItemScriptableObject item in itemData)
        {
            ItemButton button = Instantiate(equipButton, itemsContainer);
            button.SetupEquipButton(item);
            equipButtons.Add(button);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
