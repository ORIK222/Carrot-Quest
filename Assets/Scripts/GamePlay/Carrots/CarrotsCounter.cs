using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotsCounter : MonoBehaviour
{
    public static CarrotsCounter carrotsCounter;
    public int Count = 0;

    private void Awake()
    {
        carrotsCounter = this;
    }

    private void Start()
    {
        Count = transform.childCount;
    }
}
