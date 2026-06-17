using UnityEngine;

public class SlimeController : MonoBehaviour
{

    private Vector2 direction;
    private Rigidbody2D _rb;
    public DetectionController _detecController;
    private float moveSpeed = 4f;
    private SpriteRenderer _sprRenderer;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if(_detecController.detectedObjs.Count > 0)
        {
            direction = (_detecController.detectedObjs[0].transform.position - transform.position).normalized;
        
            _rb.MovePosition(_rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }

        if (direction.x > 0)
        {
            _sprRenderer.flipX = false;
        }else if (direction.x < 0)
        {
            _sprRenderer.flipX = true;
        }
    }




}
