using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _controlAudio;

    [SerializeField] private AudioClip [] _audioClips;

    private void Awake()
    {
        _controlAudio = GetComponent<AudioSource>();
    }

    public void ControlAudios(int numAudio, float volumen)
    {
        _controlAudio.PlayOneShot(_audioClips[numAudio], volumen);
    }
}
