using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    private Vector3 myPosition;
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private float speed = 5f; 
    [SerializeField] private float frequency = 5f; 
    [SerializeField] private float radius = 5f; 

    //[SerializeField] private float offset = 0f; 

    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        myPosition = gameObject.transform.position;
    }

    void Update()
    {
        transform.position = myPosition + transform.up * Mathf.Sin(Time.time * frequency /*+ offset*/) * radius + transform.right * Time.time * speed;
    }

}
