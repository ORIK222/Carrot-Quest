using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Carrot : MonoBehaviour
{
    private AudioSource _audioSource;
    private Transform _carrots;

    private void Start()
    {
        _carrots = transform.GetChild(0);
        _audioSource = GetComponent<AudioSource>();
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        Rabbit rabbit = collider.gameObject.GetComponent<Rabbit>();
        if (rabbit)
        {
            if (_carrots != null)
            {
                if(SoundSetting.IsSoundOn)_audioSource.Play();
                CarrotsCounter.carrotsCounter.Count--;
                if (CarrotsCounter.carrotsCounter.Count == 0) WinController.winController.IsWin = true;
                Destroy(_carrots.gameObject);
            }
        }
    }

}
