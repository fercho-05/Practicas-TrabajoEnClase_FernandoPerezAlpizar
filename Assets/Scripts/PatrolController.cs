using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolController : MonoBehaviour
{
    [SerializeField]
    Transform[] points;

    [SerializeField]
    float speed;

    Rigidbody _rigidbody;

    Transform _currentPoint;

    int _currentPointIndex;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        SetDestination(1);
    }

    private void FixedUpdate()
    {
        _rigidbody.position =
            Vector3.MoveTowards(_rigidbody.position, _currentPoint.position, speed * Time.fixedDeltaTime);

        if (_rigidbody.position == _currentPoint.position)
        {
            if (_currentPointIndex < points.Length - 1)
            {
                _currentPointIndex++;
            }
            else
            {
                _currentPointIndex = 0;
            }

            SetDestination(_currentPointIndex);
        }
    }

    private void SetDestination(int index)
    {
        _currentPointIndex = index;
        _currentPoint = points[_currentPointIndex];
        Vector3 position = _currentPoint.position;

        position.y = transform.position.y;
        _currentPoint.position = position;

        transform.LookAt(_currentPoint.position);
    }
}