using UnityEngine;
using static ScrollCharacter;
public class BuyCharacter : MonoBehaviour
{
    private int _characterNumber;
    private string jsonStoreData;
    private string jsonCharacterData;
    private StoreData _storeData;
    private Characters _character;
    private CharacterData[] _characterData = new CharacterData[15];

    public void BuyButtonOnClick()
    {
        FindAvaiableCharacter();
        if (_character.IsBuyed) Select();
        else Buy();
    }

    private void Start()
    {
        _storeData = JsonUtility.FromJson<StoreData>(PlayerPrefs.GetString("JsonStoreData"));
        _characterData[0] = JsonUtility.FromJson<CharacterData>(PlayerPrefs.GetString("JsonCharacterData"));
        if (_character == null) _character = new Characters();
        if (_storeData == null) _storeData = new StoreData();
    }

    private void Buy()
    {
        if(_character.Price <= GameValuta.ValutaCount)
        {
            _character.isSelect = true;
            _character.IsBuyed = true;
            GameValuta.ValutaCount -= _character.Price;
            PlayerPrefs.SetInt("Valuta", GameValuta.ValutaCount);
            _storeData._isBuy[_characterNumber] = true;
            jsonStoreData = JsonUtility.ToJson(_storeData);
            PlayerPrefs.SetString(jsonStoreData, "JsonStoreData");
            jsonCharacterData = JsonUtility.ToJson(_character);
            PlayerPrefs.SetString(jsonCharacterData, "JsonCharacterData");
        }
    }    
    private void Select()
    {
        _character.isSelect = true;
        jsonCharacterData = JsonUtility.ToJson(_character);
        PlayerPrefs.SetString(jsonCharacterData, "JsonCharacterData");
    }

    private void FindAvaiableCharacter()
    {
        for (int i = 0; i < scrollCharacter.Characters.Count; i++)
        {
            if(scrollCharacter.Characters[i].GetComponent<Characters>().isAvailable)
            {
                _character = scrollCharacter.Characters[i].GetComponent<Characters>();
                _characterNumber = i;
                break;
            }
        }
        if (_character == null) _character = scrollCharacter.Characters[0].GetComponent<Characters>();
    }

    private void SimileCharacterData()
    {
    }
}
