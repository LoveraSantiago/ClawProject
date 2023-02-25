using UnityEngine;

public class SomManagerGame : SomManager,
                              SomGarra,
                              SomColetagem,
                              SonsDeMaquina,
                              SomMaquina,
                              SomCacaNiquel,
                              SomPowerUp,
                              SomModais
{
    private AudioGameDto audioDto;

    public SomManagerGame(AudioGameDto audioDto) 
        : base(audioDto, 7)
    {
        this.audioDto = audioDto;
    }

    //***** IMPLEMENTACAO INTERFACE SOMMAQUINA INICIO *****
    public void playSomDisplayColetado()
    {
        audioPlayOneShot(getAudioSourceMaquinaDisplayColetados(), audioDto.SomMaqColetaveis);
    }

    public void stopSomMaqAlarmeTempo()
    {     
        getAudioSourceMaquinaTimer().Stop();
    }

    public void playSomMaqAlarmeTempo()
    {        
        audioPlay(getAudioSourceMaquinaTimer(), audioDto.SomMaqAlarme);
    }

    public void playSomMaqAlarmePowerUp()
    {
        audioPlay(getAudioSourceMaquinaScore(), audioDto.SomMaqAlarmeTimer);
    }

    public void stopSomMaqAlarmePowerUp()
    {
        getAudioSourceMaquinaScore().Stop();
    }

    public void playSomBotaoPowerUp()
    {
        audioPlayOneShot(getAudioSourceColetaveis(), audioDto.SomMaqCliqueBtn);
    }

    public void playSomCliqueScroll()
    {
        audioPlayOneShot(getAudioSourceColetaveis(), audioDto.SomMaqCliqueScroll);
    }

    public void playSomCliqueScrollCancel()
    {
        audioPlayOneShot(getAudioSourceColetaveis(), audioDto.SomMaqCliqueScrollCancel);
    }

    public void playSomLedsBlink()
    {
        //Debug.Log("Blink score");
        audioPlayOneShot(getAudioSourceMaquinaTimer(), audioDto.SomMaqBlinkTimer);
    }
    //***** IMPLEMENTACAO INTERFACE SOMMAQUINA FIM *****

    //***** IMPLEMENTACAO INTERFACE SOMGARRA INICIO *****
    public void playScoreColetagemNaoSucesso()
    {
        audioPlayOneShot(getAudioSourceColetaveis(), audioDto.SomCombinacaoNOK);
    }

    public void playScoreColetagemSucesso()
    {
        audioPlayOneShot(getAudioSourceColetaveis(), audioDto.SomCombinacaoOK);
    }

    public void playSomColetagem()
    {
        audioPlayOneShot(getAudioSourceColetagem(), audioDto.SomColetado);
    }

    public void playSomColetadosCaindo()
    {        
        audioPlayOneShot(getAudioSourceColetagem(), audioDto.SomColetadoCaindo);
    }

    public void playSomColetadosNoTubo()
    {        
        audioPlayOneShot(getAudioSourceMaquinaDisplayColetados(), audioDto.SomColetadoNoTubo);
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
        audioPlayOneShot(getAudioSourceGarraComplementar(), audioDto.SomGarraAgarrada);   
    }

    public void playSomGarraLateral()
    {
        audioPlayOneShot(getAudioSourceGarraComplementar(), audioDto.SomGarraLateral);
    }

    public void playSomGarraInicioDescida()
    {
        audioPlayOneShot(getAudioSourceGarraComplementar(), audioDto.SomGarraInicioDescida);
    }
    //***** IMPLEMENTACAO INTERFACE SOMGARRA FIM *****

    //***** IMPLEMENTACAO INTERFACE SOMPOWERUP INICIO *****
    public void playSomBackgroundNormal()
    {
        playSomBackground();
    }

    public void playSomBackgroundPowerUp()
    {
        if (isSomBackgroundLigado)
        {
            audioPlay(getAudioSourceBackground(), audioDto.SomBackgroundPowerUp);
        }
    }

    public void playSomExplosao()
    {
        audioPlayOneShot(getAudioSourcePowerUp(), audioDto.SomExplosao);
    }

    public void playSomMissil()
    {
        audioPlayOneShot(getAudioSourcePowerUp(), audioDto.SomMissil);
    }

    public void playSomTeleporte()
    {
        audioPlayOneShot(getAudioSourcePowerUp(), audioDto.SomTeleporte);
    }

    public void playSomAnjo()
    {
        audioPlayOneShot(getAudioSourcePowerUp(), audioDto.SomAnjo);
    }
    public void playSomChoque()
    {
        audioPlayOneShot(getAudioSourcePowerUp(), audioDto.SomChoque);
    }

    public void iniciarSomAsa()
    {
        audioPlay(getAudioSourcePowerUp(), audioDto.SomAsa);
    }

    public void pararSomAsa()
    {
        getAudioSourcePowerUp().Stop();
    }


    public void iniciarSomBuracoNegro()
    {
        audioPlay(getAudioSourcePowerUp(), audioDto.SomBuracoNegro);
    }

    public void pararSomBuracoNegro()
    {
        pararSomAsa();
    }
    //***** IMPLEMENTACAO INTERFACE SOMPOWERUP FIM *****

    //***** IMPLEMENTACAO INTERFACE SOMMODAIS INICIO *****
    public void playSomAbrirModal()
    {
        audioPlayOneShot(getAudioSourceGarraComplementar(), audioDto.SomAbrirModal);
    }

    public void playSomCliquePositivo()
    {
        playSomCliqueScroll();
    }

    public void playSomCliqueNegativo()
    {
        playSomCliqueScrollCancel();
    }

    public void playSomSucessoAbrirModal()
    {
        audioPlayOneShot(getAudioSourceGarraComplementar(), audioDto.SomAbrirModalSucesso);
    }
    //***** IMPLEMENTACAO INTERFACE SOMMODAIS INICIO *****

    //***** IMPLEMENTACAO INTERFACE SomCacaNiquel INICIO *****
    public void playSomBackgroundCacaNiquel()
    {
        if (isSomBackgroundLigado)
        {
            audioPlay(getAudioSourceBackground(), audioDto.SomBackgroundCacaNiquel);
        }
    }

    public void iniciarSomSlotsMovimento()
    {
        audioPlay(getAudioSourcePowerUp(), audioDto.SomSlotCacaNiquel);
    }
    public void pararSomSlotsMovimento()
    {
        getAudioSourcePowerUp().Stop();
    }

    public void playSomCacaNiquelSucesso()
    {
        playScoreColetagemSucesso();
    }

    public void playSomCacaNiquelFail()
    {
        playScoreColetagemNaoSucesso();
    }

    public void playSomCacaNiquelCoin()
    {
        audioPlayOneShot(getAudioSourceColetaveis(), audioDto.SomCoin);
    }

    public void playSomMola()
    {
        audioPlayOneShot(getAudioSourcePowerUp(), audioDto.SomMola);
    }
    //***** IMPLEMENTACAO INTERFACE SomCacaNiquel FIM    *****

    private AudioSource getAudioSourceGarraComplementar()
    {
        return getAudioSource(3);
    }

    private AudioSource getAudioSourceColetagem()
    {
        return getAudioSource(8);
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
        return getAudioSource(4);
    }

    private AudioSource getAudioSourcePowerUp()
    {
        return getAudioSource(9);
    }    
}
