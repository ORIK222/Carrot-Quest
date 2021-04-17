using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{   
    public static bool IsSwipeOn;

    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private Toggle _swipeToggle;
    [SerializeField] private Toggle _arrowsToggle;
    
    private bool _isSetting;
    private int _toggleNumber = 0;

    public void OpenSetting()
    {
        PlayerPrefs.SetInt("ToggleNumber", _toggleNumber);
        _isSetting = !_isSetting;
        _settingPanel.SetActive(_isSetting);
    }

    private void Start()
    {
        _toggleNumber = PlayerPrefs.GetInt("ToggleNumber");
        if (_toggleNumber == 0) _toggleNumber = 1; 
        if (_toggleNumber == 1)
        {
            IsSwipeOn = true;
            _swipeToggle.isOn = true;
            _arrowsToggle.isOn = false;
        }
        else
        {
            IsSwipeOn = false;
            _arrowsToggle.isOn = true;
            _swipeToggle.isOn = false;
        }

        _isSetting = false;
        _settingPanel.SetActive(false);
    }
    private void Update()
    {
        if (_swipeToggle.isOn)
        {
            IsSwipeOn = true;
            _toggleNumber = 1;
        }
        else
        {
            _toggleNumber = 2;
            IsSwipeOn = false;
        }
    }

}
