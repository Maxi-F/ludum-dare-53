using UnityEngine;

public class GhostLevitating : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 2.0f)] private float _levitationHeight;

    [SerializeField] [Range(0.1f, 2.0f)] private float _levitationVelocity;

    private Vector3 _position;

    private float _initialHeight; 

    private float _time;

    private bool _goingUp;

    private void Start()
    {
        _position = transform.position;

        _initialHeight = transform.position.y;        

        _time = 0.0f;

        _goingUp = true;
    }

    void Update()
    {
        _position.y = Mathf.Lerp(_initialHeight, _initialHeight + _levitationHeight, _time);

        transform.position = _position;

        if (_goingUp) 
        {
            _time += Time.deltaTime * _levitationVelocity;

            if (_time >= 1.0f)
            {
                _goingUp = !_goingUp;
            }
        }
        else 
        {
            _time -= Time.deltaTime * _levitationVelocity;

            if (_time <= 0.0f)
            {
                _goingUp = !_goingUp;
            }
        }
    }
}