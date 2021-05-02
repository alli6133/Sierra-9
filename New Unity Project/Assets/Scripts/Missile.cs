using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Missile") || collision.gameObject.CompareTag("EnemyMissile") || collision.gameObject.CompareTag("BossMissile"))
        {
            Destroy(collision.gameObject);
        }
    }
}
