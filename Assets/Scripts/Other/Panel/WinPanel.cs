using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class WinPanel : MonoBehaviour
{    
    public float SecondStarStep;
    public float ThirdStarStep;

    [SerializeField] private Image _firstStarSprite;
    [SerializeField] private Image _secondStarSprite;
    [SerializeField] private Image _thirdStarSprite;
    [SerializeField] private Sprite GoldStar;
    [SerializeField] private Sprite DarkStar;


    public void CheckStepCount()
    {
        if (StepCounter.stepCounter.Count <= ThirdStarStep)
        {
            WinController.winController.starCount = 3;
            _firstStarSprite.sprite = GoldStar;
            _secondStarSprite.sprite = GoldStar;
            _thirdStarSprite.sprite = GoldStar;
        }
        else if (StepCounter.stepCounter.Count <= SecondStarStep)
        {
            WinController.winController.starCount = 2;
            _firstStarSprite.sprite = GoldStar;
            _secondStarSprite.sprite = GoldStar;
        }
        else
        {
            WinController.winController.starCount = 1;
            _firstStarSprite.sprite = GoldStar;
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        EyeChangeController.eyeChangeController.IsEyes = false;
        Time.timeScale = 1f;
    }

    private void Start()
    {

        _firstStarSprite.sprite = DarkStar;
        _secondStarSprite.sprite = DarkStar;
        _thirdStarSprite.sprite = DarkStar;
    }
    private void Update()
    {
        if (WinController.winController.IsWin)
        {
            CheckStepCount();
        }
    }

}
