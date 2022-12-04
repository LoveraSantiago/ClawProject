using UnityEngine;

public class SomManagerLevel : SomManager
{
    private AudioLevelDto audioDto;

    public SomManagerLevel(AudioLevelDto audioDto) 
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
