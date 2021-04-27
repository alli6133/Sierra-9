using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    Vector3 myPosition;
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    public float movementSpeed = 5f;
    private float moveDirection = 0f;
    public float verticalForce = 4;

    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        myPosition = gameObject.transform.position;
        rigidBody2D.gravityScale = 0;
    }


    void Update()
    {
        Vector3 calculatedMovement = Vector3.zero;

        calculatedMovement = new Vector3(1f, 0f, 0f);

        if (Input.GetKey(KeyCode.W) == true)
        {
             calculatedMovement = new Vector3(1f, 1f);
            //rigidBody2D.AddForce(new Vector2(0f, verticalForce));
            //kan m�jligtvis raderas
        }

        if (Input.GetKey(KeyCode.S) == true)
        {
            calculatedMovement = new Vector3(1f, -1f);
        }
        calculatedMovement *= Time.deltaTime * movementSpeed;

        Move(calculatedMovement);
       
    }

    private void Move(Vector3 speed)
    {
        gameObject.transform.Translate(speed);
    }
}

/*ATT G�RA
 * Be ngn annan kolla p� koden
 * ska AddForce anv�ndas elr �r movementspeed b�ttre?
 * blir det problem om jag s�tter x till 1f n�r jag g�r upp/ner?
 * */