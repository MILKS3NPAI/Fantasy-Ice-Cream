using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{   
    //TODO: Slider value doesn't keep its value when switching scenes
    public Slider slider;
    public float currentVolume;
    public AudioMixer audioMixer;

    public void Start()
    {
        slider.value = currentVolume;
    }

    public void setVolume(float v)
    {
        audioMixer.SetFloat("sound", Mathf.Log10(v) * 20);
        currentVolume = v;

    }
}
