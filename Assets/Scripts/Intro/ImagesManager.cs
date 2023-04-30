using UnityEngine;
using UnityEngine.UI;

public class ImagesManager : MonoBehaviour
{
    [SerializeField] private Image _image;

    [SerializeField] private Sprite[] _sprites;

    [SerializeField] [Range(1.0f, 5.0f)] private float _timeBetweenImages;

    private int _count;

    private float _timer;

    void Start()
    {
        _count = 0;

        _timer = _timeBetweenImages;

        _image.sprite = _sprites[0];
    }

    void Update()
    {
        if (_timer <= 0.0f)
        {
            if (_count < _sprites.Length)
            {
                _count += 1;

                _image.sprite = _sprites[_count];

                _timer = _timeBetweenImages;
            }
            else
            {
                ScenesManager.LoadSceneGameplay();
            }            
        }

        _timer -= Time.deltaTime;
    }
}