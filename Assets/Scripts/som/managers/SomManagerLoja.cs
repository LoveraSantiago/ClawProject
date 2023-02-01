using UnityEngine;

public class SomManagerLoja : SomManager,
                              SomTimerFicha
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

    //***** IMPLEMENTACAO SOMTIMERFICHA INICIO *****
    public void playSomCliqueIrParaLojaScene(){}
    //***** IMPLEMENTACAO SOMTIMERFICHA FIM *****
}
