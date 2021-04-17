using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowButtonController : MonoBehaviour
{    
    public static bool IsTouch = false;

    private Transform[] _yellowButtons;

    private void Start()
    {
        _yellowButtons = new Transform[transform.childCount];
        MakeTransform();
    }
    private void Update()
    {
        if (IsTouch)
        { 
            var temp = _yellowButtons[0].transform.GetChild(0).GetComponent<YellowButton>().IsPressed;
            for (int i = 0; i < _yellowButtons[0].transform.childCount; i++)
                _yellowButtons[0].transform.GetChild(i).GetComponent<YellowButton>().IsPressed = !temp;
            if (_yellowButtons.Length > 1)
            {
                for (int i = 0; i < _yellowButtons[1].transform.childCount; i++)
                    _yellowButtons[1].transform.GetChild(i).GetComponent<YellowButton>().IsPressed = temp;
            }
            IsTouch = false;
        }
    }
    private void MakeTransform()
    {
        for (int i = 0; i < _yellowButtons.Length; i++)
        {
            _yellowButtons[i] = transform.GetChild(i);
        }
    }
}
