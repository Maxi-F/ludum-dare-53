using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpObject : MonoBehaviour
{
    [SerializeField] [Range(1.0f, 5.0f)] private float _maxRaycastDistance;
    [SerializeField] private TextMeshProUGUI _ghostText;

    private Pickable _visiblePickableObject;
    private Pickable _heldObject;

    // Update is called once per frame
    void Update()
    {
        LookAtObject();
    }


    void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_heldObject == null)
            {
                _ghostText.text = "I should return to the ghost...";
                _heldObject = _visiblePickableObject;
                UnIlluminateObject();
                _heldObject.Disappear();
            }
        }
    }

    void LookAtObject()
    {
        RaycastHit objectInfo;

        Ray ray = new Ray(transform.position, transform.forward);
        if (_heldObject == null && Physics.Raycast(ray, out objectInfo, _maxRaycastDistance))
        {
            if (objectInfo.rigidbody != null)
            {
                Pickable pickableObject = objectInfo.rigidbody.gameObject.GetComponent<Pickable>();

                if (pickableObject != null)
                {
                    pickableObject.Illuminate();
                    if(_visiblePickableObject != null && !areSameObjects(pickableObject, _visiblePickableObject))
                    {
                        UnIlluminateObject();
                    }
                    _visiblePickableObject = pickableObject;
                    PickUp();
                }
            }
            else
            {
                UnIlluminateObject();
            }
        }
        else
        {
            UnIlluminateObject();
        }
    }

    bool areSameObjects(Pickable anObject, Pickable otherObject)
    {
        return anObject.Name() == otherObject.Name();
    }

    void UnIlluminateObject()
    {
        if (_visiblePickableObject != null)
        {
            _visiblePickableObject.UnIlluminate();
            _visiblePickableObject = null;
        }
    }
}
