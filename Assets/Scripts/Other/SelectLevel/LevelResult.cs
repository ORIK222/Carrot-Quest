using UnityEngine;
using UnityEngine.UI;

public class LevelResult : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private Sprite _darkStarSprite;
    [SerializeField] private Sprite _goldStarSprite;

    private int _starCount;
    private LevelData _levelData;
    private Image[] _starImages = new Image[3];



    private void Awake()
    {
        MakeStarPosition();
    }
    private void Start()
    {
        StarCountCalculation();
    }

    private void StarCountCalculation()
    {
        if (_levelNumber <= PlayerPrefs.GetInt("LevelCount"))
        {
            for (int i = 0; i < 3; i++)
            {
                _starImages[i].sprite = _darkStarSprite;
            }

            _levelData = JsonUtility.FromJson<LevelData>(PlayerPrefs.GetString("Json"));
            if (_levelData != null) _starCount = _levelData.LevelStarCount[_levelNumber];
            StarDrawer();
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                _starImages[i].gameObject.SetActive(false);
            }
        }
    }
    private void StarDrawer()
    {
        for (int i = 0; i < _starCount; i++)
        {
            _starImages[i].sprite = _goldStarSprite;
        }
    }
    private void MakeStarPosition()
    {
        for (int i = 1; i < 4; i++)
        {
            _starImages[i - 1] = transform.GetChild(i).GetComponent<Image>();
        }
        var temp = _starImages[0].GetComponent<RectTransform>().anchoredPosition; temp.x = -11;
        _starImages[0].GetComponent<RectTransform>().anchoredPosition = temp;
        temp = _starImages[1].GetComponent<RectTransform>().anchoredPosition; temp.x = 0;
        _starImages[1].GetComponent<RectTransform>().anchoredPosition = temp;
        temp = _starImages[2].GetComponent<RectTransform>().anchoredPosition; temp.x = 11;
        _starImages[2].GetComponent<RectTransform>().anchoredPosition = temp;
    }
}
