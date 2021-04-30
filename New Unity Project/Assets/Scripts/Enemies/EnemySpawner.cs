//Axel Sterner
//Alexander Lindberg
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    //private GameObject enemyClone;
    public Transform spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        spawnPosition = transform.Find("Position");

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spawnEnemy();
        }
    }

    private void spawnEnemy() {
        GameObject enemyClone = Instantiate(enemy, spawnPosition);
    }

    /*private void spawnEnemy() {
        GameObject enemyClone = Instantiate(enemy) as GameObject;
        enemyClone.transform.position = spawnPosition;
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
