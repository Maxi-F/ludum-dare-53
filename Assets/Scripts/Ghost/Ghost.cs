using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ghost : MonoBehaviour, GhostInterface
{
    [SerializeField] private Pickable _expectedPickableObject;
    [SerializeField] private Ghost _nextGhost;
    [SerializeField] private TextMeshProUGUI _ghostText;
    [SerializeField] public string wantedObjectDescription;

    private bool _isHudCleanupExecuting = false;

    public void ObtainObject(Pickable heldObject)
    {
        if (ReferenceEquals(_expectedPickableObject.gameObject, heldObject.gameObject))
        {
            _nextGhost.gameObject.SetActive(true);
            gameObject.SetActive(false);
            _ghostText.text = "Correct Item! Next ghost awaiting...";
            _nextGhost.CallCleanup();
            
        } else
        {
            _ghostText.text = "This was not the wanted item...";
            CallCleanup();
        }
    }

    public void CallCleanup()
    {
        StartCoroutine(CleanupHudMessage());
    }

    private IEnumerator CleanupHudMessage()
    {
        if (_isHudCleanupExecuting)
            yield break;

        _isHudCleanupExecuting = true;

        yield return new WaitForSeconds(5);

        _ghostText.text = "";

        _isHudCleanupExecuting = false;
    }
}
