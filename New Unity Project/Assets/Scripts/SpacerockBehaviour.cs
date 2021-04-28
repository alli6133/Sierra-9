using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacerockBehaviour : MonoBehaviour
{

    public int maxHealth = 2;
    public double currentHealth;
    private PlayerState ps;
    private Vector3 rockPosition;
    [SerializeField] private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.Find("Player").GetComponent<PlayerState>();
        currentHealth = maxHealth;
        rockPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = rockPosition + transform.right * Time.time * speed;
        //transform.Rotate(0, 0, 50 * Time.deltaTime); //Se till att göra så stenen snurrar runt medans den rör sig på ett visst håll, juicing stage
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile") == true)
        {
            Destroy(collision.gameObject);
            RockTakeDamage(ps.currentAttackDamage);
        }
    }

    private void RockTakeDamage(double damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
