using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUsed : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            Destroy(gameObject);
        }
    }
}
