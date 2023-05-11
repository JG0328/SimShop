using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shopObj;

    // These include all the items
    public List<ItemScriptableObject> items = new();

    public ItemButton buyButton;

    public List<ItemButton> buyButtons = new();

    public GameObject shopItemsContainer;

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
}
