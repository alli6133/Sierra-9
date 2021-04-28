//Axel Sterner
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgBox : MonoBehaviour
{
    private GameObject enemyToKill;
    private GameObject missile;
    
    void Start()
    {
        enemyToKill = gameObject.transform.parent.gameObject;
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile") == true)
        {
            Destroy(missile);
            Destroy(enemyToKill);
        }
    }

    // Update is called once per frame
    void Update()
    {
        missile = GameObject.Find("Missile(Clone)");
    }
}
