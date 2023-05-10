using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private CapsuleCollider2D _collider;
    private Rigidbody2D _rb2d;

    private Vector2 _input;

    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider2D>();
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get both axis movement and store them in a Vector2 variable
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        _input.Normalize();
        _rb2d.MovePosition(_rb2d.position + (moveSpeed * Time.fixedDeltaTime * _input));
    }
}
