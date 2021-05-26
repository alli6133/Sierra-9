using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip musicClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = musicClip;

        if (SceneManager.GetActiveScene().name != "GameOver")
        {
            audioSource.loop = true;
            if (SceneManager.GetActiveScene().name != "MainMenu")
            {
                FadeInAudio();
            }
        }

        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FadeOutAudio()
    {
        StartCoroutine(StartFadeOutAudio(audioSource, 2, 0));
    }

    private void FadeInAudio()
    {
        StartCoroutine(StartFadeIn(audioSource, 2, audioSource.volume));
    }

    public IEnumerator StartFadeOutAudio(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    public IEnumerator StartFadeIn(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = 0;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
