using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    // AudioSource
    public AudioSource musicAudioSource;

    void Start()
    {
        // Müzik sesini yükle
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }

        // Her açıldığında sesi maksimuma ayarla
        volumeSlider.value = 1f;
        musicAudioSource.volume = 1f;
    }

    // Müzik sesini değiştir
    public void ChangeVolume()
    {
        musicAudioSource.volume = volumeSlider.value;
        Save();   
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        musicAudioSource.volume = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}