using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private UnityEvent _healthChanged;

    private float _speed;
    private bool _isWorkChangeBar;
    private Slider _healthBar;

    private void Start()
    {
        _speed = 2f;
        _healthBar = GetComponent<Slider>();
        _healthBar.maxValue = _player.MaxHealth;
        _healthBar.value = _player.Health;

        _player.OnChanged += StartChangeBar;
    }

    private void StartChangeBar()
    {
        if (_isWorkChangeBar == false)
        {
            var changeBar = StartCoroutine(ChangeBar());
        }
    }

    private IEnumerator ChangeBar()
    {       
        while (_healthBar.value != _player.Health)
        {
            _isWorkChangeBar = true;
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _player.Health, _speed * Time.deltaTime);
            yield return 0;
        }

        _isWorkChangeBar = false;
    }
}
