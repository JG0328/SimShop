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

    public void SetupBuyButton(ItemScriptableObject item)
    {
        txtName.SetText(item.itemName);
        txtDescription.SetText(item.itemDescription);
        txtType.SetText(Enum.GetName(typeof(Item.Type), item.itemType));
        imgIcon.sprite = item.itemIcon;

        actionButton.onClick.AddListener(() =>
        {
            ShopManager.Instance.BuyItem(item);
        });

        txtAction.SetText($"Buy for ${item.buyPrice}");
    }
}
