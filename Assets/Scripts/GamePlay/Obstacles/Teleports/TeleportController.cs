using UnityEngine;
using UnityEngine.Events;

public class TeleportController : MonoBehaviour
{
    public UnityEvent TeleportEvent;

    private Teleport _firstTeleport;
    private Teleport _secondTeleport;
    private Animator _rabbitAnimator;
    public void ToTeleport()
    {
        if (_firstTeleport.IsTouch == true)
        {
            _firstTeleport.IsTouch = false;
            _secondTeleport.IsTouch = true;
            Rabbit.rabbit.transform.position = _secondTeleport.transform.position;
            Rabbit.rabbit.IsMove = false;
        }
        else if (_secondTeleport.IsTouch == true)
        {
            _firstTeleport.IsTouch = true;
            _secondTeleport.IsTouch = false;
            Rabbit.rabbit.transform.position = _firstTeleport.transform.position;
            Rabbit.rabbit.IsMove = false;
        }
    }
    private void Start()
    {
        _firstTeleport = transform.GetChild(0).GetComponent<Teleport>();
        _secondTeleport = transform.GetChild(1).GetComponent<Teleport>();
    }


}
