using System;
using UnityEngine;
using UnityEngine.UI;

public class Step : MonoBehaviour
{
    public Text StepResult;

    private void Start()
    {
        StepResult.text = String.Empty;
    }
    private void Update()
    {
        if(WinController.winController.IsWin)
        StepCountChange();
    }
    private void StepCountChange()
    {
        StepResult.text = "Steps count: " + StepCounter.stepCounter.Count.ToString("F0");
    }
}
