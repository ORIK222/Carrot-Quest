using System.Collections.Generic;
using UnityEngine;

public class InstanceRabbit : MonoBehaviour
{
    [SerializeField] private List<GameObject> _characters;

    private void Awake()
    {
        CreateCharacter();
    }
    private void CreateCharacter()
    {
        Instantiate(_characters[2], new Vector3(transform.position.x, 0.5f, transform.position.z), Quaternion.identity);
    }
}
