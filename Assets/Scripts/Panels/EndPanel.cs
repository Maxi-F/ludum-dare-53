using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class EndPanel : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private bool finished = false;

    [SerializeField] [Range(0f, 10f)] private float _waitSeconds;

    // Start is called before the first frame update
    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if(Time.timeSinceLevelLoad < _waitSeconds)
        {
            return;
        }
        if(_canvasGroup.alpha < 1)
        {
            _canvasGroup.alpha += Time.deltaTime;
        } else
        {
            if(!finished)
            {
                AudioManager _audioManager = FindObjectOfType<AudioManager>();
                _audioManager.Play("Intro_outro");
            }
            finished = true;
        }
    }
}
