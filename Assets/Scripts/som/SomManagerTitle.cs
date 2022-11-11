using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomManagerTitle
{
    private AudioTitleDto audioTitleDto;
    private AudioSource audioSecundario;

    public SomManagerTitle(AudioTitleDto audioTitleDto)
    {
        this.audioTitleDto = audioTitleDto;
        audioSecundario = audioTitleDto.GoAudioSource.AddComponent<AudioSource>();

        audioTitleDto.MainAudioSource.clip = audioTitleDto.SomBackground;
        audioTitleDto.MainAudioSource.Play();
    }

    public void playSomBotaoClicado()
    {        
        audioSecundario.PlayOneShot(audioTitleDto.SomCliqueBotao);
    }
}
