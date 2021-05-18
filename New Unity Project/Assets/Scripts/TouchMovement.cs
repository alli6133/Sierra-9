//Axel Sterner

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{
    public float movementSpeed = 5f;

    private float width = (float)Screen.width / 2f;
    private float height = (float)Screen.height / 2f;
    private float maxYPos;
    private float minYPos;

    private bool maxYPosReached;
    private bool minYPosReached;
    private bool maxMinPosReached;

    private Vector3 myPosition;
    private Rigidbody2D rigidBody2D;
    

    void Start()
    {
        maxYPos = GameObject.Find("MaxYPos").GetComponent<Transform>().position.y;
        minYPos = GameObject.Find("MinYPos").GetComponent<Transform>().position.y;
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        rigidBody2D.gravityScale = 0;
    }

    void Update()
    {
        Vector3 calculatedMovement = Vector3.zero;
        calculatedMovement = new Vector3(1f, 0f, 0f);

        myPosition = gameObject.transform.position;

        maxMinYPosChecker();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            bool top = false;
            bool right = false;
            if (touch.phase == TouchPhase.Stationary && touch.deltaPosition.magnitude < 10f)
            {
                if (touch.position.y > height / 2)
                {
                    top = true;
                }

                if (touch.position.x > width / 2)
                {
                    right = true;
                }
                else if (top && !right)
                {
                    calculatedMovement = new Vector3(1f, 3f);
                }
                else if (!top && !right)
                {
                    calculatedMovement = new Vector3(1f, -3f);
                }
                
              
                if (maxYPosReached || minYPosReached)
                {
                    calculatedMovement = new Vector3(1f, 0f);
                }
            }
            else
            {
                calculatedMovement = new Vector3(1f, 0f);

                if (maxYPosReached)
                {
                    calculatedMovement = new Vector3(1f, -3f);
                }
                
                if (minYPosReached)
                {
                    calculatedMovement = new Vector3(1f, 3f);
                }
            }
        }

        calculatedMovement *= Time.deltaTime * movementSpeed;
        Move(calculatedMovement);
    }

    private void Move(Vector3 speed)
    {
        if (speed.y >= 0f && !maxYPosReached || speed.y <= 0f && !minYPosReached)
        {
            gameObject.transform.Translate(speed);
        }
    }

    private void maxMinYPosChecker()
    {
        if (myPosition.y >= maxYPos)
        {
            maxYPosReached = true;
        }
        else
        {
            maxYPosReached = false;
        }

        if (myPosition.y <= minYPos)
        {
            minYPosReached = true;
        }
        else
        {
            minYPosReached = false;
        }
    }
}

/*
 *      ATT GÖRA
 *finjustera touch-magnitud
 *sätt kontrollerna till övre och nedersta vänstra hörnet
*/
