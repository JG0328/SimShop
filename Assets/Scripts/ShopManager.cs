using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shopObj;

    public static ShopManager Instance;

    private void Awake()
    {
        Instance = this;

        shopObj.SetActive(false);
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
