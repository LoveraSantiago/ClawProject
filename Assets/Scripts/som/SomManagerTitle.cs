using System.Collections;
using UnityEngine;

public class SomManagerTitle : SomManager
{
    private AudioTitleDto audioTitleDto;    

    public SomManagerTitle(AudioTitleDto audioTitleDto)
        :base(audioTitleDto, 1)
    {
        this.audioTitleDto = audioTitleDto;
        playSomBackground();
    }

    public void playSomBackground()
    {
        audioPlay(getAudioSource(0), audioTitleDto.SomBackground);                
    }

    public void stopSomPrincipal()
    {
        audioTitleDto.MainAudioSource.Stop();
    }

    public void playSomBotaoClicado()
    {
        audioPlayOneShot(getAudioSource(1), audioTitleDto.SomCliqueBotao);        
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
        audioPlay(getAudioSource(1), audioSomGarra);        
        yield return new WaitForSeconds(audioTitleDto.DelayStopSomGarra);
        getAudioSource(1).Stop();
    }

    private IEnumerator coroutinePlayBumpSongs()
    {
        yield return new WaitForSeconds(audioTitleDto.DelayBumpTexto1);
        audioPlayOneShot(getAudioSource(1), audioTitleDto.SomCliqueBotao);
        yield return new WaitForSeconds(audioTitleDto.DelayBumpTexto2);
        audioPlayOneShot(getAudioSource(1), audioTitleDto.SomCliqueBotao);
        yield return new WaitForSeconds(audioTitleDto.DelayBumpTexto3);
        audioPlayOneShot(getAudioSource(1), audioTitleDto.SomCliqueBotao);
        yield return new WaitForSeconds(audioTitleDto.DelayBumpEstrela);
        audioPlayOneShot(getAudioSource(1), audioTitleDto.SomBumpEstrelas);
        yield return null;
    }
}
