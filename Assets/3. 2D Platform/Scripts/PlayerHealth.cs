using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private AudioClip _takeDamegeSound;
    [SerializeField] private AudioClip _usedHealth;

    private AudioSource _audioSource;

    public float Health => _health;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyMovement>(out EnemyMovement enemy))
        {
            _health--;
            _audioSource.PlayOneShot(_takeDamegeSound); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health healt))
        {
            if (_health < 10)
            {
                _health++;             
            }

            _audioSource.PlayOneShot(_usedHealth);
        }
    }
}
