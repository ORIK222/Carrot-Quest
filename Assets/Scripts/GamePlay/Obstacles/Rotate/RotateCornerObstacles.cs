using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCornerObstacles : MonoBehaviour
{   
    public bool IsWall;
    public bool IsRotate;  
    public static Vector3[] PossibleDirection = new Vector3[2];
    

    private Animator _animator;
    private AudioSource _audioSource;
    private Transform[] rotateWalls = new Transform[2];

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        rotateWalls[0] = transform.GetChild(0);
        rotateWalls[1] = transform.GetChild(2);
    }
    private void Update()
    {
        if (rotateWalls[0].GetComponent<RotateWall>().IsTouch || rotateWalls[1].GetComponent<RotateWall>().IsTouch)
            IsWall = true;
        else IsWall = false;
        if (transform.rotation.eulerAngles.y % 10 != 0) IsRotate = true;
        else IsRotate = false;
    }
    private void OnTriggerExit(Collider collider)
    {
        Rabbit rabbit = collider.GetComponent<Rabbit>();
        if (rabbit)
        {
            if (SoundSetting.IsSoundOn)_audioSource.Play();
            FindStartRotateNumber();
            ObstaclesChecker.obstaclesChecker.IsCornerRotate = false;
            ObstaclesChecker.obstaclesChecker.IsCornerRotateTouch = false;

        }
    }
    private void FindStartRotateNumber()
    {
        if (transform.rotation.y == 0)
        {
            _animator.SetTrigger("Rotate1");
        }
        if (transform.rotation.eulerAngles.y == 90)
        {
            _animator.SetTrigger("Rotate2");
        }
        if (transform.rotation.eulerAngles.y == 180)
        {
            _animator.SetTrigger("Rotate3");
        }
        if (transform.rotation.eulerAngles.y == 270)
        {
            _animator.SetTrigger("Rotate4");
        }
    }
}
