using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    public static float _musicVolume { get; private set; } = 1f;
    public static float _SFXVolume { get; private set; } = 1f;
    public static float _TurretVolume { get; private set; } = 1f;


    private void Start()
    {
        SoundManager.instance.LoadMixerVolume();

    }

    public void OnMusicSliderValueChange(float value)
    {
        _musicVolume = value;
        SoundManager.instance.UpdateMixerVolume();
    }

    public void OnSFXSliderValueChange(float value)
    {
        _SFXVolume = value;
        SoundManager.instance.UpdateMixerVolume();
    }

    public void OnTurretSliderValueChange(float value)
    {
        _TurretVolume = value;
        SoundManager.instance.UpdateMixerVolume();
    }

    public void GuardarValoresAudioMixer()
    {
        SoundManager.instance.SaveMixerVolume();
    }

    public void CargarValoresAudioMixer()
    {
        SoundManager.instance.LoadMixerVolume();
    }


}
