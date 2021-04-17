using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _isAudio = true;

    private void Start()
    {
        if (FindObjectsOfType<Music>().Length < 2)
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Play();
            DontDestroyOnLoad(_audioSource);
        }
        else _isAudio = false;
    }
    private void Update()
    {
        if (_isAudio)
        {
            if (!MusicSetting.IsMusicOn) _audioSource.volume = 0f;
            else _audioSource.volume = 0.1f;
        }
        if (SceneManager.GetActiveScene().name == "Select Level" || SceneManager.GetActiveScene().buildIndex == 0) Destroy(gameObject);
    }
}
