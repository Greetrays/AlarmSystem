using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class PlayerMoney : MonoBehaviour
{ 
    [SerializeField] private UnityEvent _onRecive;

    public event UnityAction OnRecive
    {
        add => _onRecive.AddListener(value);
        remove => _onRecive.RemoveListener(value);
    }

    public int CountMoney { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Money money))
        {
            CountMoney += money.Count;
            _onRecive.Invoke();
        }
    }
}
