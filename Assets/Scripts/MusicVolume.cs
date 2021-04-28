using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public Slider musicSlider;
    public AudioMixer musicAudioMixer;
    public float musicVolume;

    public void Start()
    {
        musicVolume = 1;
        musicSlider.value = musicVolume;
        musicAudioMixer.SetFloat("music", Mathf.Log10(musicSlider.value) * 20);
    }

    public void setMusicVolume(float m)
    {
        musicAudioMixer.SetFloat("music", Mathf.Log10(m) * 20);
        musicVolume = m;
    }
}
