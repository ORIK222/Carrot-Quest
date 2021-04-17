using UnityEngine;
using UnityEngine.UI;

public class KeyImagePanel : MonoBehaviour
{    
    public static KeyImagePanel keyImagePanel;
    public bool IsEmpty = false;
    private Image[] _keyImages;


    private void Awake()
    {
        keyImagePanel = this;
        InitKeyImage();
    } 
    
    public void DisableImage(int imageIndex)
    {
            transform.GetChild(imageIndex).gameObject.SetActive(false);
    }
    private void InitKeyImage()
    {
        var keyCount = FindObjectsOfType<Key>().Length;
        var keys = FindObjectsOfType<Key>();
        if (keys != null)
        {
            _keyImages = new Image[transform.childCount];

            for (int i = keyCount; i < transform.childCount; i++)
            {
                _keyImages[i] = transform.GetChild(i).GetComponent<Image>();
                Destroy(_keyImages[i].gameObject);
            }
            for (int i = 0; i < keyCount; i++)
            {
                _keyImages[i] = transform.GetChild(i).GetComponent<Image>();
                _keyImages[i].color = keys[i].transform.GetChild(0).GetComponent<Renderer>().material.color;
            }
        }
        else IsEmpty = true;

    }
   
}
