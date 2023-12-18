using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    public static float _musicVolume {  get; private set; }
    public static float _SFXVolume { get; private set; }

    public static float _TurretVolume { get; private set; }

    private const string prefMusicVolume = "prefMusicVolume";
    private const string prefSFXVolume = "prefSFXVolume";
    private const string prefTurretVolume = "prefTurretVolume";

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

        if (PlayerPrefs.HasKey(prefTurretVolume))
        {
            _TurretVolume = PlayerPrefs.GetFloat(prefTurretVolume);
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

    public void OnTurretSliderValueChange(float value)
    {
        _TurretVolume = value;
        SoundManager.instance.UpdateMixerVolume();
        PlayerPrefs.SetFloat(prefSFXVolume, _TurretVolume);
    }

}
