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

    public void stopSomPrincipal()
    {
        audioTitleDto.MainAudioSource.Stop();
    }

    public void playSomBumpTexto()
    {
        audioPlayOneShot(getAudioSourceUi(), audioTitleDto.SomBumpTexto);        
    }

    public void playSomStart()
    {
        audioPlayOneShot(getAudioSourceUi(), audioTitleDto.SomStart);
    }

    public void playSomGarraAsSecundario()
    {        
        ContextoEstaticoUtils.monoBehaviour.StartCoroutine(coroutinePlaySomGarraAbertura());
    }    

    public void playSonsBumpsDeTexto()
    {
        ContextoEstaticoUtils.monoBehaviour.StartCoroutine(coroutinePlayBumpSongs());
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
        playSomBumpTexto();
        yield return new WaitForSeconds(audioTitleDto.DelayBumpTexto2);
        playSomBumpTexto();
        yield return new WaitForSeconds(audioTitleDto.DelayBumpTexto3);
        playSomBumpTexto();
        yield return new WaitForSeconds(audioTitleDto.DelayBumpEstrela);
        audioPlayOneShot(getAudioSourceUi(), audioTitleDto.SomBumpEstrelas);
        yield return null;
    }
}
