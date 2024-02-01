using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public const string prefMainVolume = "prefMainVolume";
    public const string MusicVolume = "MusicVolume";
    public const string SFXVolume = "SFXVolume";
    public const string TurretVolume = "TurretVolume";
    public GameObject _information;

    public static float _musicVolume { get; private set; }
    public static float _SFXVolume { get; private set; }
    public static float _TurretVolume { get; private set; }

    public static SoundManager instance;

    [SerializeField] private Sound[] _audioClips;

    [SerializeField] Slider _mainVolume;
    [SerializeField] Slider MusicVolumeSlider;
    [SerializeField] Slider SFXVolumeSlider;
    [SerializeField] Slider TurretVolumeSlider;

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
    private void Update()
    {
        
    }
    private void Awake()
    {
        if (_information != null)
        {
            _information.SetActive(false);
        }
        instance = this;
        DontDestroyOnLoad(instance);

        if (PlayerPrefs.HasKey(prefMainVolume))
        {
            _mainVolume.value = PlayerPrefs.GetFloat(prefMainVolume);
            AudioListener.volume = _mainVolume.value;
        }
        if (PlayerPrefs.HasKey(MusicVolume))
        {
            MusicVolumeSlider.value = PlayerPrefs.GetFloat(MusicVolume,_musicVolume);

            Debug.Log("Load " + _musicVolume);
        }
        if (PlayerPrefs.HasKey(SFXVolume))
        {
            SFXVolumeSlider.value = PlayerPrefs.GetFloat(SFXVolume, _SFXVolume);
            Debug.Log("Load " + _SFXVolume);
        }
        if (PlayerPrefs.HasKey(TurretVolume))
        {
            TurretVolumeSlider.value = PlayerPrefs.GetFloat(TurretVolume, _TurretVolume);
            Debug.Log("Load " + _TurretVolume);
        }

        foreach (Sound _sounds in _audioClips)
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

    public void PlayOneClipByName(string clipName)
    {
        Sound soundToPlay = Array.Find(_audioClips, SoundList => SoundList._clipName == clipName);

        if (soundToPlay == null)
        {
            Debug.LogError("Sound: " + clipName + " does NOT exist");
            return;
        }

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

    public void UpdateMixerVolume()
    {
        _MusicMixerGroup.audioMixer.SetFloat(MusicVolume, Mathf.Log10(_musicVolume) * 20);
        _SFXMixerGroup.audioMixer.SetFloat(SFXVolume, Mathf.Log10(_SFXVolume) * 20);
        _TurretMixerGroup.audioMixer.SetFloat(TurretVolume, Mathf.Log10(_TurretVolume) * 20);
    }

    public void MainVolumeChanged(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat(prefMainVolume, value);
    }


    public void OnMusicSliderValueChange(float value)
    {
        _musicVolume = value;
        PlayerPrefs.SetFloat(MusicVolume, _musicVolume);
        UpdateMixerVolume();

    }

    public void OnSFXSliderValueChange(float value)
    {
        _SFXVolume = value;
        PlayerPrefs.SetFloat(SFXVolume, _SFXVolume);
        UpdateMixerVolume();
    }

    public void OnTurretSliderValueChange(float value)
    {
        _TurretVolume = value;
        PlayerPrefs.SetFloat(TurretVolume, _TurretVolume);
        UpdateMixerVolume();
    }
    

}
