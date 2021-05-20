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
    private bool reachedEnd = false;
    private float timer = 0f;
    private float timeBeforeNewScene = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reachedEnd)
        {
            fireButton.SetActive(false);
            healthBar.SetActive(false);
            StartCoroutine(FadeBlackOutSquare());

            timer += Time.deltaTime;
            if (timer >= timeBeforeNewScene)
            {
                SceneManager.LoadScene("Level2");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            if(SceneManager.GetActiveScene().name == "Level1")
            {
                reachedEnd = true;
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
}
