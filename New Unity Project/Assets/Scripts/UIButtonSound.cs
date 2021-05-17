using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonPressClip;

    public void ButtonPressed()
    {
        audioSource.PlayOneShot(buttonPressClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
