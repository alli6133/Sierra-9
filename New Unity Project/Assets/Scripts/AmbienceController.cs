using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmbienceController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip ambienceClip;
    private bool isFaded = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = ambienceClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu" && isFaded == false)
        {
            FadeInAudio();
            print("reached if-statement");
        }
    }

    public void FadeOutAudio()
    {
        StartCoroutine(StartFadeOut(audioSource, 2, 0));
    }

    private void FadeInAudio()
    {
        StartFadeIn(audioSource, 2, 0, audioSource.volume);
        isFaded = true;
        print("reached fadeInAudio()");
    }

    public IEnumerator StartFadeOut(AudioSource audioSource, float duration, float targetVolume)
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

    public IEnumerator StartFadeIn(AudioSource audioSource, float duration, float startVolume, float targetVolume)
    {
        float currentTime = 0;
        float start = startVolume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
