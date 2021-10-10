using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signalized : MonoBehaviour
{
    [SerializeField] private float _targetVolume;
    [SerializeField] private float _maxStep;
    [SerializeField] private AudioSource _audioSource;

    private bool _enabled;

    private void Start()
    {
        _enabled = false;
    }

    private void Update()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _maxStep * Time.deltaTime);

        if (_enabled == true)
        {
            if (_audioSource.volume >= _targetVolume)
            {
                _maxStep *= -1;
            }
            else if (_audioSource.volume <= 0)
            {
                _maxStep *= -1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _audioSource.Play();
            _enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _audioSource.Stop();
            _enabled = false;
        }
    }
}
