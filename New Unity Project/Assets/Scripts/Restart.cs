//Axel Sterner
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public void Reset()
    {
        SceneManager.LoadScene("Level1");
    }
}
