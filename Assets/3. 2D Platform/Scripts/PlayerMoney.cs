using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]

public class PlayerMoney : MonoBehaviour
{

    [SerializeField] private int _countMoney;
    [SerializeField] private AudioClip _moneySound;
    [SerializeField] private TMP_Text _moneyUI;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _moneyUI.text = _countMoney.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Money>(out Money money))
        {
            _audioSource.PlayOneShot(_moneySound);
            _countMoney++;
            _moneyUI.text = _countMoney.ToString();
        }
    }
}
