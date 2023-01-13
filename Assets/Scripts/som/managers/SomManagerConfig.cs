using UnityEngine;

public class SomManagerConfig : SomManager
{
    private AudioConfigDto audioDto;

    public SomManagerConfig(AudioConfigDto audioDto) 
        : base(audioDto, 1)
    {
        this.audioDto = audioDto;
    }

    public void playSomCliqueVoltar()
    {
        audioPlayOneShot(getComumAudioSource(), audioDto.SomCliqueVoltar);
    }

    public AudioSource getComumAudioSource()
    {
        return getAudioSource(1);
    }
}
