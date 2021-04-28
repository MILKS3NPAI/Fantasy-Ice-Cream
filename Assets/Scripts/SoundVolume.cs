using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundVolume : MonoBehaviour
{
    public Slider soundSlider;
    public AudioMixer soundAudioMixer;
    public float soundVolume;

    public void Start()
    {
        soundVolume = 1;
        soundSlider.value = soundVolume;
        soundAudioMixer.SetFloat("sound", Mathf.Log10(soundSlider.value) * 20);
    }
    public void setSoundVolume(float s)
    {
        soundAudioMixer.SetFloat("sound", Mathf.Log10(s) * 20);
        soundVolume = s;
    }
}