using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeChangeController : MonoBehaviour
{
    public bool IsEyes = false;

    public static EyeChangeController eyeChangeController;
    private void Start()
    {
        eyeChangeController = this;
    }

    public void ChangeEyesState()
    {
        var eyes = transform.GetChild(0).GetComponent<Eyes>();
        IsEyes = !IsEyes;
        eyes.ChangeEyesColors(IsEyes);
    }
}
