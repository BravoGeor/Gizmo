using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SFSlider: MonoBehaviour
{
    public Slider sliderSF;
    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
           audioMixer.SetFloat("sfx", volume);
        SaveNumber();
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    void Start()
    {
        LoadNumber();
    }
    public void SaveNumber()
    {
        audioMixer.GetFloat("sfx", out float volume);
        Debug.Log($"Save sfx {volume}");
        PlayerPrefs.SetFloat("sfx", volume);
    }
    public void LoadNumber()
    {
        float loadedNumber = PlayerPrefs.GetFloat("sfx", 0f);
        Debug.Log($"loaded {loadedNumber}");
        sliderSF.value = loadedNumber;
    }

}

//Referanced Code https://youtu.be/zc8ac_qUXQY?si=S9OVOwa9kGSQgApV
