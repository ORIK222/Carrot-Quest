using UnityEngine;

public class Rabbit : DirectionMoveChecker
{
    public static Rabbit rabbit;
    public bool IsMove;

    private Vector3 _targetPosition = Vector3.zero;

    public Vector3 TargetPosition
    {
        get  => _targetPosition;
        set { _targetPosition = value;}
    }
    public Vector3 Direction => _direction;

    private void Start()
    {
        if(Setting.IsSwipeOn) SwipeController.SwipeEvent += CheckSwipe;
        StartData();
    }
    private void FixedUpdate()
    {
        Move();
    }    
    private void Move()
    {
        ObstaclesChecker.obstaclesChecker.CheckObstacles();

        if (_direction != Vector3.zero && IsMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
        }
        if (Vector3.Angle(Vector3.forward, _direction) > 1f || Vector3.Angle(Vector3.forward, _direction) == 0)
        {
            Vector3 rotate = Vector3.RotateTowards(transform.forward, _direction, 3, 0.0f);
            transform.rotation = Quaternion.LookRotation(rotate);
        }
        if (transform.position == _targetPosition)
        {
            if (BoostObstacles.IsBoost)
            {
                BoostObstacles.IsBoost = false;
                _direction = BoostObstacles.BoostDirection;
                _targetPosition = transform.position + _direction;
                ObstaclesChecker.obstaclesChecker.IsBoost = true;
                Move();
            }
            else
            {
                _direction = Vector3.zero;
                IsMove = false;
                ObstaclesChecker.obstaclesChecker.IsBoost = false;
            }
            if (ObstaclesChecker.obstaclesChecker.IsCornerRotateTouch) ObstaclesChecker.obstaclesChecker.IsCornerRotate = true;
        }

    }
    private void OnTriggerEnter(Collider collider)
    {
        RotationObstacle rotationObstacle = collider.GetComponent<RotationObstacle>();
        if (rotationObstacle)
        {
            RotationObstacle.PossibleDirection = _direction;
            ObstaclesChecker.obstaclesChecker.IsParallelRotate = true;
        }
        RotateCornerObstacles rotateCornerObstacles = collider.GetComponent<RotateCornerObstacles>();
        if (rotateCornerObstacles)
        {
            if (rotateCornerObstacles.transform.rotation.eulerAngles.y == 0)
            {
                RotateCornerObstacles.PossibleDirection[0] = new Vector3(1, 0, 0);
                RotateCornerObstacles.PossibleDirection[1] = new Vector3(0, 0, -1);
            }
            else if (rotateCornerObstacles.transform.rotation.eulerAngles.y == 90)
            {
                RotateCornerObstacles.PossibleDirection[0] = new Vector3(-1, 0, 0);
                RotateCornerObstacles.PossibleDirection[1] = new Vector3(0, 0, -1);
            }
            else if (rotateCornerObstacles.transform.rotation.eulerAngles.y == 180)
            {
                RotateCornerObstacles.PossibleDirection[0] = new Vector3(-1, 0, 0);
                RotateCornerObstacles.PossibleDirection[1] = new Vector3(0, 0, 1);
            }
            else if (rotateCornerObstacles.transform.rotation.eulerAngles.y == 270)
            {
                RotateCornerObstacles.PossibleDirection[0] = new Vector3(1, 0, 0);
                RotateCornerObstacles.PossibleDirection[1] = new Vector3(0, 0, 1);
            }
            ObstaclesChecker.obstaclesChecker.IsCornerRotateTouch = true;
        }
    }
    private void StartData()
    {
        rabbit = this;
        _targetPosition = transform.position;
        _direction = Vector3.zero;
        IsMove = false;
        _distance = 1f;
        _speed = 5f;
    }
}