//Axel Sterner
//Alexander Lindberg
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    private GameObject enemyClone;
    public Transform spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyClone = Instantiate(enemy, spawnPosition);
            print("Collider triggered");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
