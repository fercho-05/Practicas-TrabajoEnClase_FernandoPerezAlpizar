using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    Transform _destination;


    bool _isTeleporting;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            if (_isTeleporting)
            {
                return;
            }

            _isTeleporting = true;
            PortalController portal = other.GetComponent<PortalController>();
            _destination = portal.GetDestination();

            CharacterController character = FindObjectOfType<Character3DController>().GetCharacterController();
            character.enabled = false;
            character.transform.position = _destination.position;
            character.enabled = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_destination != null)
        {
            if (other.transform.position == _destination.position)
            {
                _isTeleporting = false;
            }
        }
        
    }
}
