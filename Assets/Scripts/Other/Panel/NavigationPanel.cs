using UnityEngine;
using UnityEngine.UI;

public class NavigationPanel : MonoBehaviour
{
    public bool IsPause = false;
    
    [SerializeField] private Text _carrotsScore;
    private RectTransform _pausePanel;

    public void Pause()
    {
        IsPause = !IsPause;
        if (IsPause)
        {
            _pausePanel.gameObject.SetActive(IsPause);
            _pausePanel.GetComponent<Animator>().SetTrigger("PauseEnabled");
        }
        else
        {
            _pausePanel.GetComponent<Animator>().SetTrigger("PauseOff");
        }
    }
    private void Awake()
    {
        _pausePanel = FindObjectOfType<PausePanel>().GetComponent<RectTransform>();
    }
    private void Start()
    {
        _pausePanel.gameObject.SetActive(false);
        _carrotsScore.text = CarrotsCounter.carrotsCounter.Count.ToString();
    }
    private void Update()
    {
        _carrotsScore.text = CarrotsCounter.carrotsCounter.Count.ToString();
        if (_pausePanel.anchoredPosition.y >= -111 && !IsPause)
            _pausePanel.gameObject.SetActive(IsPause);
    }
}
