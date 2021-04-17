using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSetting : MonoBehaviour
{    
    public static bool IsMusicOn = true;

    [SerializeField] private Button _musicButton;
    [SerializeField] private Sprite _onMusic;
    [SerializeField] private Sprite _offMusic;


    public void OnOffMusic()
    {
        IsMusicOn = !IsMusicOn;
        if (IsMusicOn)
        {
            _musicButton.image.sprite = _onMusic;
        }
        else
        {
            _musicButton.image.sprite = _offMusic;
        }
    }

    private void Update()
    {
        if (IsMusicOn)
            _musicButton.image.sprite = _onMusic;
        else
            _musicButton.image.sprite = _offMusic;
    }

}
