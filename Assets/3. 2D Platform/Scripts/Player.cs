using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private AudioClip _takeDamegeSound;
    [SerializeField] private TMP_Text _healthUI;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _healthUI.text = _health.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyMovement>(out EnemyMovement enemy))
        {
            _health--;
            _healthUI.text = _health.ToString();
            _audioSource.PlayOneShot(_takeDamegeSound); 
        }
    }
}
