using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    private float moveSpeed = 5f;
    private float initialSpeed;
    private float runSpeed = 6f; 
    private Vector2 direction;

    private bool isAttack;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        initialSpeed = moveSpeed;
    }

    void Update()
    {
        PlayerRun();
        OnAttack();

        
    }

    private void FixedUpdate()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (direction.sqrMagnitude > 0.1f)
        {
            MovePlayer();

            _anim.SetFloat("X", direction.x);
            _anim.SetFloat("Y", direction.y);

            _anim.SetInteger("Movimento", 1);
        }
        else
        {
            _anim.SetInteger("Movimento", 0);
        }

        if (isAttack)
        {
            _anim.SetInteger("Movimento", 2);
        }




    }

    private void MovePlayer()
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

    void OnAttack()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetMouseButtonDown(0))
        {
            isAttack = true;
            moveSpeed = 0;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetMouseButtonUp(0))
        {
            isAttack = false;
            moveSpeed = initialSpeed;
        }
    }



}