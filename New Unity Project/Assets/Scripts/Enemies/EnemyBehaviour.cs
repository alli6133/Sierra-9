//Alexander Lindberg
//Diego Puentes Varas dipu6255

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private PlayerState ps;
    
    //private Rigidbody2D rigidBody2D; 
    //private SpriteRenderer spriteRenderer;

    public int maxHealth = 1;
    public int attackDamage = 1;
    public double currentHealth;
    private Vector3 myPosition;
    
    [SerializeField] private float frequency = 5f;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float speed = 4f;

    //[SerializeField] private float offset = 0f; 

    void Start()
    {
        ps = GameObject.Find("Player").GetComponent<PlayerState>();
        currentHealth = maxHealth;
        //rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        myPosition = gameObject.transform.position;
    }


    void Update()
    {
        //Använder sinusformeln för att röra fienden upp och ner
        transform.position = myPosition + transform.up * Mathf.Sin(Time.time * frequency /*+ offset*/) * radius + transform.right * Time.time * speed;
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
