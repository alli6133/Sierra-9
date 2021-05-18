using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip ambienceClip;

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
        
    }

    public void FadeOutAudio()
    {
        StartCoroutine(StartFade(audioSource, 2, 0));
    }

    public IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
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
}
