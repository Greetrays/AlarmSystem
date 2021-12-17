using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;

    private float _speed;
    private Slider _healthBar;

    private void Start()
    {
        _speed = 3f;
        _healthBar = GetComponent<Slider>();
        _healthBar.maxValue = _player.Health;
        _healthBar.value = _player.Health;
    }

    private void Update()
    {
        if (_healthBar.value != _player.Health)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _player.Health, _speed * Time.deltaTime);
        }
    }
}
