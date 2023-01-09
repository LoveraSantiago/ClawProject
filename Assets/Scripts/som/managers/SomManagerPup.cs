using UnityEngine;

public class SomManagerPup : SomManager,
                             SomTimerFicha
{
    private AudioPupDto audioDto;

    public SomManagerPup(AudioPupDto audioDto)
        : base(audioDto, 1)
    {
        this.audioDto = audioDto;
    }

    public void playSomCliqueItem()
    {
        audioPlayOneShot(getComumAudioSource(), audioDto.SomClique);
    }

    public void playSomCliqueIrParaLojaScene()
    {
        playSomCliqueItem();
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
