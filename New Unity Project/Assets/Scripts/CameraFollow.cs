//Axel Sterner
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /*public TouchMovement tm;
    private Vector3 myPosition;
    [SerializeField] private float speed; 

    private Vector3 offset = new Vector3(5f, 0f, -10);
    void Start()
    {
        myPosition = gameObject.transform.position;
    }

    void LateUpdate()//anropas när alla update-funktioner har exekverats
    {
        speed = tm.movementSpeed;
        transform.position = myPosition + transform.right * Time.time * speed;
    }*/
    public Transform target;
    public TouchMovement tm;
    [SerializeField] private float speed;


    void LateUpdate()//anropas när alla update-funktioner har exekverats
    {
        speed = tm.movementSpeed;
        transform.position = new Vector3(target.position.x + 40, transform.position.y, -10);
    }

}
