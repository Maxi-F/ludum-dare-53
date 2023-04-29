using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour, GhostInterface
{
    public void ObtainObject(Pickable heldObject)
    {
        Debug.Log(heldObject.name);
    }
}
