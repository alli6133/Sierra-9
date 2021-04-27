using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject invincibility;
    public GameObject oneShot;
    public GameObject shield;
    public GameObject speedUp;

    private int randomNumber;
    private float spawnTimer;
    private float spawnCooldown = 5f;

    void Start()
    {
        spawnTimer = spawnCooldown;
    }

    void Update()
    {    
        spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0)
        {
            randomNumber = Random.Range(0, 4);

            switch (randomNumber)
            {
                case 0: Instantiate(invincibility, transform); break;
                case 1: Instantiate(oneShot, transform); break;
                case 2: Instantiate(shield, transform); break;
                case 3: Instantiate(speedUp, transform); break;
            }

            spawnTimer = spawnCooldown;
        }
    }
}