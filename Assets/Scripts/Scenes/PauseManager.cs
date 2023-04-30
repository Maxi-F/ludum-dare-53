using UnityEditor;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Canvas _pauseCanvas;
    [SerializeField] private CameraRotationFromMouse _cameraRotation;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private KeyCode _pauseKey;

    void Awake()
    {
        if (_pauseCanvas != null) 
        {
            _pauseCanvas.enabled = false;
        }        
    }

    void Update()
    {
        ManagePause();
    }

    private void ManagePause() 
    {
        if (Input.GetKeyDown(_pauseKey)) 
        {
            _pauseCanvas.enabled = !_pauseCanvas.enabled;

            if (_pauseCanvas.enabled)
            {
                _cameraRotation.BlockRotation();
                _playerMovement.BlockMovement();
            }
            else 
            {
                _cameraRotation.ReleaseRotation();
                _playerMovement.ReleaseMovement();
            }
        }
    }  

    public void ClosePause() 
    {
        _pauseCanvas.enabled = false;

        _cameraRotation.ReleaseRotation();
        _playerMovement.ReleaseMovement();
    }
}