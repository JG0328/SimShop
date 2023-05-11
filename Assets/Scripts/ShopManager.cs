using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shopObj;

    public List<ItemScriptableObject> items = new();

    public ItemButton buyButton;

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
        foreach (ItemScriptableObject item in items)
        {
            ItemButton button = Instantiate(buyButton, shopItemsContainer.transform);
            button.SetupBuyButton(item);
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
}
