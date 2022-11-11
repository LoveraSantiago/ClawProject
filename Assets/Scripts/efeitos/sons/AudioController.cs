using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioClip garra;
    public AudioClip combinacaoOk;
    public AudioClip combinacaoNok;
    public AudioClip coletar;

    public static AudioController current;
    private AudioSource audioSourceGeneral;
    private AudioSource audioSourceGarra;

    void Start() {
        Debug.Log("audiocontroller iniciado");
        current = this;
        audioSourceGeneral = GetComponent<AudioSource>();
        audioSourceGarra   = gameObject.AddComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip audioClip) {
        audioSourceGeneral.PlayOneShot(audioClip);
    }

    public void PlayAudioGarra() {
        audioSourceGarra.clip = garra;
        audioSourceGarra.Play();
    }

    public void StopAudioGarra() {
        audioSourceGarra.Stop();
    }


}
