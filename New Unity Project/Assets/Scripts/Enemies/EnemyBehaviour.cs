//Alexander Lindberg
//Diego Puentes Varas dipu6255

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private PlayerState ps;
    private Vector3 myPosition;
    //private Rigidbody2D rigidBody2D; 
    //private SpriteRenderer spriteRenderer;

    public int maxHealth = 2;
    public int attackDamage = 1;
    public double currentHealth;
    
    [SerializeField] private float frequency = 5f;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float speed = 4f;

    public Rigidbody2D enemyMissile;
    private GameObject enemyLauncher;
    public Vector3 launcherPos;
    public Rigidbody2D clone;

    [SerializeField] private float laserTimer;
    [SerializeField] private float laserCooldown = 0.7f;

    //[SerializeField] private float offset = 0f; 

    void Start()
    {
        ps = GameObject.Find("Player").GetComponent<PlayerState>();
        currentHealth = maxHealth;
        //rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        myPosition = gameObject.transform.position;
        laserTimer = laserCooldown;
    }


    void Update()
    {
        //Använder sinusformeln för att röra fienden upp och ner
        transform.position = myPosition + transform.up * Mathf.Sin(Time.time * frequency /*+ offset*/) * radius + transform.right * Time.time * speed;
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
            Destroy(gameObject);
        }
    }
}
