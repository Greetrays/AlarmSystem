using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _countMoney;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyMovement>(out EnemyMovement enemy))
        {
            _health--;

            if (_health <= 0)
            {
                Debug.Log("Вы проиграли!");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Money>(out Money money))
        {
            _countMoney++;
        }
    }
}
