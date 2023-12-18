using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public const string prefAudioMute = "prefAudioMute";

    public static SoundManager instance;

    [SerializeField] private Sound[] _audioClips;

    [SerializeField] Slider _mainVolume;
    [SerializeField] GameObject _volumePanel;

    [Header("AudioMixer")]
    [SerializeField] AudioMixerGroup _MusicMixerGroup;
    [SerializeField] AudioMixerGroup _SFXMixerGroup;
    [SerializeField] AudioMixerGroup _TurretMixerGroup;

    private static SoundManager Referencia;
    public static SoundManager dameReferencia
    {
        get
        {
            if (Referencia == null)
            {
                Referencia = FindObjectOfType<SoundManager>();
                if (Referencia == null)
                {
                    GameObject go = new GameObject("SoundManager");
                    Referencia = go.AddComponent<SoundManager>();
                }
            }
            return Referencia;
        }
    }

    private void Awake()
    {
        
        instance = this;
        DontDestroyOnLoad(instance);

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

                case Sound.AudioTypes.turret:
                    _sounds._audioSource.outputAudioMixerGroup = _TurretMixerGroup;
                    break;

            }


            if (_sounds._playOnAwake)
            {
                _sounds._audioSource.Play();
            }
        }
        
        _mainVolume.value = AudioListener.volume;
        _mainVolume.onValueChanged.AddListener(MainVolumeChanged);
    }
    
   /* private void OnLevelWasLoaded(int level)
    {
        if(level == 1)
        {
            Debug.Log(" he entrado en el");
            _volumePanel = GameObject.FindGameObjectWithTag("VolumePanel");
            _volumePanel.SetActive(false);
           
        }
       
    }*/

    public void PlayClipByName(string clipName)
    {
        Sound soundToPlay = Array.Find(_audioClips, SoundList => SoundList._clipName == clipName);
       
        if (soundToPlay == null)
        {
            Debug.LogError("Sound: " + clipName + " does NOT exist");
            return;
        }

        Debug.Log("manager sonido");

        soundToPlay._audioSource.Play();
    }

    public void PlayOneClipByName(string clipName)
    {
        Sound soundToPlay = Array.Find(_audioClips, SoundList => SoundList._clipName == clipName);

        if (soundToPlay == null)
        {
            Debug.LogError("Sound: " + clipName + " does NOT exist");
            return;
        }

        Debug.Log("manager sonido");

        soundToPlay._audioSource.PlayOneShot(soundToPlay._audioClip);
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
        _TurretMixerGroup.audioMixer.SetFloat("Turret Volume", Mathf.Log10(SoundControl._SFXVolume) * 20);

    }

    public void MainVolumeChanged(float value)
    {
        AudioListener.volume = value;
    }

}
