//Axel Sterner
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int healthPoints;//aktuell HP
    public int initialHP = 10;//HP spelaren börjar med

    void Start()
    {
        healthPoints = initialHP;
    }

    void Update()
    {
        
    }

    public void DoHarm(int dmg)
    {
        healthPoints -= dmg;
        if (healthPoints <= 0)
        {
            ResetScene();
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
