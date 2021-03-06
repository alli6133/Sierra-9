//Alexander Lindberg
//Diego Puentes Varas dipu6255

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private PlayerState ps;
    private PowerupSpawner powerupScript;
    
    //private Rigidbody2D rigidBody2D; 
    //private SpriteRenderer spriteRenderer;

    public int maxHealth = 1;
    public int attackDamage = 1;
    public double currentHealth;
    public float chanceForPowerupSpawn = 1.0f;

    private Vector3 myPosition;
    private Vector3 deathPosition;
    private Quaternion deathRotation;
    private bool isAlive = true;

    //Olivia
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool removeGameObject = false;
    private float timer = 0f;
    [SerializeField] private float timeBeforeDeletion = 3f; // inte tar bort fiendeobjektet på direkten

    ParticleSystem system;
    [SerializeField] private float frequency = 5f;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float speed = 4f;

    //[SerializeField] private float offset = 0f; 

    void Start()
    {
        ps = GameObject.Find("Player").GetComponent<PlayerState>();
        powerupScript = GameObject.Find("PowerupSpawner").GetComponent<PowerupSpawner>();
        currentHealth = maxHealth;
        //rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        myPosition = gameObject.transform.position;
        system = GetComponentInChildren<ParticleSystem>();
    }

   private float timeSinceLevelLoad = 0f;//Axel

    void Update()
    {
        timeSinceLevelLoad += Time.deltaTime;

        if (isAlive)
        {
            //Använder sinusformeln för att röra fienden upp och ner
            transform.position = myPosition + transform.up * Mathf.Sin(Time.time * frequency/* + offset*/) * radius + transform.right * timeSinceLevelLoad * speed;
        }

        // Olivia, när fienden dör så kommer timer sättas innan objektet förstörs
        if (removeGameObject == true)
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeDeletion)
            {
                Destroy(gameObject);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile") == true)
        {
            Destroy(collision.gameObject);
            EnemyTakeDamage(ps.currentAttackDamage);
        }
    }

    private void EnemyTakeDamage(double damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            enemyDeath();
        }
    }

    private void SpawnPowerUpOnDeath()
    {
        if(Random.value <= chanceForPowerupSpawn)
        {
            deathPosition = gameObject.transform.position;
            deathRotation = gameObject.transform.rotation;
            powerupScript.SpawnPowerup(deathPosition, deathRotation);
        }
    }

    public void enemyDeath()
    {
        isAlive = false;
        audioSource.PlayOneShot(deathClip);
        spriteRenderer.sprite = null;
        GetComponent<Collider2D>().enabled = false; //stänger av collidern, undviker buggar
        SpawnPowerUpOnDeath();
        system.Play();
        removeGameObject = true;
    }
}
