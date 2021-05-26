using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WarningIntroText : MonoBehaviour
{
    
    public GameObject warningText;
    private float timer = 0f;
    private float timeBeforeRemoveText = 5.2f;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            warningText.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeRemoveText)
            {
                warningText.SetActive(false);
            }
        }
    }
}
