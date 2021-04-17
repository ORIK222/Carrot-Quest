using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RedButton : MonoBehaviour
{
    public UnityEvent isPress;
    public bool IsPressed = false;

    private Transform[] _buttonStates = new Transform[2];
    private Transform[] _allParallelRotateObstacles;
    private Transform[] _allCornerRotateObstacles;
    private AudioSource _audioSource;
    public void RotateObstacles()
    {
        if (SoundSetting.IsSoundOn) _allParallelRotateObstacles[0].GetComponent<AudioSource>().Play();
        for (int i = 0; i < _allParallelRotateObstacles.Length; i++)
        {
                if (_allParallelRotateObstacles[i].transform.rotation.eulerAngles.y == 0)
                {
                    _allParallelRotateObstacles[i].GetComponent<RotationObstacle>().IsTouch = true;
                    _allParallelRotateObstacles[i].GetComponent<Animator>().SetTrigger("Rotate");
                }
                else if (_allParallelRotateObstacles[i].transform.rotation.eulerAngles.y == -90)
                {
                    _allParallelRotateObstacles[i].GetComponent<RotationObstacle>().IsTouch = false;
                    _allParallelRotateObstacles[i].GetComponent<Animator>().SetTrigger("Rotate1");
            }
                else if(_allParallelRotateObstacles[i].GetComponent<RotationObstacle>().IsTouch == false)
                {
                    _allParallelRotateObstacles[i].GetComponent<RotationObstacle>().IsTouch = true;
                    _allParallelRotateObstacles[i].GetComponent<Animator>().SetTrigger("Rotate");
            }
                else if (_allParallelRotateObstacles[i].GetComponent<RotationObstacle>().IsTouch == true)
                {
                    _allParallelRotateObstacles[i].GetComponent<RotationObstacle>().IsTouch = false;
                    _allParallelRotateObstacles[i].GetComponent<Animator>().SetTrigger("Rotate1");
            }
        }
        for (int i = 0; i < _allCornerRotateObstacles.Length; i++)
        {
            _allCornerRotateObstacles[0].GetComponent<AudioSource>().Play();
            if (_allCornerRotateObstacles[i].transform.rotation.eulerAngles.y == 0)
                _allCornerRotateObstacles[i].GetComponent<Animator>().SetTrigger("Rotate1");            
            if (_allCornerRotateObstacles[i].transform.rotation.eulerAngles.y == 90)
                _allCornerRotateObstacles[i].GetComponent<Animator>().SetTrigger("Rotate2"); 
            if (_allCornerRotateObstacles[i].transform.rotation.eulerAngles.y == 180)
                _allCornerRotateObstacles[i].GetComponent<Animator>().SetTrigger("Rotate3");
            if (_allCornerRotateObstacles[i].transform.rotation.eulerAngles.y == 270)
                _allCornerRotateObstacles[i].GetComponent<Animator>().SetTrigger("Rotate4");
        }
    }

    private void Awake()
    {
        _allParallelRotateObstacles = new Transform[FindObjectsOfType<RotationObstacle>().Length];
        _allCornerRotateObstacles = new Transform[FindObjectsOfType<RotateCornerObstacles>().Length];
        _audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        MakeTransform();
    }
    private void Update()
    {
        _buttonStates[0].gameObject.SetActive(IsPressed);
        _buttonStates[1].gameObject.SetActive(!IsPressed);
    }
    private void OnTriggerEnter()
    {
        if (!IsPressed)
        {
            RedButtonsController.IsTouch = true;
            if(SoundSetting.IsSoundOn)_audioSource.Play();
            isPress.Invoke();
        }
    }
    private void MakeTransform()
    {
        for (int i = 0; i < _buttonStates.Length; i++)
        {
            _buttonStates[i] = transform.GetChild(i);
        }
        for (int i = 0; i < _allParallelRotateObstacles.Length; i++)
        {
            _allParallelRotateObstacles[i] = FindObjectsOfType<RotationObstacle>()[i].transform;
        }
        for (int i = 0; i < _allCornerRotateObstacles.Length; i++)
        {
            _allCornerRotateObstacles[i] = FindObjectsOfType<RotateCornerObstacles>()[i].transform;
        }
    }

}
