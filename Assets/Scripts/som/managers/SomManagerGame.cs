using UnityEngine;

public class SomManagerGame : SomManager,
                              SomGarra,
                              SomColetagem,
                              SomMaquina
{
    private AudioGameDto audioGameDto;

    public SomManagerGame(AudioGameDto audioDto) 
        : base(audioDto, 2)
    {
        this.audioGameDto = audioDto;
    }

    //***** IMPLEMENTACAO INTERFACE SOMMAQUINA INICIO *****
    //***** IMPLEMENTACAO INTERFACE SOMMAQUINA FIM *****

    //***** IMPLEMENTACAO INTERFACE SOMGARRA INICIO *****
    public void playScoreColetagemNaoSucesso()
    {
        audioPlayOneShot(getAudioSourceMaquina(), audioGameDto.SomCombinacaoNOK);
    }

    public void playScoreColetagemSucesso()
    {
        audioPlayOneShot(getAudioSourceMaquina(), audioGameDto.SomCombinacaoOK);
    }

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

    public void playSomGarraAgarrando()
    {
        Debug.Log("Som Garra Agarrando");
        //audioPlayOneShot(getAudioSourceGarra(), audioGameDto.SomGarraAgarrada);   
        audioPlayOneShot(getAudioSourceColetagem(), audioGameDto.SomGarraAgarrada);   
    }

    public void playSomGarraInicioDescida()
    {
        audioPlayOneShot(getAudioSourceColetagem(), audioGameDto.SomInicioDescida);
    }
    //***** IMPLEMENTACAO INTERFACE SOMGARRA FIM *****

    private AudioSource getAudioSourceColetagem()
    {
        return getAudioSource(3);
    }

    private AudioSource getAudioSourceMaquina()
    {
        return getAudioSource(4);
    }
}
