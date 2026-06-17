using System.Collections;
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
    private float attackDuration = 0.4f;
    public GameObject attackArea;
    [SerializeField] private float attackAreaSize = 0.5f;
    


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

        float posX = direction.x * 0.553f;
        float posY = direction.y * 0.3f;

        attackArea.transform.localPosition = new Vector2(posX,posY);




    }

    private void MovePlayer()
    {
        _rb.MovePosition(_rb.position + direction.normalized * moveSpeed * Time.fixedDeltaTime);

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
            if(!isAttack)
                StartCoroutine(AttackCorou());
            
        }
    }

    private IEnumerator AttackCorou()
    {
        isAttack = true;
        moveSpeed = 0;
        yield return new WaitForSeconds(attackDuration);
        moveSpeed = 4f;
        isAttack = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackArea.transform.position, attackAreaSize);
    }


}