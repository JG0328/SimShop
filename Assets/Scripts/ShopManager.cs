using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shopObj;

    // These include all the items
    public List<ItemScriptableObject> items = new();

    public ItemButton buyButton;

    public ItemButton sellButton;

    public List<ItemButton> buyButtons = new();

    public List<ItemButton> sellButtons = new();

    public TMP_Text txtCoins;

    public GameObject shopItemsContainer;

    public GameObject inventoryItemsContainer;

    public static ShopManager Instance;

    private void Awake()
    {
        Instance = this;

        // Make sure the shop starts closed
        shopObj.SetActive(false);
    }

    private void Start()
    {
        UpdateShop();
    }

    public void UpdateShop()
    {
        foreach (ItemButton button in buyButtons)
        {
            Destroy(button.gameObject);
        }

        buyButtons.Clear();

        // Our available items will be the ones that have not beeen bought yet
        IEnumerable<int> playerItemsIds = Inventory.Instance.items.Select(i => i);

        foreach (ItemScriptableObject item in items.Where(i => !playerItemsIds.Contains(i.itemId)))
        {
            ItemButton button = Instantiate(buyButton, shopItemsContainer.transform);
            button.SetupBuyButton(item);
            buyButtons.Add(button);
        }

        // Inventory items

        foreach (ItemButton button in sellButtons)
        {
            Destroy(button.gameObject);
        }

        sellButtons.Clear();

        IEnumerable<ItemScriptableObject> playerItems = items.Where(i => playerItemsIds.Contains(i.itemId)).OrderBy(i => i.itemId);

        foreach (ItemScriptableObject item in playerItems)
        {
            ItemButton button = Instantiate(sellButton, inventoryItemsContainer.transform);
            button.SetupSellButton(item);
            sellButtons.Add(button);
        }

        txtCoins.SetText($"Coins: {Inventory.Instance.coins}");
    }

    public void OpenShop()
    {
        PlayerController.Instance.canMove = false;
        shopObj.SetActive(true);
    }

    public void CloseShop()
    {
        PlayerController.Instance.canMove = true;
        shopObj.SetActive(false);
    }

    public void BuyItem(ItemScriptableObject item)
    {
        Inventory.Instance.AddItem(item);
        UpdateShop();
    }

    public void SellItem(ItemScriptableObject item)
    {
        Inventory.Instance.RemoveItem(item);
        UpdateShop();
    }
}
