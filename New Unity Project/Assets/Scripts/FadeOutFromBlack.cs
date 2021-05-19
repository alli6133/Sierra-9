using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutFromBlack : MonoBehaviour
{

    [SerializeField] private GameObject blackOutSquare;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject fireButton;
    private bool sceneStart = true;
    private bool isUI = false;
    private float timer = 0f;
    private float timeBeforeFade = 1.5f;
    private float timeBeforeUIAppears = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneStart)
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeFade)
            {
                StartCoroutine(FadeAwayFromBlack());
                sceneStart = false;
            }
        }

        if (!isUI)
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeUIAppears)
            {
                healthBar.SetActive(true);
                fireButton.SetActive(true);
                isUI = true;
            }
        }
    }

    public IEnumerator FadeAwayFromBlack(bool fadeToBlack = true, int fadeSpeed = 1)
    {
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (blackOutSquare.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }
}
