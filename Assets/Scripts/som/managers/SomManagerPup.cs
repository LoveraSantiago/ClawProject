using UnityEngine;

public class SomManagerPup : SomManager,
                             SomTimerFicha
{
    private AudioPupDto audioDto;

    public SomManagerPup(AudioPupDto audioDto)
        : base(audioDto, 2)
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

    public void playSomMovimentoCard()
    {
        audioPlayOneShot(getReservaAudioSource(), audioDto.SomCliqueCard);
    }

    public void playSomCliqueIrParaLevel()
    {
        audioPlayOneShot(getReservaAudioSource(), audioDto.SomStartGame);
    }

    public AudioSource getComumAudioSource()
    {
        return getAudioSource(1);
    }

    public AudioSource getReservaAudioSource()
    {
        return getAudioSource(2);
    }
}
