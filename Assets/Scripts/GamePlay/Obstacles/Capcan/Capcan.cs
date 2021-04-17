using UnityEngine;
using UnityEngine.SceneManagement;

public class Capcan : MonoBehaviour
{
    private Transform _thorn;
    private AudioSource _audioSource;

    private void Start()
    { 
       _thorn = transform.Find("capcan_on");
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        Rabbit rabbit = collider.GetComponent<Rabbit>();       
        if (rabbit && _thorn.gameObject.activeSelf == true)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnTriggerExit(Collider collider)
    {
        Rabbit rabbit = collider.GetComponent<Rabbit>();
        if (rabbit)
        {
            if(SoundSetting.IsSoundOn) _audioSource.Play();
            _thorn.gameObject.SetActive(true);
        }
    }
}
