using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject blackOutSquare;
    public GameObject playButton;
    public GameObject optionsButton;
    private bool playPressed = false;
    private float timer = 0f;
    private float timeBeforeDeletion = 3f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip playClip;
    [SerializeField] private AudioClip buttonPressClip;

    public void PlayGame ()
    {
        audioSource.PlayOneShot(playClip);
        playButton.SetActive(false);
        optionsButton.SetActive(false);
        playPressed = true;
    }

    public void ButtonPressed()
    {
        audioSource.PlayOneShot(buttonPressClip);
    }

    void Update()
    {
        if (playPressed == true)
        {
            StartCoroutine(FadeBlackOutSquare());

            timer += Time.deltaTime;
            if (timer >= timeBeforeDeletion)
            {
                SceneManager.LoadScene("Level1");
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
}
