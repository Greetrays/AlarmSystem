using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private GameObject _spawnPointsObject;

    private int _currentPoint;
    private SpawnPoint[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = _spawnPointsObject.GetComponentsInChildren<SpawnPoint>();
        StartCoroutine(SpawnEnemys());
    }

    private IEnumerator SpawnEnemys()
    {
        while (true)
        {
            _spawnPoints[_currentPoint].Spawn();
            _currentPoint++;

            if (_currentPoint >= _spawnPoints.Length)
            {
                _currentPoint = 0;
            }

            yield return new WaitForSeconds(_delay);
        }
    }
}
