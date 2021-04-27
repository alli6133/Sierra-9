//Axel Sterner
//Alexander Lindberg
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject enemyClone;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //enemyClone = Instantiate(enemy,)
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
