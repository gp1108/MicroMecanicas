using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    [Header("Main")]
    public Slider _volumeSlider;
    public float _sliderValue;

    [Header("SFX")]
    public Slider _SFXvolumeSlider;
    public float _SFXsliderValue;

    // Start is called before the first frame update
    void Start()
    {
        _volumeSlider.value = PlayerPrefs.GetFloat("AudioVolume", 50f);
        _SFXvolumeSlider.value = PlayerPrefs.GetFloat("SFXAudioVolume", 50f);
        AudioListener.volume = _volumeSlider.value;
        AudioListener.volume = _SFXvolumeSlider.value;
    }

    public void ChangeSlider(float _value)
    {
        _sliderValue = _value;
        PlayerPrefs.SetFloat("AudioVolume", _sliderValue);
        AudioListener.volume = _volumeSlider.value;
    }
    /*
    public void ChangeSFXSlider(float _SFXvalue)
    {
        _SFXsliderValue = _SFXvalue;
        PlayerPrefs.SetFloat("SFXAudioVolume", _SFXsliderValue);
        AudioListener.volume = _SFXvolumeSlider.value;
    }*/

}
