using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetVol (float sliderValue){
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
}
