//Alexander Lindberg
//Diego Puentes Varas dipu6255

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int maxHealth = 1;
    public int attackDamage = 1;
    public double currentHealth;

    private PlayerState ps;
    private PowerupSpawner powerupSpawner;

    private Vector3 myPosition;
    private Vector3 deathPosition;
    private Quaternion deathRotation;


    //Olivia
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool removeGameObject = false;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float timeBeforeDeletion = 1f; // inte tar bort fiendeobjektet på direkten


    [SerializeField] private float frequency = 5f;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float speed = 4f;

    //[SerializeField] private float offset = 0f; 

    void Start()
    {
        ps = GameObject.Find("Player").GetComponent<PlayerState>();
        powerupSpawner = GameObject.Find("PowerupSpawner").GetComponent<PowerupSpawner>();
        currentHealth = maxHealth;
        myPosition = gameObject.transform.position;
    }

    private float timeSinceLevelLoad = 0f;//Axel

    void Update()
    {
        timeSinceLevelLoad += Time.deltaTime;
        //Använder sinusformeln för att röra fienden upp och ner
        transform.position = myPosition + transform.up * Mathf.Sin(Time.time * frequency /*+ offset*/) * radius + transform.right * timeSinceLevelLoad * speed;

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

    void EnemyTakeDamage(double damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            audioSource.PlayOneShot(deathClip);
            spriteRenderer.sprite = null;
            GetComponent<Collider2D>().enabled = false; //stänger av collidern, undviker buggar
            SpawnPowerupOnDeath();
            removeGameObject = true;
        }
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
