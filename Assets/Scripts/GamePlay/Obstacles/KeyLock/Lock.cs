using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    public bool KeyIsPickUp = false;

    private AudioSource _audioSource;
    private Transform _lockModel;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _lockModel = transform.GetChild(0);
    }
    private void OnTriggerEnter(Collider collider)
    {
        Rabbit rabbit = collider.GetComponent<Rabbit>();
        if (rabbit)
        {
            if (_lockModel != null)
            {
                if (SoundSetting.IsSoundOn) _audioSource.Play();
                Destroy(_lockModel.gameObject);
            }
        }
    }
}
