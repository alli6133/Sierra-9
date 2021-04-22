using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LaserCannon : MonoBehaviour
{
    public Rigidbody2D missile;
    public Button button;
    public GameObject player;
    public Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        playerPos = player.transform.position;
    }

    public void FireMissile()
    {
        Rigidbody2D clone;
        clone = Instantiate(missile, playerPos, transform.rotation);
        clone.velocity = new Vector2(13.0f, 0.0f);
    }


    /*Ett laserskott skjuts samtidigt som en UI-button trycks. 
     * Tidigare så sköt spelaren genom att trycka på nedre vänstra hörnet
     * med Input.touch.
     * Nu har jag ändrat så man trycker på en UI-button.
     * */
}
