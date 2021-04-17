using UnityEngine;

public class ObstaclesChecker : MonoBehaviour
{
    public bool IsCornerRotateTouch;
    public bool IsGrass;
    public bool IsParallelRotate = false;
    public bool IsCornerRotate = false;
    public bool IsBoost = false;

    public static ObstaclesChecker obstaclesChecker;

    private Transform[] _allGrass;
    private RotationObstacle[] _allParallelRotateObstacles;
    private RotateCornerObstacles[] _allCornerRotateObstacles;
    private Lock[] _allLockObstacles;

    public void CheckObstacles()
    {
        CheckObstaclesDistance();
        if (IsParallelRotate && RotationObstacle.PossibleDirection 
            != Rabbit.rabbit.Direction && RotationObstacle.PossibleDirection 
            != -Rabbit.rabbit.Direction)
        {
            Rabbit.rabbit.IsMove = false;
        }
        if (IsCornerRotate && RotateCornerObstacles.PossibleDirection[0] 
            != Rabbit.rabbit.Direction && RotateCornerObstacles.PossibleDirection[1] 
            != Rabbit.rabbit.Direction)
        {
            Rabbit.rabbit.IsMove = false;
        }
        if (IsGrass)
        {
            Rabbit.rabbit.IsMove = false;
        }
    }

    private void Awake()
    {
        _allGrass = new Transform[FindObjectsOfType<Grass>().Length];
        _allParallelRotateObstacles = new RotationObstacle[FindObjectsOfType<RotationObstacle>().Length];
        _allCornerRotateObstacles = new RotateCornerObstacles[FindObjectsOfType<RotateCornerObstacles>().Length];
        _allLockObstacles = new Lock[FindObjectsOfType<Lock>().Length];
        obstaclesChecker = this;
    }
    private void Start()
    {
        MakeTransformAllObstacles();
    }
    private void MakeTransformAllObstacles()
    {
        for (int i = 0; i < _allGrass.Length; i++)
        {
            _allGrass[i] = FindObjectsOfType<Grass>()[i].transform;
        }
        for (int i = 0; i < _allParallelRotateObstacles.Length; i++)
        {
            _allParallelRotateObstacles[i] = FindObjectsOfType<RotationObstacle>()[i].GetComponent<RotationObstacle>();
        }
        for (int i = 0; i < _allCornerRotateObstacles.Length; i++)
        {
            _allCornerRotateObstacles[i] = FindObjectsOfType<RotateCornerObstacles>()[i].GetComponent<RotateCornerObstacles>();
        }
        for (int i = 0; i < _allLockObstacles.Length; i++)
        {
            _allLockObstacles[i] = FindObjectsOfType<Lock>()[i].GetComponent<Lock>();
        }
    }
    private void CheckObstaclesDistance()
    {
        for (int i = 0; i < _allGrass.Length; i++)
        {
            if (Vector3.Distance(Rabbit.rabbit.TargetPosition, _allGrass[i].position) < 0.65f)
            {
                IsGrass = true;
            }
        }
        for (int i = 0; i < _allParallelRotateObstacles.Length; i++)
        {
            if (Vector3.Distance(Rabbit.rabbit.TargetPosition, _allParallelRotateObstacles[i].transform.position) < 0.5f)
            {
                if (_allParallelRotateObstacles[i].IsWall || _allParallelRotateObstacles[i].IsRotate)
                {
                    IsGrass = true;
                }
            }
        }
        for (int i = 0; i < _allCornerRotateObstacles.Length; i++)
        {
            if (Vector3.Distance(Rabbit.rabbit.TargetPosition, _allCornerRotateObstacles[i].transform.position) < 0.5f)
            {
                if (_allCornerRotateObstacles[i].IsWall || _allCornerRotateObstacles[i].IsRotate)
                {
                    IsGrass = true;
                }
            }
        }
        for (int i = 0; i < _allLockObstacles.Length; i++)
        {
            if (_allLockObstacles[i] != null)
            {
                if (Vector3.Distance(Rabbit.rabbit.TargetPosition, _allLockObstacles[i].transform.position) < 0.65f && !_allLockObstacles[i].KeyIsPickUp)
                {
                    IsGrass = true;
                }
            }
        }
    }
}
