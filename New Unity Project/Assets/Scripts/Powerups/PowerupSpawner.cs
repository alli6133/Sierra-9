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

    public void SpawnPowerup(Vector3 position, Quaternion rotation)
    {
        randomNumber = Random.Range(0, 4);

        switch (randomNumber)
        {
            case 0: Instantiate(invincibility, position, rotation); break;
            case 1: Instantiate(oneShot, position, rotation); break;
            case 2: Instantiate(shield, position, rotation); break;
            case 3: Instantiate(speedUp, position, rotation); break;
        }
    }
}