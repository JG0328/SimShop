using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public TMP_Text txtName;

    public TMP_Text txtType;

    public TMP_Text txtDescription;

    public Image imgIcon;

    public Button actionButton;

    public TMP_Text txtAction;

    // All item buttons share the same structure, only their action ('buy', 'sell', 'equip') changes.
    private void SetupBaseButton(ItemScriptableObject item)
    {
        txtName.SetText(item.itemName);
        txtDescription.SetText(item.itemDescription);
        txtType.SetText(Enum.GetName(typeof(Item.Type), item.itemType));
        imgIcon.sprite = item.itemIcon;
    }

    public void SetupBuyButton(ItemScriptableObject item)
    {
        SetupBaseButton(item);

        actionButton.onClick.AddListener(() =>
        {
            ShopManager.Instance.BuyItem(item);
        });

        txtAction.SetText($"Buy for ${item.buyPrice}");

        if (Inventory.Instance.coins < item.buyPrice)
        {
            actionButton.interactable = false;
        }
    }

    public void SetupSellButton(ItemScriptableObject item)
    {
        SetupBaseButton(item);

        actionButton.onClick.AddListener(() =>
        {
            ShopManager.Instance.SellItem(item);
        });

        txtAction.SetText($"Sell for ${item.sellPrice}");
    }
}
