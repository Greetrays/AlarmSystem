using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private AudioClip _takeDamegeSound;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyMovement>(out EnemyMovement enemy))
        {
            _health--;
            _audioSource.PlayOneShot(_takeDamegeSound);  

            if (_health <= 0)
            {
                Debug.Log("Вы проиграли!");
            }
        }
    }
}
