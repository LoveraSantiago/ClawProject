using UnityEngine;
public class SomManagerColetaveis : SomManager,
                                    SomTimerFicha
{
    private AudioColetaveisDto audioDto;

    public SomManagerColetaveis(AudioColetaveisDto audioDto) 
        : base(audioDto, 1)
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

    public AudioSource getComumAudioSource()
    {
        return getAudioSource(1);
    }
}
