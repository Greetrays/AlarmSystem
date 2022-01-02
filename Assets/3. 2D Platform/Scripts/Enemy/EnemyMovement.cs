using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Puth _puth;
    [SerializeField] private float _speed;

    private Transform[] _targetPoints;
    private int _currentPoint;
    private bool _isGame;

    private void Start()
    {
        _isGame = false;
        _targetPoints = new Transform[_puth.transform.childCount];

        for (int i = 0; i < _puth.transform.childCount; i++)
        {
            _targetPoints[i] = _puth.transform.GetChild(i);
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
