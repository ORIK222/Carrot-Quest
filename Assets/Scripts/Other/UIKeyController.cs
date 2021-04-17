using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKeyController : MonoBehaviour
{
    private Image[] _keyImages;

    private void Start()
    {
        _keyImages = new Image[transform.childCount];
        for (int i = 0; i < _keyImages.Length; i++)
        {
            _keyImages[i] = transform.GetChild(i).GetComponent<Image>();
            _keyImages[i].gameObject.SetActive(false);
        }
    }
}
