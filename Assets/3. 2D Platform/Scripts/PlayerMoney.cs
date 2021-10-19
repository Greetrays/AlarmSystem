using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private int _countMoney;
    [SerializeField] private AudioClip _moneySound;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Money>(out Money money))
        {
            _audioSource.PlayOneShot(_moneySound);
            _countMoney++;
        }
    }
}
