using UnityEngine;
using UnityEngine.UI;

public class SettingsPage : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        musicSlider.value = AudioManager.Instance.musicVolume;
        sfxSlider.value = AudioManager.Instance.sfxVolume;

        musicSlider.onValueChanged.AddListener(delegate { AudioManager.Instance.SetMusicVolume(musicSlider.value); });
        sfxSlider.onValueChanged.AddListener(delegate { AudioManager.Instance.SetSFXVolume(sfxSlider.value); });
    }
}
