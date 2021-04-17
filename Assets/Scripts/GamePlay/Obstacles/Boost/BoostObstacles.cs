using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DirectionMoveChecker;

public class BoostObstacles : MonoBehaviour
{
    public static bool IsBoost = false;
    public static Vector3 BoostDirection;

    private AudioSource _audioSource;
    private Rabbit _rabbit;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        _rabbit = collider.GetComponent<Rabbit>();
        if (_rabbit)
        {
            if(SoundSetting.IsSoundOn)_audioSource.Play();
            Boost();
            IsBoost = true;
        }
    }
    private void Boost()
    {
        switch (transform.rotation.eulerAngles.y)
        {
            case 0:
                {
                    BoostDirection = new Vector3(-1, 0, 0);
                    break;
                }
            case 90:
                {
                    BoostDirection = new Vector3(0, 0, 1);
                    break;
                }
            case 180:
                {
                    BoostDirection = new Vector3(1, 0, 0);
                    break;
                }
            case 270:
                {
                    BoostDirection = new Vector3(0, 0, -1);
                    break;
                }
            default:
                {
                    Debug.Log(transform.rotation.eulerAngles.y);
                    break;
                }
        }
    }
}
