using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _healthObject;
    [SerializeField] private float _speed;

    private Slider _healthBar;
    private Coroutine _changeValue;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _healthBar.maxValue = _healthBar.value = _healthObject.MaxCapacity;
        _changeValue = null;
    }

    private void OnEnable()
    {
        _healthObject.Changed += TryRunChangeValue;
    }

    private void OnDisable()
    {
        _healthObject.Changed -= TryRunChangeValue;
    }

    private void TryRunChangeValue()
    {
        if (_changeValue == null)
        {
            _changeValue = StartCoroutine(ChangeValue());
        }
    }

    private IEnumerator ChangeValue()
    {       
        while (_healthBar.value != _healthObject.Current)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _healthObject.Current, _speed * Time.deltaTime);
            yield return null;
        }

        _changeValue = null;
    }
}
