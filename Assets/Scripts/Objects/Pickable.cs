using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Pickable : MonoBehaviour, PickableInterface
{
    [SerializeField] Material _newMaterial;
    [SerializeField] public string objectDescription;

    private MeshRenderer _meshRenderer;
    private Material _previousMaterial;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _previousMaterial = _meshRenderer.material;
    }

    public string Name()
    {
        return _meshRenderer.gameObject.name;
    }

    public void Illuminate()
    {
        _meshRenderer.material = _newMaterial;
    }

    public void UnIlluminate()
    {
        _meshRenderer.material = _previousMaterial;
    }

    public void Disappear()
    {
        gameObject.SetActive(false);
    }
}
