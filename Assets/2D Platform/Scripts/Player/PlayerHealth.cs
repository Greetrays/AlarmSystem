using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class PlayerHealth : Health
{
    [SerializeField] private UnityEvent _cure;
    [SerializeField] private UnityEvent _hit;

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (Current > 0)
            {
                Change(-enemy.Damage);
                _hit?.Invoke();
            }

            if (Current <= 0)
            {
                Debug.Log("ВЫ ПРОИГРАЛИ!");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Heart healt))
        {
            if (Current < MaxCapacity)
            {
                Change(healt.Size);
            }

            _cure?.Invoke();
        }
    }
}
