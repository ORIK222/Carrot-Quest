using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{    
    public static bool IsSoundOn = true;

    [SerializeField] private Button _soundButton;
    [SerializeField] private Sprite _onSound;
    [SerializeField] private Sprite _offSound;
 
    public void OnOffSound()
    {
        IsSoundOn = !IsSoundOn;
        if (IsSoundOn)
        {
            _soundButton.image.sprite = _onSound;
        }
        else
        {
            _soundButton.image.sprite = _offSound;
        }
    }
    private void Update()
    {
        if (IsSoundOn)
            _soundButton.image.sprite = _onSound;
        else
            _soundButton.image.sprite = _offSound;
    }
   
}
