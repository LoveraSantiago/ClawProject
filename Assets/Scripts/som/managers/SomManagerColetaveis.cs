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

    public void playSomCliqueIrParaLojaScene()
    {
        playSomCliqueItem();
    }

    public AudioSource getComumAudioSource()
    {
        return getAudioSource(1);
    }
}
