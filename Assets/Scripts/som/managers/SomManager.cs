using UnityEngine;

public abstract class SomManager : SomLoading
{
    private float volume;
    private AudioDto audioDto;
    private AudioSource[] audiosSources;

    protected SomManager(AudioDto audioDto):
        this(audioDto, 0)
    {
    }

    public void trocarVolume(float volume) 
    {
        this.volume = volume;
        getAudioSourceBackground().volume = audioDto.SomBackground.Volume * volume;        
    }

    protected SomManager(AudioDto audioDto, int qtdAudioSources)
    {
        volume = PlayerPrefsVolume.recuperarVolume();
        this.audioDto = audioDto;
        audiosSources = new AudioSource[3 + qtdAudioSources];
        audiosSources[0] = audioDto.MainAudioSource;
        audiosSources[0].priority = audiosSources.Length;

        for (int contador = 1; contador < audiosSources.Length; contador++)
        {
            audiosSources[contador] = audioDto.GoAudioSource.AddComponent<AudioSource>();
            audiosSources[contador].priority = audiosSources.Length - contador;
        } 
    }

    public virtual void playSomBackground()
    {
        audioPlay(getAudioSourceBackground(), audioDto.SomBackground);
    }

    protected void audioPlay(AudioSource audioSource, AudioClipDto audioClipDto)
    {
        //Debug.Log("audioPlay " + audioClipDto.AudioClip.name);
        audioSource.volume = audioClipDto.Volume * volume;
        audioSource.clip = audioClipDto.AudioClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    protected void audioPlayOneShot(AudioSource audioSource, AudioClipDto audioClipDto)
    {
        //Debug.Log("audioPlayOneShot " + audioClipDto.AudioClip.name);
        audioSource.PlayOneShot(audioClipDto.AudioClip, audioClipDto.Volume * volume);
    }

    protected AudioSource getAudioSourceBackground()
    {
        return getAudioSource(0);
    }

    protected AudioSource getAudioSourceGarra()
    {
        return getAudioSource(1);
    }

    protected AudioSource getAudioSourceUi()
    {
        return getAudioSource(2);
    }

    protected AudioSource getAudioSource(int indice)
    {
        return audiosSources[indice];
    }

    //***** IMPLEMENTACAO INTERFACE SOMLOADING INICIO *****
    public void playSomGarraGirando()
    {
        audioPlay(getAudioSource(1), audioDto.SomGarra);
    }

    public void stopSomGarraGirando()
    {
        getAudioSourceGarra().Stop();
    }

    public void playSomBumpModal()
    {        
        AudioSource audioSource = getAudioSourceUi();        
        audioPlayOneShot(audioSource, audioDto.SomBatidaAbrirModal);
    }

    public void stopSomBackground()
    {
        getAudioSourceBackground().Stop();
    }
    //***** IMPLEMENTACAO INTERFACE SOMLOADING FIM *****
}
