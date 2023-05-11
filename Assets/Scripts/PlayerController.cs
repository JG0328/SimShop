using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public bool canMove = true;

    public Sprite defaultClothes;

    public SpriteRenderer clothesRenderer;

    private Rigidbody2D _rb2d;

    private Vector2 _input;

    public static PlayerController Instance;

    private void Awake()
    {
        Instance = this;
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get both axis movement and store them in a Vector2 variable
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Inventory.Instance.isOpen)
            {
                Inventory.Instance.CloseInventory();
            }
            else
            {
                Inventory.Instance.OpenInventory();
            }
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            _input.Normalize();
            _rb2d.velocity = _input * moveSpeed;
        }
    }

    public void UpdateClothes()
    {
        ItemScriptableObject item = ShopManager.Instance.items.FirstOrDefault(i => i.itemId == Inventory.Instance.equippedItem);
        if (item != null)
        {
            clothesRenderer.sprite = item.itemIcon;
        }
        else
        {
            clothesRenderer.sprite = defaultClothes;
        }
    }
}
