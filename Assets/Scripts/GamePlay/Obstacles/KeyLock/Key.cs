using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    private AudioSource _audioSource;
    private Color _color;
    private Image _keyImage;
    private Transform _keyModel;
    public Image KeyImage => _keyImage;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _keyModel = transform.GetChild(0);
        _color = transform.GetChild(0).GetComponent<Renderer>().material.color;
        FindKeyImage();
    }
    private void OnTriggerEnter(Collider collider)
    {
        Rabbit rabbit = collider.GetComponent<Rabbit>();        
        if(rabbit)
        {
            if (_keyModel != null)
            {
                if (SoundSetting.IsSoundOn) _audioSource.Play();
                _keyImage?.gameObject.SetActive(true);
                Destroy(_keyModel.gameObject);
            }
        }
    }
    private void FindKeyImage()
    {
        var keyImageCount = KeyImagePanel.keyImagePanel.transform.childCount;
        KeyImage[] keyImages = new KeyImage[keyImageCount];
        if (!KeyImagePanel.keyImagePanel.IsEmpty)
        {
            for (int i = 0; i < keyImageCount; i++)
            {
                keyImages[i] = KeyImagePanel.keyImagePanel.transform.GetChild(i).GetComponent<KeyImage>();
            }
            for (int i = 0; i < keyImageCount; i++)
            {
                if (keyImages[i].GetComponent<Image>().color == _color)
                {
                    _keyImage = keyImages[i].GetComponent<Image>();
                    KeyImagePanel.keyImagePanel.DisableImage(i);
                    return;
                }
            }
        }
        else return;
    }
}
