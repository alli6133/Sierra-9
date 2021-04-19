using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int healthPoints = 10;//aktuell HP
    public int initialHP = 10;//HP spelaren börjar med

    void Start()
    {
        healthPoints = initialHP;
    }

    void Update()
    {
        
    }

    public void DoHarm(int doHarmByThisMuch)
    {
        healthPoints -= doHarmByThisMuch;
        if (healthPoints <= 0)
        {
            ResetScene();
        }
    }

    public void ResetScene()
    {
        //gå till game-over screen
        SceneManager.LoadScene("New Scene");
    }
}
