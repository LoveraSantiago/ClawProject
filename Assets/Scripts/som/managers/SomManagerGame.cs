using UnityEngine;

public class SomManagerGame : SomManager,
                              SomGarra,
                              SomColetagem,
                              SomMaquina,
                              SomPowerUp
{
    private AudioGameDto audioGameDto;

    public SomManagerGame(AudioGameDto audioDto) 
        : base(audioDto, 6)
    {
        this.audioGameDto = audioDto;
    }

    //***** IMPLEMENTACAO INTERFACE SOMMAQUINA INICIO *****
    public void playSomDisplayColetado()
    {
        audioPlayOneShot(getAudioSourceMaquinaDisplayColetados(), audioGameDto.SomMaqColetaveis);
    }

    public void stopSomMaqAlarmeTempo()
    {     
        getAudioSourceMaquinaTimer().Stop();
    }

    public void playSomMaqAlarmeTempo()
    {        
        audioPlay(getAudioSourceMaquinaTimer(), audioGameDto.SomMaqAlarme);
    }

    public void playSomMaqAlarmePowerUp()
    {
        audioPlay(getAudioSourceMaquinaScore(), audioGameDto.SomMaqAlarmeTimer);
    }

    public void stopSomMaqAlarmePowerUp()
    {
        getAudioSourceMaquinaScore().Stop();
    }

    public void playSomBotaoPowerUp()
    {
        audioPlayOneShot(getAudioSourceColetaveis(), audioGameDto.SomMaqCliqueBtn);
    }

    public void playSomCliqueScroll()
    {
        audioPlayOneShot(getAudioSourceColetaveis(), audioGameDto.SomMaqCliqueScroll);
    }

    public void playSomCliqueScrollCancel()
    {
        audioPlayOneShot(getAudioSourceColetaveis(), audioGameDto.SomMaqCliqueScrollCancel);
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

    public void playSomColetadosCaindo()
    {        
        audioPlayOneShot(getAudioSourceColetagem(), audioGameDto.SomColetadoCaindo);
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

    //***** IMPLEMENTACAO INTERFACE SOMPOWERUP INICIO *****
    public void playSomBackgroundNormal()
    {
        playSomBackground();
    }

    public void playSomBackgroundPowerUp()
    {
        audioPlay(getAudioSourceBackground(), audioGameDto.SomBackgroundPowerUp);
    }
    //***** IMPLEMENTACAO INTERFACE SOMPOWERUP INICIO *****

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

    private AudioSource getAudioSourceMaquinaScore()
    {
        return getAudioSource(8);
    }   
}
