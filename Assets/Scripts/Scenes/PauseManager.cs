using UnityEditor;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Canvas _pauseCanvas;

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
                Time.timeScale = 0.0f;                
            }
            else 
            {
                Time.timeScale = 1.0f;
            }
        }
    }  

    public void ClosePause() 
    {
        _pauseCanvas.enabled = false;

        Time.timeScale = 1.0f;
    }
}