using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DmgBoxBoss : MonoBehaviour
{
    private GameObject enemyToKill;
    private GameObject missile;
    [SerializeField] private int HP = 20; 
    
    void Start()
    {
        enemyToKill = gameObject.transform.parent.gameObject;
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile") == true)
        {
            HP--;
            Destroy(missile);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HP == 0)
        {
            destroyBoss();
            SceneManager.LoadScene("MainMenu");
        }

        missile = GameObject.Find("Missile(Clone)");
    }

    private void destroyBoss()
    {
        Destroy(enemyToKill);
    }

}
