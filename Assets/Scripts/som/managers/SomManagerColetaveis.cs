using UnityEngine;
public class SomManagerColetaveis : SomManager,
                                    SomTimerFicha, 
                                    SomModalNoFicha
{
    private AudioColetaveisDto audioDto;

    public SomManagerColetaveis(AudioColetaveisDto audioDto) 
        : base(audioDto, 2)
    {
        this.audioDto = audioDto;
    }

    public void playSomCliqueItem()
    {
        audioPlayOneShot(getComumAudioSource(), audioDto.SomClique);
    }

    public void playSomCliqueVoltar()
    {
        audioPlayOneShot(getComumAudioSource(), audioDto.SomCliqueVoltar);
    }

    public void playSomCliqueIrParaLojaScene()
    {
        playSomCliqueItem();
    }

    public void playSomCliqueColetavel()
    {
        audioPlayOneShot(getComumAudioSource(), audioDto.SomCliqueColetavel);
    }

    public void playSomZoomArmario()
    {
        audioPlayOneShot(getReservaAudioSource(), audioDto.SomZoomArmario);
    }

    public void playSomCliqueIrParaGame()
    {
        audioPlayOneShot(getComumAudioSource(), audioDto.SomStartGame);
    } 

    public void playSomClique()
    {
        playSomCliqueColetavel();
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
