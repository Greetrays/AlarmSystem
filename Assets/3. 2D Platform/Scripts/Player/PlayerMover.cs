using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private bool _isFacingRight;
    private bool _isGround;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private bool _isGame;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _isGame = false;
        _isFacingRight = true;
    }
    
    private void Update()
    {
        if (_isGame)
        {
            if (Input.GetKey(KeyCode.D))
            {
                Flip(false);

                Vector3 newPosition = new Vector3(_speed * Time.deltaTime, 0, 0);
                transform.Translate(newPosition);
                _animator.SetBool(AnimatorPlayerController.States.IsWalk, true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Flip(true);

                Vector3 newPosition = new Vector3(-1 * _speed * Time.deltaTime, 0, 0);
                transform.Translate(newPosition);
                _animator.SetBool(AnimatorPlayerController.States.IsWalk, true);
            }
            else
            {
                _animator.SetBool(AnimatorPlayerController.States.IsWalk, false);
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && _isGround == true)
        {
            _rigidbody2D.AddForce(Vector3.up * _jumpForce);
        }
    }

    public void SwitchGame(bool isGame)
    {
        _isGame = isGame;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            _isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
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
