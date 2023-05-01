using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ghost : MonoBehaviour, GhostInterface
{
    [SerializeField] private Pickable _expectedPickableObject;
    [SerializeField] private Ghost _nextGhost;
    [SerializeField] private ObjectDescription _ghostMessageSender;
    [SerializeField] public string wantedObjectDescription;
    [SerializeField] private string _expectedGivenObjectDescription;
    [SerializeField] private string _notExpectedGivenObjectDescription;

    public void ObtainObject(Pickable heldObject)
    {
        if (ReferenceEquals(_expectedPickableObject.gameObject, heldObject.gameObject))
        {
            ReceivedExpectedObject();
        } else
        {
            _ghostMessageSender.ShowDescription(_notExpectedGivenObjectDescription);
            heldObject.Appear();
        }
    }

    private void ReceivedExpectedObject()
    {
            _ghostMessageSender.ShowDescription(_expectedGivenObjectDescription, "", _nextGhost == null);
            if(_nextGhost != null)
            {
                _nextGhost.gameObject.SetActive(true);
                gameObject.SetActive(false);
            }
    }
}
