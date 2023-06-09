using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PickUpObject))]
[RequireComponent(typeof(LookObject))]
[RequireComponent(typeof(ObjectDescription))]
public class GhostInteractor : MonoBehaviour
{
    private PickUpObject _pickUpObject;
    private LookObject _lookObject;
    private ObjectDescription _objectDescription;

    private bool _isInteracting = false;

    private void Awake()
    {
        _pickUpObject = GetComponent<PickUpObject>();
        _lookObject = GetComponent<LookObject>();
        _objectDescription = GetComponent<ObjectDescription>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _isInteracting = false;
        }

        if (_lookObject.isLookingToObject)
        {
            Ghost ghost = _lookObject.lookedObject.transform.GetComponent<Ghost>();
            if (ghost)
            {
                if(Input.GetKeyDown(KeyCode.E) && !_isInteracting)
                {
                    _isInteracting = true;
                    if (_pickUpObject.heldObject == null)
                    {
                        _objectDescription.ShowDescription(ghost.wantedObjectDescription);
                    }
                    else
                    {
                        ghost.ObtainObject(_pickUpObject.heldObject);
                        _pickUpObject.DropObject();
                    }
                }
            }
        }
    }
}
