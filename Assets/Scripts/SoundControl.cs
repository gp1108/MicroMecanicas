using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    public static float _musicVolume {  get; private set; }
    public static float _SFXVolume { get; private set; }

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
}
