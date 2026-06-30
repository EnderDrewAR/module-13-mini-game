using System;
using Unity.VisualScripting;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float _moveForce;
    [SerializeField] private float _jumpForce;

    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    private const float DeadZone = 0.05f;
    
    private Rigidbody _rigidbody; 
    private Vector3 _moveDirection;
        
    private bool _isJumping;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float xInput = Input.GetAxis(HorizontalAxis);
        float yInput = Input.GetAxis(VerticalAxis);
        
        _moveDirection = new Vector3(xInput, 0f, yInput);
        
        if (_moveDirection.magnitude < DeadZone)
            _moveDirection = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            _isJumping = true;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_moveDirection.magnitude) > DeadZone)
            transform.rotation = Quaternion.LookRotation(_moveDirection);
        
        _rigidbody.AddForce(_moveDirection * _moveForce);

        if (_isJumping)
        {
            _rigidbody.AddForce(transform.up * _jumpForce);
            _isJumping = false;
        }
    }

    private void OnCollisionEnter(Collision collision) => _isGrounded = true;

    private void OnCollisionExit(Collision collision) => _isGrounded = false;
    
}
