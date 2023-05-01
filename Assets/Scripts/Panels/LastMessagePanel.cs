using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class LastMessagePanel : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private bool finished = false;
    private float finishedTime;

    [SerializeField] [Range(0f, 10f)] private float _waitSeconds;
    [SerializeField] [Range(2f, 50f)] private float _fadeOutSeconds;

    // Start is called before the first frame update
    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad < _waitSeconds)
        {
            return;
        }
        if (_canvasGroup.alpha < 1 && !finished)
        {
            _canvasGroup.alpha += Time.deltaTime;
        } else if (!finished)
        {
            finished = true;
            finishedTime = Time.timeSinceLevelLoad;
        } else
        {
            if (Time.timeSinceLevelLoad < _fadeOutSeconds + finishedTime)
            {
                return;
            }
            if(_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= Time.deltaTime;
            }
        }
    }
}
