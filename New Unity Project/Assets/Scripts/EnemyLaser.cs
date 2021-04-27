//Axel Sterner
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public Rigidbody2D missile;
    public GameObject enemyLauncher;
    public Vector3 launcherPos;
    public Rigidbody2D clone;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip firesound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemyLauncher = GameObject.Find("enemyLauncher");
        launcherPos = enemyLauncher.transform.position;
        FireMissile();
    }

    public void FireMissile()
    {
        clone = Instantiate(missile, launcherPos, missile.transform.rotation);
        clone.velocity = new Vector2(13.0f, 0.0f);
        audioSource.PlayOneShot(firesound);
    }
}
