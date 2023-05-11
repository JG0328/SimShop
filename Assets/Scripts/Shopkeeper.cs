using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    public void Interact()
    {
        ShopManager.Instance.OpenShop();
    }
}
