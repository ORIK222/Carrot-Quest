using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComingSoon : MonoBehaviour
{
    [SerializeField] private GameObject _comingSoonPanel;

    private bool IsOpen;

    public void OpenComingSoonPanel()
    {
        IsOpen = !IsOpen;
        _comingSoonPanel.SetActive(IsOpen);
    }

    private void Start()
    {
        IsOpen = false;
    }
    

}
