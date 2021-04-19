using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{

    Vector3 myPosition;
    private Rigidbody2D rigidBody2D;
    public float movementSpeed = 5f;
    private float moveDirection = 0f;
    public float verticalForce = 4;
    public float screenHeight;

    //private float vertical = 0;
    

    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        myPosition = gameObject.transform.position;
        rigidBody2D.gravityScale = 0;

        screenHeight = Screen.height;
        
    }

    void Update()
    {
        Vector3 calculatedMovement = Vector3.zero;

        calculatedMovement = new Vector3(1f, 0f, 0f);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log(touch.deltaPosition.magnitude);
            if (touch.phase == TouchPhase.Stationary && touch.deltaPosition.magnitude < 8000f)
            {
                if (touch.position.y > screenHeight / 2)
                {
                    calculatedMovement = new Vector3(1f, 1f);
                    //vertical = 1.0f;

                }
                if (touch.position.y < screenHeight / 2)
                {
                    calculatedMovement = new Vector3(1f, -1f);
                    //vertical = -1.0f;
                }
            }
            else
            {
                calculatedMovement = new Vector3(0f, 0f);
            }
        }
        calculatedMovement *= Time.deltaTime * movementSpeed;
        Move(calculatedMovement);
    }

    /*private void FixedUpdate()
    {
        rigidBody2D.AddForce(new Vector2(horizontal *(movementSpeed * 20f) * Time.deltaTime, 0));
    }*/

    private void Move(Vector3 speed)
    {
        gameObject.transform.Translate(speed);
    }
}
