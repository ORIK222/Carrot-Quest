using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollLevelPanel : MonoBehaviour
{
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _backButton;

    private RectTransform[] _panels;
    private int _levelPanelsnumber;

    public void BackButtonClick()
    {
        var temp = _panels[0].anchoredPosition;
        _nextButton.interactable = true;
        for (int i = 0; i < _panels.Length; i++)
        {
            if (i != 0 && i != _panels.Length - 1)
                _panels[i].anchoredPosition = _panels[i + 1].anchoredPosition;
            else if (i == 0)
            {
                temp = _panels[i].anchoredPosition;
                _panels[i].anchoredPosition = _panels[i + 1].anchoredPosition;
            }
            else if (i == _panels.Length - 1)
            {
                _panels[i].anchoredPosition = temp;
            }
        }
        _levelPanelsnumber--;
    }
    public void NextButtonClick()
    {
        var temp = _panels[0].anchoredPosition;
        _backButton.interactable = true;
        for (int i = _panels.Length - 1; i >= 0; i--)
        {
            if (i != 0 && i != _panels.Length - 1)
                _panels[i].anchoredPosition = _panels[i - 1].GetComponent<RectTransform>().anchoredPosition;
            else if (i == 0)
            {
                _panels[i].anchoredPosition = temp;
            }
            else if (i == _panels.Length - 1)
            {
                temp = _panels[i].anchoredPosition;
                _panels[i].anchoredPosition = _panels[i - 1].anchoredPosition;
            }
        }
        _levelPanelsnumber++;
    }

    private void Start()
    {
        _backButton.interactable = false;
        _levelPanelsnumber = 1;
        PanelsInit();
    }
    private void Update()
    {
        if (_levelPanelsnumber == 1) _backButton.interactable = false;
        if (_levelPanelsnumber == 4) _nextButton.interactable = false;
    }

    private void PanelsInit()
    {
        _panels = new RectTransform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            _panels[i] = transform.GetChild(i).GetComponent<RectTransform>();
        }
    }

}
