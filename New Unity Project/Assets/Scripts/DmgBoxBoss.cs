using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DmgBoxBoss : MonoBehaviour
{
    private GameObject enemyToKill;
    private GameObject missile;
    private bool removeGameObject = false;
    private float timer = 0f;
    private float timeBeforeEndScene = 10f;
    private float timeBeforeUIDisappears = 6f;
    private bool isUI = true;
    public AudioSource musicSource;
    public ParticleSystem dmgParticles;
    public ParticleSystem explosion;
    public GameObject whiteSquare;
    public GameObject shootButton;
    public GameObject healthBar;
    private BossBehaviour bossBehaviour;
    [SerializeField] private int HP = 20;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private AudioClip damageTakenClip;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        enemyToKill = gameObject.transform.parent.gameObject;
        bossBehaviour = (BossBehaviour)FindObjectOfType(typeof(BossBehaviour));
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
                bossBehaviour.disableMissiles();
                destroyBoss();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (removeGameObject == true)
        {
            musicSource.Stop();
            shootButton.SetActive(false);
            healthBar.SetActive(false);

            timer += Time.deltaTime;
            if (timer >= timeBeforeEndScene)
            {
                Destroy(enemyToKill);
                SceneManager.LoadScene("VictoryScene");
            }

            isUI = false;
        }

        if (!isUI)
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeUIDisappears)
            {
                StartCoroutine(FadeToWhiteSquare());
                isUI = true;
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
    }

    private IEnumerator FadeToWhiteSquare(bool fadeToWhite = true, int fadeSpeed = 1)
    {
        Color objectColor = whiteSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToWhite)
        {
            while (whiteSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                whiteSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }
}
