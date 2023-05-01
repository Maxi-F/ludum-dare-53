using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Pickable : MonoBehaviour, PickableInterface
{
    [SerializeField] public string objectDescription;

    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public string Name()
    {
        return _meshRenderer.gameObject.name;
    }

    public void Illuminate()
    {
        _meshRenderer.material.SetColor("_Color", Color.red);
    }

    public void UnIlluminate()
    {
        _meshRenderer.material.SetColor("_Color", Color.white);
    }

    public void Disappear()
    {
        gameObject.SetActive(false);
    }

    public void Appear()
    {
        gameObject.SetActive(true);
    }
}
