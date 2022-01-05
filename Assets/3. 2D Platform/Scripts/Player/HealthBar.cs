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
    private Slider _healthBar;
    private Coroutine _changeBar;

    private void Start()
    {
        _speed = 2f;
        _healthBar = GetComponent<Slider>();
        _healthBar.maxValue = _player.MaxHealth;
        _healthBar.value = _player.Health;
        _changeBar = null;
    }

    private void OnEnable()
    {
        _player.Changed += TryRunChangeBar;
    }

    private void OnDisable()
    {
        _player.Changed -= TryRunChangeBar;
    }

    private void TryRunChangeBar()
    {
        if (_changeBar == null)
        {
            _changeBar = StartCoroutine(ChangeBar());
        }
    }

    private IEnumerator ChangeBar()
    {       
        while (_healthBar.value != _player.Health)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _player.Health, _speed * Time.deltaTime);
            yield return null;
        }

        _changeBar = null;
    }
}
