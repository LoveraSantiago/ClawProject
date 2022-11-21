using UnityEngine;

public class SomManagerGame : SomManager,
                              SomGarra,
                              SomColetagem
{
    private AudioGameDto audioGameDto;

    public SomManagerGame(AudioGameDto audioDto) 
        : base(audioDto, 1)
    {
        this.audioGameDto = audioDto;
    }

    //***** IMPLEMENTACAO INTERFACE SOMGARRA INICIO *****
    public void playSomColetagem()
    {
        audioPlayOneShot(getAudioSourceColetagem(), audioGameDto.SomColetado);
    }
    //***** IMPLEMENTACAO INTERFACE SOMGARRA FIM *****

    //***** IMPLEMENTACAO INTERFACE SOMGARRA INICIO *****
    public void playSomGarraSubindo()
    {
        base.playSomGarraGirando();
    }

    public void stopSomGarraSubindo()
    {
        base.stopSomGarraGirando();
    }
    //***** IMPLEMENTACAO INTERFACE SOMGARRA FIM *****

    private AudioSource getAudioSourceColetagem()
    {
        return getAudioSource(3);
    }
}
