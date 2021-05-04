using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ToMainMenu : MonoBehaviour
{
    public void Reset()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
