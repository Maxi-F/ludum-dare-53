using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(LookObject))]
[RequireComponent(typeof(ObjectDescription))]
public class PickUpObject : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ghostText;

    private LookObject _lookObject;
    private Pickable _visiblePickableObject;
    private ObjectDescription _objectDescription;
    public Pickable heldObject;

    public void DropObject()
    {
        heldObject = null;
        _ghostText.text = "";
    }

    private void Awake()
    {
        _objectDescription = GetComponent<ObjectDescription>();
        _lookObject = GetComponent<LookObject>();
    }

    private void Update()
    {
        LookAtObject();

        if(heldObject != null)
        {
            _ghostText.text = "I should return to the ghost...";
        }
    }


    private void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E) && heldObject == null)
        {
            _objectDescription.ShowDescription(_visiblePickableObject.objectDescription);
            heldObject = _visiblePickableObject;
            UnIlluminateObject();
            heldObject.Disappear();
        }
    }

    private void LookAtObject()
    {

        if (heldObject == null && _lookObject.isLookingToObject)
        {
            RaycastHit objectInfo = _lookObject.lookedObject;

            if (objectInfo.rigidbody != null)
            {
                Debug.Log(objectInfo.rigidbody.name);
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

    private bool areSameObjects(Pickable anObject, Pickable otherObject)
    {
        return anObject.Name() == otherObject.Name();
    }

    private void UnIlluminateObject()
    {
        if (_visiblePickableObject != null)
        {
            _visiblePickableObject.UnIlluminate();
            _visiblePickableObject = null;
        }
    }
}
