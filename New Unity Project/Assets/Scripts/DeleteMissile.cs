using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMissile : MonoBehaviour
{

    private GameObject playerMissile;
    private GameObject enemyMissile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMissile = GameObject.Find("Missile(Clone)");
        enemyMissile = GameObject.Find("Missile Variant(Clone)");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile") == true)
        {
            Destroy(playerMissile);
        }

        if (collision.CompareTag("EnemyMissile") == true)
        {
            Destroy(enemyMissile);
        }
    }
}
