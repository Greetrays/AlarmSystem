using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private EnemyCapsule _enemy;
    [SerializeField] private float _radius;
    [SerializeField] private int _enemyCount;

    private float _angleStep;
    private int _enemyCounter;

    private void Start()
    {
        _angleStep = 360 / _enemyCount;
    }

    public void Spawn()
    {
        if (_enemyCounter < _enemyCount)
        {
            Vector3 newPosition = new Vector3(_radius * Mathf.Cos(_angleStep * _enemyCounter * Mathf.Deg2Rad), 0, _radius * Mathf.Sin(_angleStep * _enemyCounter * Mathf.Deg2Rad));
            Instantiate(_enemy, transform.position + newPosition, Quaternion.identity);
            _enemyCounter++;
        }
    }
}
