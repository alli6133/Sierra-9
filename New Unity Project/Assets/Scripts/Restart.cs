//Axel Sterner
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip restartPressedClip;
    public GameObject blackOutSquare;
    public GameObject menuButton;
    public Image restartImage;
    public Text restartText;
    private bool restartPressed = false;
    private float timer = 0f;
    private float timeBeforeNewScene = 3f;

    public void Reset()
    {
        restartPressed = true;
        menuButton.SetActive(false);
        restartImage.enabled = false;
        restartText.enabled = false;
        audioSource.PlayOneShot(restartPressedClip);
    }

    void Update()
    {
        if (restartPressed == true)
        {
            StartCoroutine(FadeBlackOutSquare());

            timer += Time.deltaTime;
            if (timer >= timeBeforeNewScene)
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
