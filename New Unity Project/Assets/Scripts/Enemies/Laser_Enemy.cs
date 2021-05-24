//Alexander Lindberg
//Diego Puentes Varas dipu6255

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Enemy : MonoBehaviour
{
    private PlayerState ps;
    private ParticleSystem system;
    private PowerupSpawner powerupSpawner;

    private Vector3 myPosition;
    private Vector3 deathPosition;
    private Quaternion deathRotation;

    public int maxHealth = 2;
    public int attackDamage = 1;
    public double currentHealth;
    
    [SerializeField] private float frequency = 5f;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float speed = 4f;
    public bool readyToFire = false;

    public Rigidbody2D enemyMissile;
    private GameObject enemyLauncher;
    public Vector3 launcherPos;
    public Rigidbody2D clone;

    [SerializeField] private float laserTimer;
    [SerializeField] private float laserCooldown = 0.7f;

    //[SerializeField] private float offset = 0f; 

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool removeGameObject = false;
    private float timer = 0f;
    [SerializeField] private float timeBeforeDeletion = 1f;

    void Start()
    {
        ps = GameObject.Find("Player").GetComponent<PlayerState>();
        powerupSpawner = GameObject.Find("PowerupSpawner").GetComponent<PowerupSpawner>();
        system = GetComponentInChildren<ParticleSystem>();
        currentHealth = maxHealth;
        myPosition = gameObject.transform.position;
        laserTimer = laserCooldown;
    }
    
    private float timeSinceLevelLoad = 0f;//Axel

    void Update()
    {
        timeSinceLevelLoad += Time.deltaTime;
        //Använder sinusformeln för att röra fienden upp och ner
        transform.position = myPosition + transform.up * Mathf.Sin(Time.time * frequency /*+ offset*/) * radius + transform.right * timeSinceLevelLoad * speed;
        enemyLauncher = transform.Find("enemyLauncher").gameObject;
        launcherPos = enemyLauncher.transform.position;

        if (laserTimer < 0 && readyToFire == true)//Axel
        {
            FireMissile();
        }
        else
        {
            laserTimer -= Time.deltaTime;
        }

        if (removeGameObject == true)
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeDeletion)
            {
                Destroy(gameObject);
            }
        }
    }

    public void FireMissile()
    {
        clone = Instantiate(enemyMissile, launcherPos, enemyMissile.transform.rotation);
        clone.velocity = new Vector2(-60.0f, 0.0f);
        laserTimer = laserCooldown;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile") == true)
        {
            Destroy(collision.gameObject);
            EnemyTakeDamage(ps.currentAttackDamage);
        }
    }

    void EnemyTakeDamage(double damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            enemyDeath();
        }
    }

    public void enemyDeath()
    {
        system.Play();
        readyToFire = false;
        audioSource.PlayOneShot(deathClip);
        spriteRenderer.sprite = null;
        GetComponent<Collider2D>().enabled = false; //stänger av collidern, undviker buggar
        SpawnPowerupOnDeath();
        removeGameObject = true;
    }

    void SpawnPowerupOnDeath()
    {
        if (Random.value <= 0.5)
        {
            deathPosition = gameObject.transform.position;
            deathRotation = gameObject.transform.rotation;
            powerupSpawner.SpawnPowerup(deathPosition, deathRotation);
        }
    }
}
