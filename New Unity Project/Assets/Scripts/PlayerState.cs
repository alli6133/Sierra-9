//Diego Puentes Varas dipu6255

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private Text repair;
    [SerializeField] private Text critical;
    private BossBehaviour boss;
    private EnemyBehaviour enemy;
    private HealthUI healthUI;
    public GameObject startPosition;

    public int maxHealth = 1;
    private int currentHealth;
    private int currentShieldHealth;
    [System.NonSerialized] public double currentAttackDamage;

    private float invincibilityTimer;
    private float oneShotTimer;
    private float speedUpTimer;

    private double normalAttackDamage = 1f;
    private int enemyAttackDamage;
    private double oneShotDamage = double.PositiveInfinity;

    private bool invincibilityBool;
    private bool oneShotBool;
    private bool shieldBool;
    private bool speedUpBool;

    private TouchMovement touch;

    private int shieldStrength = 5;
    private float invincibilityDuration = 5f;
    private float oneShotDuration = 5f;
    private float speedUpDuration = 5f;
    private float normalMovementSpeed;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool removeGameObject = false;
    private float timer = 0f;
    [SerializeField] private float timeBeforeDeletion = 5f;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level1") {
            //Skapa en metod och lägg in den här. Metoden ska flytta spelaren in i kamerans ram, det ska förestå som en typ av intro-"animation" för första leveln
        }

        boss = (BossBehaviour)FindObjectOfType(typeof(BossBehaviour));

        touch = GetComponent<TouchMovement>();
        normalMovementSpeed = GetComponent<TouchMovement>().movementSpeed;

        healthUI = GameObject.Find("Slider").GetComponent<HealthUI>();
        healthUI.SetMaxHealth(maxHealth);

        gameObject.transform.position = startPosition.transform.position;

        currentHealth = maxHealth;
        currentAttackDamage = normalAttackDamage;

        invincibilityTimer = invincibilityDuration;
        oneShotTimer = oneShotDuration;
        speedUpTimer = speedUpDuration;
       
    }
    
    void Update()
    {
        enemy = (EnemyBehaviour)FindObjectOfType(typeof(EnemyBehaviour));
        
        if(enemy != null)
        {
            enemyAttackDamage = enemy.attackDamage;
        }

        if (invincibilityBool)
        {
            invincibilityTimer -= Time.deltaTime;
        }

        if (invincibilityTimer <= 0)
        {
            invincibilityBool = false;
            invincibilityTimer = invincibilityDuration;
        }

        if (oneShotBool)
        {
            oneShotTimer -= Time.deltaTime;
        }

        if (oneShotTimer <= 0)
        {
            oneShotBool = false;
            currentAttackDamage = normalAttackDamage;
            oneShotTimer = oneShotDuration;
        }

        if (speedUpBool)
        {
            speedUpTimer -= Time.deltaTime;
        }

        if (speedUpTimer <= 0)
        {
            speedUpBool = false;
            touch.movementSpeed = normalMovementSpeed;
            speedUpTimer = speedUpDuration;
        }

        if (removeGameObject == true)
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeDeletion)
            {
                GameOver();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyMissile") || collision.gameObject.CompareTag("EnemyLaser"))
        {
            TakeDamage(enemyAttackDamage);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("BossMissile"))
        {
            TakeDamage(boss.attackDamage);
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!invincibilityBool && !shieldBool)
        {
            currentHealth -= damage;
        }
        else if (!invincibilityBool && shieldBool)
        {
            currentShieldHealth -= damage;
        }
        
        if (currentShieldHealth == 0 && !invincibilityBool && currentHealth > 0)
        {
            shieldBool = false;
        }

        healthUI.SetHealth(currentHealth);

        if (currentHealth == 5)
        {
            repair.gameObject.SetActive(true);
        }

        if(currentHealth <= 3)
        {
            repair.gameObject.SetActive(false);
            critical.gameObject.SetActive(true);
        }

        if (currentHealth <= 0)
        {
            audioSource.PlayOneShot(deathClip);
            spriteRenderer.sprite = null;
            GetComponent<EdgeCollider2D>().enabled = false; //stänger av collidern, undviker buggar
            removeGameObject = true;
        }
    }

    public void Move(Vector2 movementSpeed)
    {
        gameObject.transform.Translate(movementSpeed);
    }

    public void Invincibility()
    {
        invincibilityBool = true;
    }

    public void OneShot()
    {
        currentAttackDamage = oneShotDamage;
        oneShotBool = true;
    }

    public void Shield()
    {
        currentShieldHealth = shieldStrength;
        shieldBool = true;
    }

    public void SpeedUp()
    {
        touch.movementSpeed *= 2;
        speedUpBool = true;
    }

    private void MovePlayerInFrame() {

    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
