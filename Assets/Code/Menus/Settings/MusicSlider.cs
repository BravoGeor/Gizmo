using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicSlider : MonoBehaviour
{
    public Slider sliderMusic;

    public AudioMixer audioMixer;
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        SaveNumber();
    }

  public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    void Start ()
    {
        LoadNumber();
    }

    public void SaveNumber()
    {
        audioMixer.GetFloat("Volume" , out float volume);
        Debug.Log($"Save volume {volume}");
        PlayerPrefs.SetFloat("Volume", volume);
    }
    public void LoadNumber()
    {
        float loadedNumber = PlayerPrefs.GetFloat("Volume" ,0f);
        Debug.Log($"loaded {loadedNumber}");
        sliderMusic.value = loadedNumber;
        SetVolume( loadedNumber );  
    }
}

//Referanced Code https://youtu.be/zc8ac_qUXQY?si=S9OVOwa9kGSQgApV
