using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    public static int countComlpleteLevel = 1;

    [SerializeField] private Sprite _lockedSprite;
    [SerializeField] private Sprite _unlockedSprite;

    private void Start()
    {
        if (PlayerPrefs.GetInt("LevelCount") > 1)
            countComlpleteLevel = PlayerPrefs.GetInt("LevelCount");
        else countComlpleteLevel = 1;
       LevelUnlocked();
    }
    private void LevelUnlocked()
    {
        var temp = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            for (int j = 0; j < transform.GetChild(i).transform.childCount; j++)
            {
                if (temp < countComlpleteLevel)
                {
                    var level = transform.GetChild(i).transform.GetChild(j);
                    level.GetComponent<Image>().sprite = _unlockedSprite;
                    level.GetComponent<Button>().interactable = true;
                    level.transform.GetChild(0).GetComponent<Text>().text = (++temp).ToString(); temp--;
                }
                else
                {
                    transform.GetChild(i).transform.GetChild(j).GetComponent<Image>().sprite = _lockedSprite;
                    transform.GetChild(i).transform.GetChild(j).GetComponent<Button>().interactable = false;
                    transform.GetChild(i).transform.GetChild(j).transform.GetChild(0).GetComponent<Text>().text = (++temp).ToString(); temp--;
                }
                temp++;
            }
        }
    }
}
