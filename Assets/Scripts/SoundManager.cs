using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public const string prefAudioMute = "prefAudioMute";

    public static SoundManager instance;

    [SerializeField] private Sound[] _audioClips;
    
    [Header("AudioMixer")]
    [SerializeField] AudioMixerGroup _MusicMixerGroup;
    [SerializeField] AudioMixerGroup _SFXMixerGroup;

    private void Awake()
    {
        instance = this;

        if (PlayerPrefs.HasKey(prefAudioMute))
        {
            AudioListener.volume = PlayerPrefs.GetFloat(prefAudioMute);
        }

        foreach(Sound _sounds in _audioClips)
        {
            _sounds._audioSource = gameObject.AddComponent<AudioSource>();

            _sounds._audioSource.clip = _sounds._audioClip;
            _sounds._audioSource.loop = _sounds._isLoop;
            _sounds._audioSource.volume = _sounds.volume;

            switch (_sounds._audioTypes)
            {
                case Sound.AudioTypes.SFX:
                    _sounds._audioSource.outputAudioMixerGroup = _SFXMixerGroup;
                    break;

                case Sound.AudioTypes.music:
                    _sounds._audioSource.outputAudioMixerGroup = _MusicMixerGroup;
                    break;

            }


            if (_sounds._playOnAwake)
            {
                _sounds._audioSource.Play();
            }
        }

    }

    public void PlayClipByName(string clipName)
    {
        Sound soundToPlay = Array.Find(_audioClips, SoundList => SoundList._clipName == clipName);
       
        if (soundToPlay == null)
        {
            Debug.LogError("Sound: " + clipName + " does NOT exist");
            return;
        }
        soundToPlay._audioSource.Play();
    }

    public void StopClipByName(string clipName)
    {
        Sound soundToStop = Array.Find(_audioClips, SoundList => SoundList._clipName == clipName);

        if (soundToStop == null)
        {
            Debug.LogError("Sound: " + clipName + " does NOT exist");
            return;
        }
        soundToStop._audioSource.Stop();
    }

    public void MuteSound()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }

        PlayerPrefs.SetFloat(prefAudioMute, AudioListener.volume);
    }

    public void UpdateMixerVolume()
    {
        _MusicMixerGroup.audioMixer.SetFloat("Music Volume", Mathf.Log10(SoundControl._musicVolume) * 20);
        _SFXMixerGroup.audioMixer.SetFloat("SFX Volume", Mathf.Log10(SoundControl._SFXVolume) * 20);
    }

    
}
