using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButtonsController : MonoBehaviour
{    
    public static bool IsTouch = false;
    
    private Transform[] _redButtons;

    private void Start()
    {
        _redButtons = new Transform[transform.childCount];
        MakeTransform();
    }
    private void Update()
    {
        if (IsTouch)
        {
            var temp = _redButtons[0].transform.GetChild(0).GetComponent<RedButton>().IsPressed;
            for (int i = 0; i < _redButtons[0].transform.childCount; i++)
            {
                _redButtons[0].transform.GetChild(i).GetComponent<RedButton>().IsPressed = !temp;
            }
            if(_redButtons.Length>1)
            {
                for (int i = 0; i < _redButtons[1].transform.childCount; i++)
                {
                    _redButtons[1].transform.GetChild(i).GetComponent<RedButton>().IsPressed = temp;
                }
            }
            IsTouch = false;
        }
    }
    private void MakeTransform()
    {
        for (int i = 0; i < _redButtons.Length; i++)
        {
            _redButtons[i] = transform.GetChild(i);
        }
    }
}
