using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private int _minDistance;
    [SerializeField] private int _maxDistance;
    [SerializeField] private ObjectUsed _object;
    [SerializeField] private float _delay;

    private const string UsedObjectMask = "UsedObject";

    private void Start()
    {
        StartCoroutine(SpawnMoney());
    }

    private IEnumerator SpawnMoney()
    {
        while (true)
        {
            int randomPointX = Random.Range(_minDistance, _maxDistance);
            Vector2 spawnPoint = new Vector2(randomPointX, transform.position.y);

            RaycastHit2D hit = Physics2D.Raycast(spawnPoint, Vector2.down, 10, LayerMask.GetMask(UsedObjectMask));

            if (hit == false)
            {
                Instantiate(_object, new Vector3(randomPointX, transform.position.y, 0), Quaternion.identity);
            }

            yield return new WaitForSeconds(_delay);
        }
    }
}
