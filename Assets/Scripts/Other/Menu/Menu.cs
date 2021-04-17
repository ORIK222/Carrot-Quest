using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private LevelData _levelData;
    public void Play()
    {
        SceneManager.LoadScene("Select Level");
    }
    public void StoreOpen()
    {
        SceneManager.LoadScene("Store");
    }
    private void Start()
    {
        Time.timeScale = 1f;
    }
}
