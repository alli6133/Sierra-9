//Diego Puentes Varas dipu6255

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            collision.gameObject.GetComponent<PlayerState>().Invincibility();
            Destroy(gameObject);
        }
    }
}
