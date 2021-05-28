using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacerockBehaviour : MonoBehaviour
{

    public int maxHealth = 2;
    public double currentHealth;
    private PlayerState ps;
    private Vector3 rockPosition;
    private bool isAlive = true;
    private ParticleSystem system;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float timeBeforeDeletion = 0.5f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private bool removeGameObject = false;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.Find("Player").GetComponent<PlayerState>();
        currentHealth = maxHealth;
        rockPosition = gameObject.transform.position;
        system = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            transform.position = rockPosition + transform.right * Time.time * speed;
            //transform.Rotate(0, 0, 50 * Time.deltaTime); //Se till att göra så stenen snurrar runt medans den rör sig på ett visst håll, juicing stage
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile") == true)
        {
            Destroy(collision.gameObject);
            RockTakeDamage(ps.currentAttackDamage);
        }

        if(collision.CompareTag("Player") == true)
        {
            RockTakeDamage(2);
        }
    }

    public void RockTakeDamage(double damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            RockDestruction();
        }
    }

    public void RockDestruction()
    {
        isAlive = false;
        spriteRenderer.sprite = null;
        GetComponent<Collider2D>().enabled = false;
        system.Play();
        removeGameObject = true;
    }

}
