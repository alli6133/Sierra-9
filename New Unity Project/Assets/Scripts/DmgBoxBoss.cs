using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DmgBoxBoss : MonoBehaviour
{
    private GameObject enemyToKill;
    private GameObject missile;
    private bool removeGameObject = false;
    private float timer = 0f;
    public ParticleSystem dmgParticles;
    public ParticleSystem explosion;
    [SerializeField] private int HP = 20;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private AudioClip damageTakenClip;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float timeBeforeDeletion = 5f;
    
    void Start()
    {
        enemyToKill = gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile") == true)
        {
            audioSource.PlayOneShot(damageTakenClip);
            HP--;
            Destroy(missile);

            if(HP <= 15)
            {
                dmgParticles.Play();
            }

            if (HP == 0) {
                destroyBoss();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (removeGameObject == true)
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeDeletion)
            {
                Destroy(enemyToKill);
                SceneManager.LoadScene("VictoryScene");
            }
        }

        missile = GameObject.Find("Missile(Clone)");
    }

    private void destroyBoss()
    {
        dmgParticles.Stop();
        explosion.Play();
        audioSource.PlayOneShot(deathClip);
        spriteRenderer.sprite = null;
        GetComponent<CircleCollider2D>().enabled = false; //stänger av collidern, undviker buggar
        removeGameObject = true;
        //Destroy(enemyToKill);
    }

}
