//Axel Sterner

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{
    Vector3 myPosition;
    private Rigidbody2D rigidBody2D;
    public float movementSpeed = 5f;
    public float screenHeight;

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
            bool top = false;
            bool right = false;
            if (touch.phase == TouchPhase.Stationary && touch.deltaPosition.magnitude < 10f)
            {
                if (touch.position.y > screenHeight / 2)
                {
                    calculatedMovement = new Vector3(1f, 3f);
                    top = true;
                    //vertical = 1.0f;
                }
                if (touch.position.y < screenHeight / 2)
                {
                    calculatedMovement = new Vector3(1f, -3f);
                    //vertical = -1.0f;
                }

                if (touch.position.x > Screen.width / 2f)
                {
                    right = true;
                }
            }
            else
            {
                calculatedMovement = new Vector3(1f, 0f);
            }
        }
        calculatedMovement *= Time.deltaTime * movementSpeed;
        Move(calculatedMovement);
    }

    private void Move(Vector3 speed)
    {
        gameObject.transform.Translate(speed);
    }
}

/*
 *      ATT GÖRA
 *finjustera touch-magnitud
 *sätt kontrollerna till övre och nedersta vänstra hörnet
*/
