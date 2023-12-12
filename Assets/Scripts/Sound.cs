using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Sound
{
    public enum AudioTypes { SFX, music}
    public AudioTypes _audioTypes;


    [HideInInspector] public AudioSource _audioSource;
    public AudioClip _audioClip;
    public string _clipName;
    public bool _isLoop;
    public bool _playOnAwake;
    
    [Range(0, 1)] public float volume;
}
