using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private Animator _animator;
    private int _temp = 0;

    private void OnTriggerEnter(Collider collider)
    {
        Rabbit rabbit = collider.GetComponent<Rabbit>();
        
        if(rabbit && WinController.winController.IsWin)
        {
            WinController.winController.WinResult();
        }
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (CarrotsCounter.carrotsCounter.Count == 0 && _temp < 1)
        {
            _temp++;
            _animator.SetTrigger("Win");
        }
    }
}
