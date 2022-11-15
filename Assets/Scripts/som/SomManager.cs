using UnityEngine;

public abstract class SomManager : SomLoading
{
    private AudioDto audioDto;
    private AudioSource[] audiosSources;

    protected SomManager(AudioDto audioDto, int qtdAudioSources)
    {
        this.audioDto = audioDto;
        audiosSources = new AudioSource[qtdAudioSources + 1];
        audiosSources[0] = audioDto.MainAudioSource;

        for(int contador = 0; contador < qtdAudioSources; contador++)
        {
            audiosSources[contador + 1] = audioDto.GoAudioSource.AddComponent<AudioSource>();
        } 
    }

    protected void audioPlay(AudioSource audioSource, AudioClipDto audioClipDto)
    {
        audioSource.volume = audioClipDto.Volume;
        audioSource.clip = audioClipDto.AudioClip;
        audioSource.Play();
    }

    protected void audioPlayOneShot(AudioSource audioSource, AudioClipDto audioClipDto)
    {
        audioSource.volume = audioClipDto.Volume;
        audioSource.PlayOneShot(audioClipDto.AudioClip);
    }

    protected AudioSource getAudioSource(int indice)
    {
        return audiosSources[indice];
    }

    //***** IMPLEMENTACAO INTERFACE SOMLOADING INICIO *****
    public void playGarraGirando()
    {
        audioPlay(getAudioSource(1), audioDto.SomGarra);
    }

    public void playSomAbrirModal()
    {
        Debug.Log("Som abrir modal chamado");
        AudioSource audioSource = getAudioSource(1);
        audioSource.clip = null;
        audioPlayOneShot(audioSource, audioDto.SomBatidaAbrirModal);
    }
    //***** IMPLEMENTACAO INTERFACE SOMLOADING FIM *****
}
