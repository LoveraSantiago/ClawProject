using UnityEngine;

public class SomManagerPup : SomManager,
                             SomTimerFicha,
                             SomModalNoFicha
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

    public void playSomClique()
    {
        audioPlayOneShot(getComumAudioSource(), audioDto.SomCliqueItem);
    }

    public void playSomCliqueCancelar()
    {
        audioPlayOneShot(getComumAudioSource(), audioDto.SomCancelar);
    }

    public void playSomAbrirModal()
    {
        audioPlayOneShot(getComumAudioSource(), audioDto.AbrirModal);
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
