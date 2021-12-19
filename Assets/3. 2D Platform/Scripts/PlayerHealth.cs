using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private AudioClip _takeDamegeSound;
    [SerializeField] private AudioClip _usedHealth;
    [SerializeField] private HealthBar _healthBar;

    private AudioSource _audioSource;
    
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnValidate()
    {
        if (_health > _maxHealth || _health == 0)
        {
            _health = _maxHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyMovement>(out EnemyMovement enemy))
        {
            if (_health > 0)
            {
                _health--;
                _healthBar.StartChangeBar();
                _audioSource.PlayOneShot(_takeDamegeSound);
            }

            if (_health <= 0)
            {
                Debug.Log("ВЫ ПРОИГРАЛИ!");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health healt))
        {
            if (_health < _maxHealth)
            {
                _health++;
                _healthBar.StartChangeBar();
            }         

            _audioSource.PlayOneShot(_usedHealth);
        }
    }
}
