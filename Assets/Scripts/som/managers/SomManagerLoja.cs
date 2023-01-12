using UnityEngine;

public class SomManagerLoja : SomManager
{
    private AudioLojaDto audioDto;

    public SomManagerLoja(AudioLojaDto audioDto) 
        : base(audioDto, 1)
    {
        this.audioDto = audioDto;
    }

    public void playSomClique()
    {
        audioPlayOneShot(getComumAudioSource(), audioDto.SomClique);
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
