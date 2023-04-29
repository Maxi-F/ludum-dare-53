using UnityEngine;

public class CameraRotationFromMouse : MonoBehaviour
{
    [SerializeField] [Range(0.01f, 50.0f)] private float _sensitivity;

    [SerializeField] [Range(0.0f, 70.0f)] private float _maxXRotation;
    
    [SerializeField] [Range(-70.0f, 0.0f)] private float _minXRotation;   

    private float _rotationX = 0;
    private float _rotationY = 0;
    private bool blockRotation = false;

    public void BlockRotation()
    {
        blockRotation = true;
    }

    public void ReleaseRotation()
    {
        blockRotation = false;
    }

    void Start()
    {
        transform.eulerAngles = Vector3.zero;      
    }    

    void Update()
    {
        if(!blockRotation)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _sensitivity;
            _rotationY += Input.GetAxis("Mouse X") * _sensitivity;

            _rotationX = Mathf.Clamp(_rotationX, _minXRotation, _maxXRotation);

            transform.eulerAngles = new Vector3(_rotationX, _rotationY, 0.0f);
        }
    }    
}
