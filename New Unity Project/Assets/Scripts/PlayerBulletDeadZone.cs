using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletDeadZone : MonoBehaviour
{

    private GameObject playerLaser;

    void Start()
    {
        playerLaser = GameObject.Find("Missile");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            Destroy(collision.gameObject);
        }
    }
}
