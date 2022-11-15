using System.Collections;
using UnityEngine;

public class SomManagerTitle : SomLoading
{
    private AudioTitleDto audioTitleDto;
    private AudioSource audioSecundario;

    public SomManagerTitle(AudioTitleDto audioTitleDto)
    {
        this.audioTitleDto = audioTitleDto;
        audioSecundario = audioTitleDto.GoAudioSource.AddComponent<AudioSource>();

        audioPlay(audioTitleDto.MainAudioSource, audioTitleDto.SomBackground);        
        audioTitleDto.MainAudioSource.Play();
    }

    public void stopSomPrincipal()
    {
        audioTitleDto.MainAudioSource.Stop();
    }

    public void playSomBotaoClicado()
    {
        audioPlayOneShot(audioSecundario, audioTitleDto.SomCliqueBotao);        
    }

    public void playSomGarraAsSecundario()
    {        
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutinePlaySomGarra());
    }

    public void playGarraGirando()
    {
        audioPlay(audioTitleDto.MainAudioSource, audioTitleDto.SomGarra);
    }

    public void playSomBumpTexto()
    {
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutinePlayBumpSongs());
    }

    public void playSomAbrirModal()
    {
        audioPlayOneShot(audioSecundario, audioTitleDto.SomBatidaAbrirModal);
    }

    private void audioPlay(AudioSource audioSource, AudioClipDto audioClipDto)
    {
        audioSource.volume = audioClipDto.Volume;
        audioSource.clip = audioClipDto.AudioClip;
        audioSource.Play();
    }

    private void audioPlayOneShot(AudioSource audioSource, AudioClipDto audioClipDto)
    {
        audioSource.volume = audioClipDto.Volume;
        audioSource.PlayOneShot(audioClipDto.AudioClip);
    }

    private IEnumerator coroutinePlaySomGarra()
    {
        yield return new WaitForSeconds(audioTitleDto.DelayInicioSomGarra);

        AudioClipDto audioSomGarra = audioTitleDto.SomGarra;
        audioPlay(audioSecundario, audioSomGarra);        
        yield return new WaitForSeconds(audioTitleDto.DelayStopSomGarra);
        audioSecundario.Stop();
    }

    private IEnumerator coroutinePlayBumpSongs()
    {
        yield return new WaitForSeconds(audioTitleDto.DelayBumpTexto1);
        audioPlayOneShot(audioSecundario, audioTitleDto.SomCliqueBotao);
        yield return new WaitForSeconds(audioTitleDto.DelayBumpTexto2);
        audioPlayOneShot(audioSecundario, audioTitleDto.SomCliqueBotao);
        yield return new WaitForSeconds(audioTitleDto.DelayBumpTexto3);
        audioPlayOneShot(audioSecundario, audioTitleDto.SomCliqueBotao);
        yield return new WaitForSeconds(audioTitleDto.DelayBumpEstrela);
        audioPlayOneShot(audioSecundario, audioTitleDto.SomBumpEstrelas);
        yield return null;
    }
}
