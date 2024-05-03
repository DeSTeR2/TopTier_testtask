using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource _audioSource;
    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audio) {
        _audioSource.PlayOneShot(audio);
    }

    public void PlaySound(AudioClip audio, float timeWait) {
        _audioSource.PlayOneShot(audio);
    }
}
