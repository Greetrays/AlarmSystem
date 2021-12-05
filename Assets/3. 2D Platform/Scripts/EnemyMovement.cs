using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _puth;
    [SerializeField] private float _speed;

    private Transform[] _targetPoints;
    private int _currentPoint;
    private bool _isGame;

    private void Start()
    {
        _isGame = false;
        _targetPoints = new Transform[_puth.childCount];

        for (int i = 0; i < _puth.childCount; i++)
        {
            _targetPoints[i] = _puth.GetChild(i);
        }
    }
    
    private void Update()
    {
        if (_isGame)
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

    public void SwitchGame(bool isGame)
    {
        _isGame = isGame;
    }
}
