//Axel Sterner
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LaserCannon : MonoBehaviour
{
    public Rigidbody2D missile;
    public Button button;
    public GameObject laserLauncher;
    public Vector3 launcherPos;
    public Rigidbody2D clone;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip firesound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        laserLauncher = GameObject.Find("laserLauncher");
        launcherPos = laserLauncher.transform.position;
    }

    public void FireMissile()
    {
        clone = Instantiate(missile,launcherPos,missile.transform.rotation);
        clone.velocity = new Vector2(13.0f, 0.0f);
        audioSource.PlayOneShot(firesound);

       
    }
    

    /*Ett laserskott skjuts samtidigt som en UI-button trycks. 
     * Tidigare så sköt spelaren genom att trycka på nedre vänstra hörnet
     * med Input.touch.
     * Nu har jag ändrat så man trycker på en UI-button.
     * */
}
