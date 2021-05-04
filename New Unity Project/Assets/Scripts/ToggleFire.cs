//Axel Sterner
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFire : MonoBehaviour
{
    private GameObject enemyLaser;
    // Start is called before the first frame update
    void Start()
    {
        enemyLaser = GameObject.Find("Enemy_Laser");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("EnemyLaser"))
        {
            collision.gameObject.GetComponent<Laser_Enemy>().readyToFire = true;
        }
    }
}
