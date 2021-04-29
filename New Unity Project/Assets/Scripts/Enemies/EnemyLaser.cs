//Axel Sterner
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public Rigidbody2D enemyMissile;
    public GameObject enemyLauncher;
    public Vector3 launcherPos;
    public Rigidbody2D clone;

    [SerializeField] private float laserTimer;
    [SerializeField] private float laserCooldown = 0.7f;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip firesound;

    void Start()
    {
        laserTimer = laserCooldown;
    }

    void Update()
    {
        enemyLauncher = GameObject.Find("enemyLauncher");
        launcherPos = enemyLauncher.transform.position;

        if (laserTimer < 0)
        {
            FireMissile();
        }
        else
        {
            laserTimer -= Time.deltaTime;
        }
    }

    public void FireMissile()
    {
        clone = Instantiate(enemyMissile, launcherPos, enemyMissile.transform.rotation);
        clone.velocity = new Vector2(-13.0f, 0.0f);
        audioSource.PlayOneShot(firesound);
        laserTimer = laserCooldown;
    }
}
