using UnityEngine;

public class RotationObstacle : MonoBehaviour
{
    public bool IsTouch = true;
    public bool IsRotate = false;
    public bool IsWall;

    public static Vector3 PossibleDirection;

    private Transform[] rotateWalls = new Transform[2];
    private Animator _animator;
    private AudioSource _audioSource;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        if (transform.rotation.y == 0) IsTouch = false;
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
        if(rabbit)
        {
            if (SoundSetting.IsSoundOn) _audioSource.Play();
            if (!IsTouch)
            {
                _animator.SetTrigger("Rotate");
                IsTouch = !IsTouch;
            }
            else
            {
                _animator.SetTrigger("Rotate1");
                IsTouch = !IsTouch;
            }
            ObstaclesChecker.obstaclesChecker.IsParallelRotate = false;
        }
    }
}
