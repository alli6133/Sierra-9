using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject followTarget;

    private Vector3 offset = new Vector3(12f, 0f, -10);
    public float smoothSpeed = 0.5f;
    void Start()
    {
        followTarget = GameObject.Find("Player"); //leta upp player och gör det till followTargets värde
    }


    void LateUpdate()//anropas när alla update-funktioner har exekverats
    {
        Vector3 desiredPosition = followTarget.transform.position + offset;//kameran hamnar på spelarens position, Z -10.
        Vector3 smoothPosition = Vector3.Lerp(gameObject.transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        //spelarens aktuella värde och de önskade värdet adderas det räknas ut på en viss tid.
        //detta för att kameran ska flytta på sig långsamt
        gameObject.transform.position = smoothPosition;
    }
}
