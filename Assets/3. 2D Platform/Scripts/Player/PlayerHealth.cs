using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private UnityEvent _cure;
    [SerializeField] private UnityEvent _hit;

    public event UnityAction Changed;

    public float Health => _health;
    public float MaxHealth => _maxHealth;

    private void OnValidate()
    {
        if (_maxHealth <= 0)
        {
            _maxHealth = 5;
        }

        if (_health > _maxHealth || _health <= 0)
        {
            _health = _maxHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (_health > 0)
            {
                ChangeHealth(-enemy.Damage);
                _hit?.Invoke();
            }

            if (_health <= 0)
            {
                Debug.Log("ВЫ ПРОИГРАЛИ!");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health healt))
        {
            if (_health < _maxHealth)
            {
                ChangeHealth(healt.Size);
            }

            _cure?.Invoke();
        }
    }

    private void ChangeHealth(float health)
    {
        _health += health;
        Changed?.Invoke();
    }
}
