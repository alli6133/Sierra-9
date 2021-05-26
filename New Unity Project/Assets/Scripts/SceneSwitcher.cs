//Axel Sterner
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{

    public GameObject blackOutSquare;
    public GameObject fireButton;
    public GameObject healthBar;
    [SerializeField] private AudioSource audioSourceAmbience;
    [SerializeField] private AudioSource audioSourceMusic;
    private bool reachedEnd1 = false;
    private bool reachedEnd2 = false;
    private bool reachedEnd3 = false;
    private bool reachedEnd4 = false;
    private float timer = 0f;
    private float timeBeforeNewScene = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reachedEnd1)
        {
            FadeToNextScene();

            timer += Time.deltaTime;
            if (timer >= timeBeforeNewScene )
            {
                SceneManager.LoadScene("Level2");
            }
        }
        
        if (reachedEnd2)
        {
            FadeToNextScene();

            timer += Time.deltaTime;
            if (timer >= timeBeforeNewScene )
            {
                SceneManager.LoadScene("Level3");
            }
        }

        if (reachedEnd3)
        {
            FadeToNextScene();

            timer += Time.deltaTime;
            if (timer >= timeBeforeNewScene)
            {
                SceneManager.LoadScene("Level4");
            }
        }

        if (reachedEnd4)
        {
            FadeToNextScene();

            timer += Time.deltaTime;
            if (timer >= timeBeforeNewScene)
            {
                SceneManager.LoadScene("BossLvl");
            }
        }
    }

    private void FadeToNextScene() {
        fireButton.SetActive(false);
        healthBar.SetActive(false);
        StartCoroutine(FadeBlackOutSquare());
        StartCoroutine(StartFadeOutAudio(audioSourceAmbience, 2, 0));
        StartCoroutine(StartFadeOutAudio(audioSourceMusic, 2, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            if(SceneManager.GetActiveScene().name == "Level1")
            {
                reachedEnd1 = true;
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                reachedEnd2 = true;
            }
            else if (SceneManager.GetActiveScene().name == "Level3")
            {
                reachedEnd3 = true;
            }
            else if (SceneManager.GetActiveScene().name == "Level4")
            {
                reachedEnd4 = true;
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
            
        }
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, int fadeSpeed = 1)
    {
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (blackOutSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
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
}
