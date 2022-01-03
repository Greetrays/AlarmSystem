using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class PlayerMoney : MonoBehaviour
{ 
    [SerializeField] private UnityEvent _recive;

    public event UnityAction Recive
    {
        add => _recive?.AddListener(value);
        remove => _recive?.RemoveListener(value);
    }

    public int CountMoney { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Money money))
        {
            CountMoney += money.Count;
            _recive?.Invoke();
        }
    }
}
