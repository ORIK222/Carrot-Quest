using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepCounter : MonoBehaviour
{
    private int _count = 0;
    public int Count
    {
        get => _count;
        set 
        {
            _count = value;
        }
    }
    public static StepCounter stepCounter;

    private void Awake()
    {
        stepCounter = this;
    }
}
