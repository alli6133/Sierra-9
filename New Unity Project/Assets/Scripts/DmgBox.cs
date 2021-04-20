using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgBox : MonoBehaviour
{
    GameObject enemyToKill;
    
    void Start()
    {
        enemyToKill = gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile") == true)
        {
            Destroy(enemyToKill);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
