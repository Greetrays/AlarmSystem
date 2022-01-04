using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private int _minDistance;
    [SerializeField] private int _maxDistance;
    [SerializeField] private ObjectUsed _object;
    [SerializeField] private float _delay;   

    private void Start()
    {
        StartCoroutine(SpawnMoney());
    }

    private IEnumerator SpawnMoney()
    {
        while (true)
        {
            Instantiate(_object, new Vector3(Random.Range(_minDistance, _maxDistance), transform.position.y, 0), Quaternion.identity);
            yield return new WaitForSeconds(_delay);
        }
    }
}
