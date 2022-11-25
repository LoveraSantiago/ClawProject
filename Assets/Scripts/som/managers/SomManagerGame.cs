using UnityEngine;

public class SomManagerGame : SomManager,
                              SomGarra,
                              SomColetagem,
                              SomMaquina
{
    private AudioGameDto audioGameDto;

    public SomManagerGame(AudioGameDto audioDto) 
        : base(audioDto, 5)
    {
        this.audioGameDto = audioDto;
    }

    //***** IMPLEMENTACAO INTERFACE SOMMAQUINA INICIO *****
    public void playSomDisplayColetado()
    {
        audioPlayOneShot(getAudioSourceMaquinaDisplayColetados(), audioGameDto.SomMaqColetaveis);
    }

    public void stopSomMaqAlarme()
    {     
        getAudioSourceMaquinaTimer().Stop();
    }

    public void playSomMaqAlarme()
    {        
        audioPlay(getAudioSourceMaquinaTimer(), audioGameDto.SomMaqAlarme);
    }
    //***** IMPLEMENTACAO INTERFACE SOMMAQUINA FIM *****

    //***** IMPLEMENTACAO INTERFACE SOMGARRA INICIO *****
    public void playScoreColetagemNaoSucesso()
    {
        audioPlayOneShot(getAudioSourceColetaveis(), audioGameDto.SomCombinacaoNOK);
    }

    public void playScoreColetagemSucesso()
    {
        audioPlayOneShot(getAudioSourceColetaveis(), audioGameDto.SomCombinacaoOK);
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
        audioPlayOneShot(getAudioSourceGarraComplementar(), audioGameDto.SomGarraAgarrada);   
    }

    public void playSomGarraLateral()
    {
        audioPlayOneShot(getAudioSourceGarraComplementar(), audioGameDto.SomGarraLateral);
    }

    public void playSomGarraInicioDescida()
    {
        audioPlayOneShot(getAudioSourceGarraComplementar(), audioGameDto.SomGarraInicioDescida);
    }
    //***** IMPLEMENTACAO INTERFACE SOMGARRA FIM *****

    private AudioSource getAudioSourceGarraComplementar()
    {
        return getAudioSource(3);
    }

    private AudioSource getAudioSourceColetagem()
    {
        return getAudioSource(4);
    }

    private AudioSource getAudioSourceColetaveis()
    {
        return getAudioSource(5);
    }

    private AudioSource getAudioSourceMaquinaDisplayColetados()
    {
        return getAudioSource(6);
    }   

    private AudioSource getAudioSourceMaquinaTimer()
    {
        return getAudioSource(7);
    }    
}
