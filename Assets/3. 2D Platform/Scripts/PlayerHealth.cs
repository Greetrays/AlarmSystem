using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private AudioClip _takeDamegeSound;
    [SerializeField] private AudioClip _usedHealth;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _speed;

    private AudioSource _audioSource;

    public float Health => _health;

    private void Update()
    {
        if (_healthBar.value != _health)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _health, Time.deltaTime * _speed);
        }
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _healthBar.maxValue = _healthBar.value = _health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyMovement>(out EnemyMovement enemy))
        {
            _health--;
            _audioSource.PlayOneShot(_takeDamegeSound); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health healt))
        {
            if (_health < 10)
            {
                _health++;             
            }

            _audioSource.PlayOneShot(_usedHealth);
        }
    }
}
