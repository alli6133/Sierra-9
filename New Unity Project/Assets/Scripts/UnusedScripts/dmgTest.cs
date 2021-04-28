using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmgTest : MonoBehaviour
{
    public int dmg = 10;

    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.CompareTag("Player") == true){

            collision.gameObject.GetComponent<PlayerState>().TakeDamage(dmg);
        }
    }
}
