//Axel Sterner
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject followTarget;
    private Vector3 myPosition;
    [SerializeField] private float speed = 5f; 

    private Vector3 offset = new Vector3(12f, 0f, -10);
    void Start()
    {
        myPosition = gameObject.transform.position;
    }


    void LateUpdate()//anropas när alla update-funktioner har exekverats
    {
        transform.position = myPosition + transform.right * Time.time * speed;
    }
}
