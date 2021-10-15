using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private float _targetTime;
    [SerializeField] private GameObject _spawnPointsObject;

    private float _currentTime;
    private int _currentPoint;
    private SpawnPoint[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = _spawnPointsObject.GetComponentsInChildren<SpawnPoint>();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _targetTime && _spawnPoints[_currentPoint].EnemyCounter < _spawnPoints[_currentPoint].EnemyNumber)
        {
            _spawnPoints[_currentPoint].GetComponent<SpawnPoint>().Spawn();
            _currentPoint++;
            _currentTime = 0;

            if (_currentPoint >= _spawnPoints.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
