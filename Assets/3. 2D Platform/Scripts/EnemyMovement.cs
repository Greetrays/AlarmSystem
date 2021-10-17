using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _puth;
    [SerializeField] private float _speed;

    private Transform[] _targetPoints;
    private int _currentPoint;

    private void Start()
    {
        _targetPoints = new Transform[_puth.childCount];

        for (int i = 0; i < _puth.childCount; i++)
        {
            _targetPoints[i] = _puth.GetChild(i);
        }
    }
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPoints[_currentPoint].position, _speed * Time.deltaTime);

        if (transform.position == _targetPoints[_currentPoint].position)
        {
            _currentPoint++;

            if (_currentPoint >= _targetPoints.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
