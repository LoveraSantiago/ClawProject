using System.Collections;
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

    public void playSomBumpTexto()
    {
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutinePlayBumpSongs());
    }

    private IEnumerator coroutinePlayBumpSongs()
    {
        yield return new WaitForSeconds(audioTitleDto.DelayBumpTexto1);
        audioSecundario.PlayOneShot(audioTitleDto.SomCliqueBotao);
        yield return new WaitForSeconds(audioTitleDto.DelayBumpTexto2);
        audioSecundario.PlayOneShot(audioTitleDto.SomCliqueBotao);
        yield return new WaitForSeconds(audioTitleDto.DelayBumpTexto3);
        audioSecundario.PlayOneShot(audioTitleDto.SomCliqueBotao);
        yield return new WaitForSeconds(audioTitleDto.DelayBumpEstrela);
        audioSecundario.PlayOneShot(audioTitleDto.SomBumpEstrelas);
        yield return null;
    }
}
