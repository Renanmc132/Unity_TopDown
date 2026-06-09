using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    private float moveSpeed = 5f;
    private float initialSpeed;
    private float runSpeed = 6f; 
    private Vector2 direction;



    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        initialSpeed = moveSpeed;
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));

        if (direction.sqrMagnitude > 0)
        {
            _anim.SetInteger("Movimento", 1);
        }
        else
        {
            _anim.SetInteger("Movimento", 0);
        }

        Flip();
        PlayerRun();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + direction.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        if (direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        else if (direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }

    }

    private void PlayerRun()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = initialSpeed;
        }

    }



}



