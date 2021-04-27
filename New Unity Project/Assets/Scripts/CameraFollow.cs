//Axel Sterner
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject followTarget;

    private Vector3 offset = new Vector3(12f, 0f, -10);
    void Start()
    {
        //followTarget = GameObject.Find("Player"); //leta upp player och gör det till followTargets värde
    }


    void LateUpdate()//anropas när alla update-funktioner har exekverats
    {
        
    }
}
