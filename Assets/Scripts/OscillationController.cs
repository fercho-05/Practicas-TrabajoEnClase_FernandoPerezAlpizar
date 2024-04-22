using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillationController : MonoBehaviour
{
    [SerializeField]
    bool moveX;

    [SerializeField]
    bool moveY;

    [SerializeField]
    bool moveZ;

    [SerializeField]
    float distance;

    [SerializeField]
    float speed;

    [SerializeField]
    bool reverse;

    Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        Vector3 position = transform.position;

        if (moveX)
        {
            position.x = _startPosition.x + Mathf.PingPong(Time.time * speed, distance) * (reverse ? -1 : 1);
        }

        if (moveY)
        {
            position.y = _startPosition.y + Mathf.PingPong(Time.time * speed, distance) * (reverse ? -1 : 1);
        }

        if (moveZ)
        {
            position.z = _startPosition.z + Mathf.PingPong(Time.time * speed, distance) * (reverse ? -1 : 1);
        }

        transform.position = position;

    }
}
