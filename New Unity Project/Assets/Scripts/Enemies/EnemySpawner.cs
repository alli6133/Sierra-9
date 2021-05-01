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
    public GameObject spawn;
    public Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        spawn = transform.Find("Spawn").gameObject;//hitta spawn-objektet
        spawnPos = spawn.transform.position;//hitta spawnobjektets position
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spawnEnemy();
        }
    }

    private void spawnEnemy() {
        GameObject enemyClone = Instantiate(enemy);
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
