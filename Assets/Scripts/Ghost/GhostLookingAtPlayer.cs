using UnityEngine;

public class GhostLookingAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
        
    void LateUpdate()
    {
        if (_playerTransform != null)
        {
            transform.LookAt(_playerTransform);

            transform.eulerAngles = new Vector3(0.0f, transform.eulerAngles.y, 0.0f);
        }
    }
}