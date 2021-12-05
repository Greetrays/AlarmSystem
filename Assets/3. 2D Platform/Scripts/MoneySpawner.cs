using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private int _minDistance;
    [SerializeField] private int _maxDistance;
    [SerializeField] private Money _money;
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
                Instantiate(_money, new Vector3(Random.Range(_minDistance, _maxDistance), transform.position.y, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(_delay);
        }
    }

    public void SwitchGame(bool isGame)
    {
        _isGame = isGame;
    }
}
