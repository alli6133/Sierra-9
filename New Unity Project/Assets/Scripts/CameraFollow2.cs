using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
<<<<<<< Updated upstream
    public TouchMovement tm;
    private Vector3 myPosition;
    [SerializeField] private float speed; 

    private Vector3 offset = new Vector3(12f, 0f, -10);
    void Start()
    {
        myPosition = gameObject.transform.position;
        speed = tm.movementSpeed;
=======
    // Start is called before the first frame update
    private Vector3 myPosition;
    [SerializeField] private float speed = 5f; 

    private Vector3 offset = new Vector3(5f, 0f, -10);
    void Start()
    {
        myPosition = gameObject.transform.position;
>>>>>>> Stashed changes
    }


    void LateUpdate()//anropas när alla update-funktioner har exekverats
    {
        transform.position = myPosition + transform.right * Time.time * speed;
    }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
}
