using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PickUpObject))]
[RequireComponent(typeof(LookObject))]
public class GiveObject : MonoBehaviour
{
    private PickUpObject _pickUpObject;
    private LookObject _lookObject;

    private void Awake()
    {
        _pickUpObject = GetComponent<PickUpObject>();
        _lookObject = GetComponent<LookObject>();
    }
    // Update is called once per frame
    void Update()
    {
        if(_pickUpObject.heldObject != null && _lookObject.isLookingToObject)
        {
            Ghost ghost = _lookObject.lookedObject.transform.GetComponent<Ghost>();
            if(ghost && Input.GetKeyDown(KeyCode.E))
            {
                ghost.ObtainObject(_pickUpObject.heldObject);
                _pickUpObject.DropObject();
            }
        }
    }
}
