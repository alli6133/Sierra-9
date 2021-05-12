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
    private Rigidbody2D clone;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip firesound;

    private float laserCooldown = 0.3f;
    private float laserTimer;

    // Start is called before the first frame update
    void Start()
    {
        laserTimer = laserCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        laserLauncher = GameObject.Find("laserLauncher");
        launcherPos = laserLauncher.transform.position;
        laserTimer -= Time.deltaTime;

    }

    public void FireMissile()
    {
        if (laserTimer < 0)
        {
            clone = Instantiate(missile, launcherPos, missile.transform.rotation);
            clone.velocity = new Vector2(108.0f, 0.0f);
            audioSource.PlayOneShot(firesound);
            laserTimer = laserCooldown;
            Vibration.Vibrate(100);
        }
    }
}
