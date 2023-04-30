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

    private bool blockMovement = false;
    
    public void BlockMovement()
    {
        blockMovement = true;
    }

    public void ReleaseMovement()
    {
        blockMovement = false;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }   

    private void Update()
    {
        _inputX = Input.GetAxisRaw("Horizontal");
        _inputY = Input.GetAxisRaw("Vertical");        
    }

    private void FixedUpdate()
    {
        if(!blockMovement)
        {
            _moveHorizontalResult = GetMovementVectorFor(_cameraTransform.forward, _inputY);

            _moveVerticalResult = GetMovementVectorFor(_cameraTransform.right, _inputX);

            _rigidbody.MovePosition(transform.position + _moveHorizontalResult + _moveVerticalResult);
        }
    }

    private Vector3 GetMovementVectorFor(Vector3 cameraTransformVector, float input)
    {
        return new Vector3(GetNewPositionFor(cameraTransformVector.x, input), 0, GetNewPositionFor(cameraTransformVector.z, input));
    }

    private float GetNewPositionFor(float valueInVector, float input)
    {
        return valueInVector * input * _velocity * Time.deltaTime;
    }
}