using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{
    public bool IsWin = false;
    public int starCount;
    public static WinController winController;
    public LevelData levelData;

    [SerializeField] private GameObject _winPanel;
    private string _levelResulForJson;

    public void WinResult()
    {
        if (CarrotsCounter.carrotsCounter.Count <= 0)
        {
            IsWin = true;
            _winPanel.SetActive(true);
            _winPanel.GetComponent<WinPanel>().CheckStepCount();
            if (SceneManager.GetActiveScene().buildIndex == SelectLevel.countComlpleteLevel)
                MakeFirstLevelWinReward();

            if (starCount > levelData.LevelStarCount[SceneManager.GetActiveScene().buildIndex])
                ChangeStarCountInLevel();
        }
    }

    private void Awake()
    {
        winController = this;
    }
    private void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3819611", false);
        }

        GetLevelDataFromJson();
    }
    private void AdsShow()
    {
            if (Advertisement.IsReady())
            {
                Advertisement.Show("video");
            }
    }
    private void GetLevelDataFromJson()
    {

        if (PlayerPrefs.GetString("Json") != string.Empty)
        {
            levelData = JsonUtility.FromJson<LevelData>(PlayerPrefs.GetString("Json"));
            starCount = levelData.LevelStarCount[SceneManager.GetActiveScene().buildIndex];
        }
        else
        {
            levelData = new LevelData();
            starCount = 0;
        }
    }
    private void MakeFirstLevelWinReward()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 10)
            AdsShow();
        SelectLevel.countComlpleteLevel++;
        PlayerPrefs.SetInt("LevelCount", SelectLevel.countComlpleteLevel);
        GameValuta.ValutaCount += CarrotsCounter.carrotsCounter.Count;
        PlayerPrefs.SetInt("Valuta", GameValuta.ValutaCount);
    }
    private void ChangeStarCountInLevel()
    {
        levelData.LevelStarCount[SceneManager.GetActiveScene().buildIndex] = starCount;
        _levelResulForJson = JsonUtility.ToJson(levelData);
        PlayerPrefs.SetString("Json", _levelResulForJson);
    }
}
