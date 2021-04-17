using UnityEngine;
using UnityEngine.UI;

public class Eyes : MonoBehaviour
{ 
    public Color ColorOn;
    public Color ColorOff;

    private Image _eyeImage;

    private void Start()
    {
        _eyeImage = GetComponent<Image>();
    }
    public void ChangeEyesColors(bool isEnabled)
    {
        if (isEnabled)
        { 
            _eyeImage.color = ColorOn;
        }
        else
        {
            _eyeImage.color = ColorOff;
        }
    }
}
