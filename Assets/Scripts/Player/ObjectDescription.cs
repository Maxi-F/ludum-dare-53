using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(CameraRotationFromMouse))]
public class ObjectDescription : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private TextMeshProUGUI _ghostText;
    [SerializeField] private Canvas _hudCanvas;
    [SerializeField] private Canvas _objectDescriptionCanvas;
    [SerializeField] private TextMeshProUGUI _objectText;
    [SerializeField] private Image image;

    private CameraRotationFromMouse _cameraRotation;
    private bool isShowingDescription = false;
    private bool _shouldEnd = false;

    [HideInInspector]
    private string _musicToPlay = "Gameplay";

    private void Awake()
    {
        _cameraRotation = GetComponent<CameraRotationFromMouse>();   
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isShowingDescription)
        {
            AudioManager _audioManager = FindObjectOfType<AudioManager>();
            if (_shouldEnd)
            {
                _audioManager.StopAll();
                _audioManager.Play("Pistol");
                ScenesManager.LoadSceneEndScreen();
            } else
            {
                _audioManager.Stop("Fantasmas_objetos");
                _audioManager.Play(_musicToPlay);

                PauseManager _pauseManager = FindObjectOfType<PauseManager>();
                _pauseManager.SetWasAlreadyBlocked(false);

                _hudCanvas.gameObject.SetActive(true);
                
                image.gameObject.SetActive(false);

                isShowingDescription = false;
                _objectDescriptionCanvas.gameObject.SetActive(false);
                _objectText.text = "";
                _cameraRotation.ReleaseRotation();
                _playerMovement.ReleaseMovement();
            }
        }
    }

    public void SetMusicToPlay(string name)
    {
        _musicToPlay = name;
    }

    public void ShowDescription(string description, string audioClip = "", bool shouldEnd = false, Sprite sprite = null)
    {
        AudioManager _audioManager = FindObjectOfType<AudioManager>();
        _audioManager.PauseAll();

        PauseManager _pauseManager = FindObjectOfType<PauseManager>();
        _pauseManager.SetWasAlreadyBlocked(true);

        if(audioClip != "")
        {
            _audioManager.Play(audioClip);
        }
        _audioManager.Play("Fantasmas_objetos");

        _hudCanvas.gameObject.SetActive(false);
        _objectText.text = description;
        _objectDescriptionCanvas.gameObject.SetActive(true);

        if(sprite != null)
        {
            image.gameObject.SetActive(true);
            image.sprite = sprite;
        }

        _cameraRotation.BlockRotation();
        _playerMovement.BlockMovement();
        isShowingDescription = true;
        _shouldEnd = shouldEnd;
    }
}
