using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialTexts : MonoBehaviour
{

    public GameObject upText;
    public GameObject downText;
    private float timer = 0f;
    private float timeBeforeTextAppears = 5.2f;
    private float timeBeforeRemoveText = 12.2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeTextAppears)
            {
                upText.SetActive(true);
                downText.SetActive(true);
            }

            if (timer >= timeBeforeRemoveText)
            {
                upText.SetActive(false);
                downText.SetActive(false);
            }
        }
    }
}
