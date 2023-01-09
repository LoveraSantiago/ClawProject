using UnityEngine;

public class SomManagerPup : SomManager,
                             SomTimerFicha
{
    private AudioPupDto audioPupDto;

    public SomManagerPup(AudioPupDto audioPupDto)
        : base(audioPupDto, 1)
    {
        this.audioPupDto = audioPupDto;
    }

    public void playSomCliqueItem()
    {
        audioPlayOneShot(getComumAudioSource(), audioPupDto.SomClique);
    }

    public void playSomCliqueIrParaLojaScene()
    {
        playSomCliqueItem();
    }

    public AudioSource getComumAudioSource()
    {
        return getAudioSource(1);
    }
}
