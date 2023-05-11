using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool canInteract = false;

    private void Update()
    {
        if (PlayerController.Instance.canMove && canInteract && Input.GetButtonDown("Jump"))
        {
            ShopManager.Instance.OpenShop();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shopkeeper"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;
    }
}
