using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsulePlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(-1 * _speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0, 0, _speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(0, 0, -1 * _speed * Time.deltaTime);
        }
    }
}
