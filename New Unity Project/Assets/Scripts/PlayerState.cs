//Diego Puentes Varas dipu6255

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public EnemyBehaviour enemy;
    public HealthUI healthUI;

    public int maxHealth = 1;
    public int currentHealth;
    public int currentShieldHealth;

    public float invincibilityTimer;
    public float oneShotTimer;
    public float speedUpTimer;

    public double normalAttackDamage = 1f;
    public double currentAttackDamage;
    public double oneShotDamage = double.PositiveInfinity;

    public bool invincibilityBool;
    public bool oneShotBool;
    public bool shieldBool;
    public bool speedUpBool;

    private TouchMovement touch;

    private int shieldStrength = 5;
    private float invincibilityDuration = 5f;
    private float oneShotDuration = 5f;
    private float speedUpDuration = 5f;
    private float normalMovementSpeed;

    void Start()
    {
        touch = GetComponent<TouchMovement>();
        normalMovementSpeed = GetComponent<TouchMovement>().movementSpeed;
        healthUI.SetMaxHealth(maxHealth);

        currentHealth = maxHealth;
        currentAttackDamage = normalAttackDamage;

        invincibilityTimer = invincibilityDuration;
        oneShotTimer = oneShotDuration;
        speedUpTimer = speedUpDuration;
    }
    
    void Update()
    {
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") == true)
        {
            TakeDamage(enemy.attackDamage);
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

        if (currentHealth <= 0)
        {
            GameOver();
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

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
