using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SetMasterVolume : MonoBehaviour
{
    
    public AudioMixer mixer;

    public void SetLevel(float sliderValue) {
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
    }

}
