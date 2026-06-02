using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float moveSpeed = 5f;
    private Vector2 direction;



    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

}
