using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    [SerializeField] [Range(0.1f, 50.0f)] private float _velocity;

    private Rigidbody _rigidbody;

    private Vector3 _moveHorizontalResult;
    private Vector3 _moveVerticalResult;

    private float _inputX;
    private float _inputY;  
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }   

    void Update()
    {
        _inputX = Input.GetAxisRaw("Horizontal");
        _inputY = Input.GetAxisRaw("Vertical");        
    }

    void FixedUpdate()
    {
        _moveHorizontalResult = _cameraTransform.forward * _inputY * _velocity * Time.deltaTime;

        _moveVerticalResult = _cameraTransform.right * _inputX * _velocity * Time.deltaTime;

        _rigidbody.MovePosition(transform.position + _moveHorizontalResult + _moveVerticalResult);        
    }
}