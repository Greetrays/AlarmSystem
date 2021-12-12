using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private int _minDistance;
    [SerializeField] private int _maxDistance;
    [SerializeField] private ObjectUsed _object;
    [SerializeField] private float _delay;

    private bool _isGame;

    private void Start()
    {
        _isGame = false;
        StartCoroutine(SpawnMoney());
    }

    private IEnumerator SpawnMoney()
    {
        while (true)
        {
            if (_isGame == true)
            {
                Instantiate(_object, new Vector3(Random.Range(_minDistance, _maxDistance), transform.position.y, 0), Quaternion.identity);
            }

            yield return new WaitForSeconds(_delay);
        }
    }

    public void SwitchGame(bool isGame)
    {
        _isGame = isGame;
    }
}
