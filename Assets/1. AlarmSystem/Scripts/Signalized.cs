using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signalized : MonoBehaviour
{
    [SerializeField] private float _targetVolume;
    [SerializeField] private float _maxStep;
    [SerializeField] private AudioSource _audioSource;

    private bool _enabled;
    private Coroutine _oscillateSound;

    private void Start()
    {
        _enabled = false;
    }

    private void Update()
    {       
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

    private IEnumerator OscillateSound()
    {
        while (true)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _maxStep * Time.deltaTime);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _oscillateSound = StartCoroutine(OscillateSound());
            _audioSource.Play();
            _enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _audioSource.Stop();
            StopCoroutine(_oscillateSound);
            _enabled = false;
        }
    }
}
