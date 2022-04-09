using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D _body;
    private BoxCollider2D _boxCollider;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }
 
    private void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        _body.velocity = new Vector2(horizontalInput * speed, _body.velocity.y);
        
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
 
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
            Jump();
    }
 
    private void Jump()
    {
        _body.velocity = new Vector2(_body.velocity.x, speed);
    }
    private bool IsGrounded()
    {
        var bounds = _boxCollider.bounds;
        RaycastHit2D raycastHit = Physics2D.BoxCast(bounds.center,
            bounds.size, 0,
            Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider !=null;
    }
}
