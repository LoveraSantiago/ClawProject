using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioClip garra;

    public static AudioController current;
    private AudioSource audioSource;

    void Start() {
        current = this;
        audioSource = GetComponent<AudioSource>();
    }


    public void PlayAudio(AudioClip audioClip) {
        audioSource.PlayOneShot(audioClip);
    }


}
