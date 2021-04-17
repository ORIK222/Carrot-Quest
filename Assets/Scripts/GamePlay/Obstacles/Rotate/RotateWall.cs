using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWall : MonoBehaviour
{
    public bool IsTouch = false;
    private void OnTriggerEnter(Collider collider)
    {
        Rabbit rabbit = collider.GetComponent<Rabbit>();
        if(rabbit)
        {
            IsTouch = true;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        Rabbit rabbit = collider.GetComponent<Rabbit>();
        if (rabbit)
        {
            IsTouch = false;
        }
    }
}
