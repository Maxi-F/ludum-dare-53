using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImagesManager : MonoBehaviour
{
    [SerializeField] private Image _image;

    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private IntroImage[] _introImages;

    [SerializeField] private float _firstTiming;

    private int _count;

    private float _timer;

    void Start()
    {
        _count = 0;

        _timer = _firstTiming;

        _image.sprite = _introImages[0].sprite;

        _text.text = _introImages[0].text;
    }

    void Update()
    {
        if (_timer <= 0.0f)
        {
            if (_count < _introImages.Length)
            {
                _count += 1;
                if (_count < _introImages.Length)
                {
                    _image.sprite = _introImages[_count].sprite;
                    _text.text = _introImages[_count].text;

                    _timer = _introImages[_count].timeInPlace;
                }
            }
            else
            {
                AudioManager audioManager = FindObjectOfType<AudioManager>();
                audioManager.StopAll();
                audioManager.Play("Gameplay");

                ScenesManager.LoadSceneGameplay();
            }            
        }

        _timer -= Time.deltaTime;
    }
}