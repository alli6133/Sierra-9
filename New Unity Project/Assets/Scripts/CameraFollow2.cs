using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    public TouchMovement tm;
    private Vector3 myPosition;
    [SerializeField] private float speed; 

    private Vector3 offset = new Vector3(12f, 0f, -10);
    void Start()
    {
        myPosition = gameObject.transform.position;
        speed = tm.movementSpeed;
    }


    void LateUpdate()//anropas när alla update-funktioner har exekverats
    {
        transform.position = myPosition + transform.right * Time.time * speed;
    }

}
