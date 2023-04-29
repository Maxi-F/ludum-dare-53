using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookObject : MonoBehaviour
{
    [SerializeField] [Range(1.0f, 5.0f)] private float _maxRaycastDistance;
    public RaycastHit lookedObject;
    public bool isLookingToObject;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        isLookingToObject = Physics.Raycast(ray, out lookedObject, _maxRaycastDistance);
    }
}
