using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class YellowButton : MonoBehaviour
{
    public UnityEvent isPress;
    public bool IsPressed = false;

    private Transform[] _buttonStates = new Transform[2];
    private Transform[] _allBoostObstacles;
    private AudioSource _audioSource;

    public void RotateObstacles()
    {
        for (int i = 0; i < _allBoostObstacles.Length; i++)
        {
            if (_allBoostObstacles[i].transform.rotation.eulerAngles.y == 0)
                _allBoostObstacles[i].transform.rotation = Quaternion.Euler(0, 180, 0);
            else if (_allBoostObstacles[i].transform.rotation.eulerAngles.y == 90)
                _allBoostObstacles[i].transform.rotation = Quaternion.Euler(0, 270, 0);
            else if (_allBoostObstacles[i].transform.rotation.eulerAngles.y == 180)
                _allBoostObstacles[i].transform.rotation = Quaternion.Euler(0, 0, 0);
            else if (_allBoostObstacles[i].transform.rotation.eulerAngles.y == 270)
                _allBoostObstacles[i].transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }

    private void Awake()
    {
        _allBoostObstacles = new Transform[FindObjectsOfType<BoostObstacles>().Length];
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
            YellowButtonController.IsTouch = true;
            if(SoundSetting.IsSoundOn) _audioSource.Play();
            isPress.Invoke();
        }
    }
    private void MakeTransform()
    {
        for (int i = 0; i < _buttonStates.Length; i++)
        {
            _buttonStates[i] = transform.GetChild(i);
        }
        for (int i = 0; i < _allBoostObstacles.Length; i++)
        {
            _allBoostObstacles[i] = FindObjectsOfType<BoostObstacles>()[i].transform;
        }
    }

}
