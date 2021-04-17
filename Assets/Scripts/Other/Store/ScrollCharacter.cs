using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollCharacter : MonoBehaviour
{
    public static ScrollCharacter scrollCharacter;
    
    private Vector3 _selectPosition;
    public Vector3 SelectPosition => _selectPosition;
    public List<Transform> Characters;
    private Characters _avaiableCharacter;

    [SerializeField] private Button _selectButton;
    [SerializeField] private Text _selectButtonText;

    public void BackCharacter()
    {
        var temp = Vector3.zero;
        for (int i = 0; i < Characters.Count; i++)
        {
            if (i != 0 && i != Characters.Count - 1)
                Characters[i].transform.position = Characters[i + 1].transform.position;
            else if (i == 0)
            {
                temp = Characters[i].transform.position;
                Characters[i].transform.position = Characters[i + 1].transform.position;
            }
            else if (i == Characters.Count - 1)
            {
                Characters[i].transform.position = temp;
            }
        }
        FindAvaiableCharacter();
        if (_avaiableCharacter.isSelect)
        {
            _selectButtonText.text = "Selected"; 
            _selectButton.interactable = false;
        }
        else if(_avaiableCharacter.IsBuyed)
        {
            _selectButtonText.text = "Select";
            _selectButton.interactable = true;
        }
        else if(!_avaiableCharacter.IsBuyed)
        {
            _selectButtonText.text = _avaiableCharacter.Price.ToString();
            _selectButton.interactable = true;
        }

    }
    public void NextCharacter()
    {
        var temp = Vector3.zero;
        for (int i = Characters.Count - 1; i >= 0; i--)
        {
            if (i != 0 && i != Characters.Count - 1)
            {
                Characters[i].transform.position = Characters[i - 1].transform.position;
            }
            else if (i == 0)
            {
                if (temp != Vector3.zero)
                    Characters[i].transform.position = temp;
                else Characters[i].transform.position = Characters[Characters.Count - 1].transform.position;
            }
            else if (i == Characters.Count - 1)
            {
                temp = Characters[i].transform.position;
                Characters[i].transform.position = Characters[i - 1].transform.position;
            }
        }
        FindAvaiableCharacter();
        if (_avaiableCharacter.isSelect)
        {
            _selectButtonText.text = "Selected";
            _selectButton.interactable = false;
        }
        else if (_avaiableCharacter.IsBuyed)
        {
            _selectButtonText.text = "Select";
            _selectButton.interactable = true;
        }
        else if (!_avaiableCharacter.IsBuyed)
        {
            _selectButtonText.text = _avaiableCharacter.Price.ToString();
            _selectButton.interactable = true;
        }
    }

    private void Start()
    {
        scrollCharacter = this;
        FindAvaiableCharacter();
        //_selectPosition = _avaiableCharacter.transform.position;
    }
    private void FindAvaiableCharacter()
    {
        for (int i = 0; i < Characters.Count; i++)
        {
            if (Characters[i].GetComponent<Characters>().isAvailable)
            {
                _avaiableCharacter = Characters[i].GetComponent<Characters>();
                break;
            }
        }
        if (_avaiableCharacter == null) _avaiableCharacter = Characters[0].GetComponent<Characters>();
    }
}
