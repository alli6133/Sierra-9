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
    private SpacerockBehaviour spaceRock;
    private HealthUI healthUI;
    public GameObject startPosition;
    public GameObject levelCollider;
    public GameObject rocketBoost;
    private GameObject laserButton;
    public ParticleSystem dmgParticles;
    public ParticleSystem explosion;
    public AudioSource musicSource;
    [SerializeField] private GameObject healthBar;


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
    [SerializeField] private AudioClip enemyDeathClip;
    [SerializeField] private AudioClip powerUpActivatesClip;
    [SerializeField] private AudioClip playerDamageClip;
    [SerializeField] private AudioClip playerDeathClip;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool removeGameObject = false;
    private float timer = 0f;
    [SerializeField] private float timeBeforeDeletion = 5f;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level1") {
            //Skapa en metod och l??gg in den h??r. Metoden ska flytta spelaren in i kamerans ram, det ska f??rest?? som en typ av intro-"animation" f??r f??rsta leveln
        }
        spaceRock = (SpacerockBehaviour)FindObjectOfType(typeof(SpacerockBehaviour));

        boss = (BossBehaviour)FindObjectOfType(typeof(BossBehaviour));
        laserButton = GameObject.Find("Laser_button");

        touch = GetComponent<TouchMovement>();
        normalMovementSpeed = GetComponent<TouchMovement>().movementSpeed;

        healthUI = healthBar.GetComponent<HealthUI>();
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
        if (collision.gameObject.CompareTag("EnemyMissile"))
        {
            TakeDamage(enemyAttackDamage);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Spacerock"))
        {
            TakeDamage(enemyAttackDamage);
            spaceRock.RockTakeDamage(currentAttackDamage);
        }

        if (collision.gameObject.CompareTag("EnemyLaser"))
        {
            TakeDamage(enemyAttackDamage);
            collision.gameObject.GetComponent<Laser_Enemy>().enemyDeath();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(enemyDeathClip);
            TakeDamage(enemyAttackDamage);
            collision.gameObject.GetComponent<EnemyBehaviour>().enemyDeath();
        }

        if (collision.gameObject.CompareTag("BossMissile"))
        {
            TakeDamage(boss.attackDamage);
            Destroy(collision.gameObject);
        }


    }

    private void playerTakesDamageAudio() {
        audioSource.PlayOneShot(playerDamageClip);
    }

    public void TakeDamage(int damage)
    {

        if (!invincibilityBool && !shieldBool)
        {
            audioSource.PlayOneShot(playerDamageClip);
            currentHealth -= damage;
        }
        else if (!invincibilityBool && shieldBool)
        {
            //audioSource.PlayOneShot(playerDamageClip);
            currentShieldHealth -= damage;
        }
        
        if (currentShieldHealth == 0 && !invincibilityBool && currentHealth > 0)
        {
            shieldBool = false;
        }

        if (currentHealth == 5)
        {
            repair.gameObject.SetActive(true);
            dmgParticles.Play();

        }

        if(currentHealth <= 3)
        {
            repair.gameObject.SetActive(false);
            critical.gameObject.SetActive(true);
            dmgParticles.Play();
        }

        if (currentHealth <= 0)
        {
            musicSource.Stop();
            audioSource.PlayOneShot(playerDeathClip);
            spriteRenderer.sprite = null;
            GetComponent<EdgeCollider2D>().enabled = false; //st??nger av collidern, undviker buggar
            levelCollider.SetActive(false);
            rocketBoost.SetActive(false);
            dmgParticles.Stop();
            explosion.Play();
            laserButton.SetActive(false);
            removeGameObject = true;
        }
        healthUI.SetHealth(currentHealth);
    }

    public void Move(Vector2 movementSpeed)
    {
        gameObject.transform.Translate(movementSpeed);
    }

    public void Invincibility()
    {
        powerUpAudio();
        invincibilityBool = true;
    }

    public void OneShot()
    {
        powerUpAudio();
        currentAttackDamage = oneShotDamage;
        oneShotBool = true;
    }

    public void Shield()
    {
        powerUpAudio();
        currentShieldHealth = shieldStrength;
        shieldBool = true;
    }

    public void SpeedUp()
    {
        powerUpAudio();
        if (!speedUpBool)
        {
            touch.movementSpeed *= 2;
            speedUpBool = true;
        }
    }

    private void powerUpAudio() {
        audioSource.PlayOneShot(powerUpActivatesClip);
    }

    private void MovePlayerInFrame() {

    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
