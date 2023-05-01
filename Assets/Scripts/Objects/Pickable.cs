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
        _meshRenderer.material.EnableKeyword("_EMISSION");
    }

    public void UnIlluminate()
    {
        _meshRenderer.material.DisableKeyword("_EMISSION");
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
