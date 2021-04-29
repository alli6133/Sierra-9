using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    private Vector3 myPosition;
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private float speed = 4f; 
    [SerializeField] private float frequency = 5f; 
    [SerializeField] private float radius = 5f;

    public Rigidbody2D missile;
    public GameObject bossLauncher;
    public Vector3 launcherPos;
    public Rigidbody2D clone;

    public int attackDamage = 2;

    [SerializeField] private float laserTimer;
    [SerializeField] private float laserCooldown = 0.7f;

    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        myPosition = gameObject.transform.position;
        laserTimer = laserCooldown;
    }

    void Update()
    {
        transform.position = myPosition + transform.up * Mathf.Sin(Time.time * frequency) * radius + transform.right * Time.time * speed;
        bossLauncher = GameObject.Find("bossLauncher");
        launcherPos = bossLauncher.transform.position;

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
        clone = Instantiate(missile, launcherPos, missile.transform.rotation);
        clone.velocity = new Vector2(-13.0f, 0.0f);
        laserTimer = laserCooldown;
    }

}
