using UnityEngine;

public class DirectionMoveChecker : MonoBehaviour
{
    protected float _speed;
    protected float _distance = 1;
    protected Vector3 _direction = Vector3.zero;

    public void CheckArrowsDirection(int type)
    {
        if (!EyeChangeController.eyeChangeController.IsEyes && !ObstaclesChecker.obstaclesChecker.IsBoost && !Rabbit.rabbit.IsMove)
        {
            ObstaclesChecker.obstaclesChecker.IsGrass = false;
            if (type == (int)Direction.UP)
            {
                Rabbit.rabbit._direction = new Vector3(-Rabbit.rabbit._distance, 0, 0);
                if (!Rabbit.rabbit.IsMove) Rabbit.rabbit.TargetPosition = Rabbit.rabbit.transform.position + Rabbit.rabbit._direction;
                Rabbit.rabbit.IsMove = true;
            }
            if (type == (int)Direction.DOWN)
            {
                Rabbit.rabbit._direction = new Vector3(Rabbit.rabbit._distance, 0, 0);
                if (!Rabbit.rabbit.IsMove) Rabbit.rabbit.TargetPosition = Rabbit.rabbit.transform.position + Rabbit.rabbit._direction;
                Rabbit.rabbit.IsMove = true;
            }
            if (type == (int)Direction.RIGHT)
            {
                Rabbit.rabbit._direction = new Vector3(0, 0, Rabbit.rabbit._distance);
                if (!Rabbit.rabbit.IsMove) Rabbit.rabbit.TargetPosition = Rabbit.rabbit.transform.position + Rabbit.rabbit._direction;
                Rabbit.rabbit.IsMove = true;
            }
            if (type == (int)Direction.LEFT)
            {
                Rabbit.rabbit._direction = new Vector3(0, 0, -Rabbit.rabbit._distance);
                if (!Rabbit.rabbit.IsMove) Rabbit.rabbit.TargetPosition = Rabbit.rabbit.transform.position + Rabbit.rabbit._direction;
                Rabbit.rabbit.IsMove = true;
            }
            StepCounter.stepCounter.Count++;
        }
    }
    private void OnDisable()
    {
        SwipeController.SwipeEvent -= CheckSwipe;
    }
    protected void CheckSwipe(SwipeController.SwipeType type)
    {
        if (!EyeChangeController.eyeChangeController.IsEyes && !ObstaclesChecker.obstaclesChecker.IsBoost && !Rabbit.rabbit.IsMove)
        {
            ObstaclesChecker.obstaclesChecker.IsGrass = false;
            if (type == SwipeController.SwipeType.UP)
            {
                _direction = new Vector3(-_distance, 0, 0);
                if (!Rabbit.rabbit.IsMove) Rabbit.rabbit.TargetPosition = transform.position + _direction;
                Rabbit.rabbit.IsMove = true;
            }
            if (type == SwipeController.SwipeType.DOWN)
            {
                _direction = new Vector3(_distance, 0, 0);
                if (!Rabbit.rabbit.IsMove) Rabbit.rabbit.TargetPosition = transform.position + _direction;
                Rabbit.rabbit.IsMove = true;
            }
            if (type == SwipeController.SwipeType.RIGHT)
            {
                _direction = new Vector3(0, 0, _distance);
                if (!Rabbit.rabbit.IsMove) Rabbit.rabbit.TargetPosition = transform.position + _direction;
                Rabbit.rabbit.IsMove = true;
            }
            if (type == SwipeController.SwipeType.LEFT)
            {
                _direction = new Vector3(0, 0, -_distance);
                if (!Rabbit.rabbit.IsMove) Rabbit.rabbit.TargetPosition = transform.position + _direction;
                Rabbit.rabbit.IsMove = true;
            }
            StepCounter.stepCounter.Count++;
        }
    }
}
public enum Direction
{
    UP,
    DOWN,
    RIGHT,
    LEFT
}




