using UnityEngine;

class CameraController : MonoBehaviour
{
    private float _speed = 2f;
    private Transform _target;
    private Vector3 _rotation;

    private void Start()
    {
        if (!_target) _target = FindObjectOfType<Rabbit>().transform;
        _rotation = transform.rotation.eulerAngles;
    }
    private void Update()
    {
        if (!EyeChangeController.eyeChangeController.IsEyes)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_rotation),_speed * Time.deltaTime);
            var position = _target.position; position.y += 3f; position.x += 3f;
            transform.position = Vector3.Lerp(transform.position, position, _speed * Time.deltaTime);
        }
        else
        {
            var position = transform.position; position.y = 8;
            transform.position = Vector3.Lerp(transform.position, position, _speed * Time.deltaTime);
            var rotation = new Vector3(90, -90, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotation), _speed * Time.deltaTime);
        }
    }
}