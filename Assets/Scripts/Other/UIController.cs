using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _arrowsPanel;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        if (!Setting.IsSwipeOn) _arrowsPanel.SetActive(true);
        else _arrowsPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
