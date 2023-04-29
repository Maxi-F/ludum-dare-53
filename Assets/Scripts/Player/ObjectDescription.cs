using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(CameraRotationFromMouse))]
public class ObjectDescription : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private TextMeshProUGUI _ghostText;
    [SerializeField] private Canvas _hudCanvas;
    [SerializeField] private Canvas _objectDescriptionCanvas;
    [SerializeField] private TextMeshProUGUI _objectText;

    private CameraRotationFromMouse _cameraRotation;
    private bool isShowingDescription = false;

    private void Awake()
    {
        _cameraRotation = GetComponent<CameraRotationFromMouse>();   
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isShowingDescription)
        {
            _hudCanvas.gameObject.SetActive(true);
            _objectDescriptionCanvas.gameObject.SetActive(false);
            _objectText.text = "";
            _cameraRotation.ReleaseRotation();
            _playerMovement.ReleaseMovement();
        }
    }

    public void ShowDescription(string description)
    {
        _hudCanvas.gameObject.SetActive(false);
        _objectText.text = description;
        _objectDescriptionCanvas.gameObject.SetActive(true);
        _cameraRotation.BlockRotation();
        _playerMovement.BlockMovement();
        isShowingDescription = true;
    }
}
