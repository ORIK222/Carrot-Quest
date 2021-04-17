using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{    
    public bool IsTouch;

    [SerializeField] private TeleportController _teleportController;

    private void OnTriggerEnter(Collider collider)
    {
        Rabbit rabbit = collider.GetComponent<Rabbit>();
        if(rabbit && !IsTouch)
        {
            IsTouch = true;
            _teleportController.TeleportEvent.Invoke();
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        Rabbit rabbit = collider.GetComponent<Rabbit>();
        if(rabbit) IsTouch = false;
    }
}
