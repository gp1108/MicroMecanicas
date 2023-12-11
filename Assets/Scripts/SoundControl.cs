using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    public static float _musicVolume {  get; private set; }
    public static float _SFXVolume { get; private set; }

    private const string prefMusicVolume = "prefMusicVolume";
    private const string prefSFXVolume = "prefSFXVolume";

    private void Start()
    {
        if (PlayerPrefs.HasKey(prefMusicVolume))
        {
            _musicVolume = PlayerPrefs.GetFloat(prefMusicVolume);
        }

        if (PlayerPrefs.HasKey(prefSFXVolume))
        {
            _SFXVolume = PlayerPrefs.GetFloat(prefSFXVolume);
        }
    }

    public void OnMusicSliderValueChange(float value)
    {
        _musicVolume = value;
        SoundManager.instance.UpdateMixerVolume();
        PlayerPrefs.SetFloat(prefMusicVolume, _musicVolume);
    }

    public void OnSFXSliderValueChange(float value)
    {
        _SFXVolume = value;
        SoundManager.instance.UpdateMixerVolume();
        PlayerPrefs.SetFloat(prefSFXVolume, _SFXVolume);
    }
}
