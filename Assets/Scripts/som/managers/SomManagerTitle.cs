using System.Collections;
using UnityEngine;

public class SomManagerTitle : SomManager
{
    private AudioTitleDto audioTitleDto;    

    public SomManagerTitle(AudioTitleDto audioTitleDto)
        :base(audioTitleDto)
    {
        this.audioTitleDto = audioTitleDto;
        playSomBackground();
    }

    public void playSomBackground()
    {
        audioPlay(getAudioSourceBackground(), audioTitleDto.SomBackground);                
    }

    public void stopSomPrincipal()
    {
        audioTitleDto.MainAudioSource.Stop();
    }

    public void playSomBotaoClicado()
    {
        audioPlayOneShot(getAudioSourceUi(), audioTitleDto.SomCliqueBotao);        
    }

    public void playSomGarraAsSecundario()
    {        
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutinePlaySomGarraAbertura());
    }    

    public void playSomBumpTexto()
    {
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutinePlayBumpSongs());
    }         

    private IEnumerator coroutinePlaySomGarraAbertura()
    {
        yield return new WaitForSeconds(audioTitleDto.DelayInicioSomGarra);

        AudioClipDto audioSomGarra = audioTitleDto.SomGarra;
        audioPlay(getAudioSourceGarra(), audioSomGarra);        
        yield return new WaitForSeconds(audioTitleDto.DelayStopSomGarra);
        getAudioSourceGarra().Stop();
    }

    private IEnumerator coroutinePlayBumpSongs()
    {
        yield return new WaitForSeconds(audioTitleDto.DelayBumpTexto1);
        audioPlayOneShot(getAudioSourceUi(), audioTitleDto.SomCliqueBotao);
        yield return new WaitForSeconds(audioTitleDto.DelayBumpTexto2);
        audioPlayOneShot(getAudioSourceUi(), audioTitleDto.SomCliqueBotao);
        yield return new WaitForSeconds(audioTitleDto.DelayBumpTexto3);
        audioPlayOneShot(getAudioSourceUi(), audioTitleDto.SomCliqueBotao);
        yield return new WaitForSeconds(audioTitleDto.DelayBumpEstrela);
        audioPlayOneShot(getAudioSourceUi(), audioTitleDto.SomBumpEstrelas);
        yield return null;
    }
}
