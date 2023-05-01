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
                AudioManager _audioManager = FindObjectOfType<AudioManager>();
                _audioManager.PauseAll();
                _audioManager.Play("Pausa");

                _cameraRotation.BlockRotation();
                _playerMovement.BlockMovement();

                Time.timeScale = 0.0f;
            }
            else 
            {
                AudioManager _audioManager = FindObjectOfType<AudioManager>();
                _audioManager.Stop("Pausa");
                _audioManager.ResumeAll();

                _cameraRotation.ReleaseRotation();
                _playerMovement.ReleaseMovement();

                Time.timeScale = 1.0f;
            }
        }
    }  

    public void ClosePause() 
    {
        AudioManager _audioManager = FindObjectOfType<AudioManager>();
        _audioManager.Stop("Pausa");
        _audioManager.ResumeAll();

        _pauseCanvas.enabled = false;

        _cameraRotation.ReleaseRotation();
        _playerMovement.ReleaseMovement();

        Time.timeScale = 1.0f;
    }

    public void SetTimeScaleToNormal() 
    {
        Time.timeScale = 1.0f;
    }
}