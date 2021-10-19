using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _health;
    [SerializeField] private int _countMoney;

    private bool _isFacingRight;
    private bool _isGround;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _isFacingRight = true;
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Flip(false);

            Vector3 newPosition = new Vector3(_speed * Time.deltaTime, 0, 0);
            transform.position += newPosition;
            _animator.SetBool("isWalk", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Flip(true);

            Vector3 newPosition = new Vector3(-1 * _speed * Time.deltaTime, 0, 0);
            transform.position += newPosition;
            _animator.SetBool("isWalk", true);
        }
        else
        {
            _animator.SetBool("isWalk", false);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && _isGround == true)
        {
            _rigidbody2D.AddForce(Vector3.up * _jumpForce);
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.TryGetComponent<EnemyMovement>(out EnemyMovement enemy))
        {
            _health--;

            if (_health <= 0)
            {
                Debug.Log("Вы проиграли!");
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            _isGround = true;
        }

        if (collision.gameObject.TryGetComponent<Money>(out Money money))
        {
            _countMoney++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            _isGround = false;
        }
    }

    private void Flip(bool isFacingRight)
    {
        if (_isFacingRight == isFacingRight)
        {
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y);
            _isFacingRight = !_isFacingRight;
        }
    }
}
