using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _radius;
    [SerializeField] private int _enemyNumber;

    private float _angelStep;

    public int EnemyNumber => _enemyNumber;
    public int EnemyCounter { get; private set; }

    private void Start()
    {
        _angelStep = 360 / EnemyNumber;
    }

    public void Spawn()
    {
        Vector3 newPosition = new Vector3(_radius * Mathf.Cos(_angelStep * EnemyCounter * Mathf.Deg2Rad), 0, _radius * Mathf.Sin(_angelStep * EnemyCounter * Mathf.Deg2Rad));
        Instantiate(_enemy, transform.position + newPosition, Quaternion.identity);
        EnemyCounter++;
    }
}
