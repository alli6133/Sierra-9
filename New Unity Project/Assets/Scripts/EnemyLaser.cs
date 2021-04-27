//Axel Sterner
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public Rigidbody2D missile;
    public GameObject enemyLauncher;
    public Quaternion launcherRot;//prova �ndra till rotation ist�llet
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
        launcherRot = enemyLauncher.transform.rotation;
        FireMissile();
    }

    public void FireMissile()
    {
        clone = Instantiate(missile, missile.transform.position, missile.transform.rotation);
        clone.velocity = new Vector2(13.0f, 0.0f);
        audioSource.PlayOneShot(firesound);
    }
}
