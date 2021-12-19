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
        _speed = 2f;
        _healthBar = GetComponent<Slider>();
        _healthBar.maxValue = _player.MaxHealth;
        _healthBar.value = _player.Health;
    }

    public void StartChangeBar()
    {
        var changeBar = StartCoroutine(ChangeBar());
    }

    private IEnumerator ChangeBar()
    {
        while (_healthBar.value != _player.Health)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _player.Health, _speed * Time.deltaTime);
            yield return 0;
        }
    }
}
