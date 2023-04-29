using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(PickUpObject))]
[RequireComponent(typeof(CameraRotationFromMouse))]
public class ObjectDescription : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private TextMeshProUGUI _ghostText;
    [SerializeField] private Canvas _hudCanvas;
    [SerializeField] private Canvas _objectDescriptionCanvas;
    [SerializeField] private TextMeshProUGUI _objectText;

    private CameraRotationFromMouse _cameraRotation;
    private PickUpObject _pickUpObject;

    private void Awake()
    {
        _cameraRotation = GetComponent<CameraRotationFromMouse>();
        _pickUpObject = GetComponent<PickUpObject>();    
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _pickUpObject.heldObject != null)
        {
            Debug.Log("Wtf");
            _hudCanvas.gameObject.SetActive(true);
            _objectDescriptionCanvas.gameObject.SetActive(false);
            _objectText.text = "";
            _ghostText.text = "I should return to the ghost...";
            _cameraRotation.ReleaseRotation();
            _playerMovement.ReleaseMovement();
        }
    }

    public void ShowDescription(Pickable anObject)
    {
        _hudCanvas.gameObject.SetActive(false);
        _objectText.text = anObject.objectDescription;
        _objectDescriptionCanvas.gameObject.SetActive(true);
        _cameraRotation.BlockRotation();
        _playerMovement.BlockMovement();
    }
}
