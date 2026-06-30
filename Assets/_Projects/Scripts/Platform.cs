using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] Transform _firstPoint;
    [SerializeField] Transform _secondPoint;
    [SerializeField] private float _speed = 2f;

    private const float DeadZone = 0.05f;
    
    private Rigidbody _rigidbody;
    private Transform _currentTarget;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        _currentTarget = _secondPoint;
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = Vector3.MoveTowards(
            transform.position,
            _currentTarget.position,
            _speed * Time.deltaTime
        );
        
        _rigidbody.MovePosition(newPosition);

        if (Vector3.Distance(transform.position, _currentTarget.position) < DeadZone)
            _currentTarget = (_currentTarget == _firstPoint) ? _secondPoint : _firstPoint;
        
    }
}
