using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCannon : MonoBehaviour
{
    public Rigidbody2D missile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);//ändra siffran vid problem
            if (touch.phase == TouchPhase.Began)
            {
                if (Input.GetKeyDown(KeyCode(Q)) == true)
                {
                    Rigidbody2D clone;
                    clone = Instantiate(missile, transform.position, transform.rotation);
                    clone.velocity = new Vector2(13.0f, 0.0f);
                }
            }
        }

    }

    /*Ett laserskott skjuts samtidigt som Q trycks ner. 
     * måste minska eldhastigheten
     * 
     * */
}
