using System;
using UnityEngine;
using System.Collections.Generic;

public class MaquinaManager : ConsumidorDeEvento<InformacoesColetado>,
                              ConsumidorDeEvento<PowerUpInfoFim>
{    

    private DisplaysDeColetados displayDeColetados;
    private DisplayDeScores displayDeScores;
    private DisplayTimer displayTimer;

    private Joystick joystick;
    private BotoesPowerUp botoesPowerUp;

    private PartesMaquinaDto partesDto;

    //TODO RESOLVER EXCECO DE ARGUMENTOS NO CONSTRUTOR
    public MaquinaManager(MaquinaDto maquinaDto, float velocidadeJoystick, InputGame inputGame, MonoBehaviour monoBehaviour)
    {
        partesDto = maquinaDto.PartesDto;

        displayDeColetados = new DisplaysDeColetados(maquinaDto.DisplayDeColetadoDto, monoBehaviour);
        displayDeScores    = new DisplayDeScores(maquinaDto.DisplayDeScoreDto, monoBehaviour);
        displayTimer       = new DisplayTimer(maquinaDto.DisplayTimerDto);
        joystick           = new Joystick(maquinaDto.JoystickDto, velocidadeJoystick);
        botoesPowerUp      = new BotoesPowerUp(maquinaDto.BotoesPowerUpDto, inputGame);
    }

    public void configuradoPeloLevel(AbstractLevel levelEscolhido)
    {
        botoesPowerUp.configuradoPeloLevel(levelEscolhido);
        displayTimer.configuradoPeloLevel(levelEscolhido);
        colorindoPartesMaquina(levelEscolhido.getDicionarioDeCores());
        joystick.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());
    }

    public void start()
    {
        displayTimer.iniciarContagemTempo();
    }

    public void update()
    {
        botoesPowerUp.update();
        displayTimer.update();
    }

    public void fixedUpdate()
    {
        joystick.fixedUpdate();
    }   

    public void beginDragPowerUp(Vector2 posicao)
    {
        botoesPowerUp.beginDrag(posicao);
    }

    public void onDragPowerUp(Vector2 delta)
    {
        botoesPowerUp.drag(delta);
    }

    public void onEndDragPowerUp(MonoBehaviour monoBehaviour)
    {
        botoesPowerUp.endDrag(monoBehaviour);
    }

    private void processarInformacoesDoColetado(InformacoesColetado infoColetado)
    {        
        displayDeColetados.adicionarSpriteAoDisplay(infoColetado.sprite, infoColetado.resultCombinacao);
        displayDeScores.mostrarScore(infoColetado.score, infoColetado.resultCombinacao);
    }

    private void processarPreFimDePowerUp()
    {
        displayDeScores.piscarAsteriscos();
    }

    private void processarFimDePowerUp()
    {
        displayDeScores.mostrarPontuacaoAcumulada();
        botoesPowerUp.acionarFimPowerUp();
    }

    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<INFORMACOESCOLETADO> INICIO
    public void consumirEvento(InformacoesColetado infoColetado)
    {
        processarInformacoesDoColetado(infoColetado);
    }
    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<INFORMACOESCOLETADO> FIM

    //IMPLEMENTACAO CONSUMIDORDEEVENTO<INT> INICIO
    public void consumirEvento(PowerUpInfoFim powerUpInfoFim)
    {
        //Debug.Log("Maquina consumindo prefim " + powerUpInfoFim.preFinalizar);
        //Debug.Log("Maquina consumindo fim " + powerUpInfoFim.finalizar);
        if (powerUpInfoFim.preFinalizar)
        {     
            processarPreFimDePowerUp();
        }
        if (powerUpInfoFim.finalizar)
        {         
            processarFimDePowerUp();
        }
    }
    //IMPLEMENTACAO CONSUMIDORDEEVENTO<INT> FIM

    //CONSUMIDORES DE EVENTOS INICIO
    public ConsumidorDeEvento<DirecaoDaGarra> getJoystickHasteConsumidorDirecao()
    {
        return joystick.getConsumidorDeEventoDeDirecao();
    }    

    public ConsumidorDeEvento<InformacoesColetado> getConsumidorInfoColetado()
    {
        return this;
    }

    public ConsumidorDeEvento<PowerUpInfo> getConsumidorDePowerUpInfo()
    {
        return displayDeScores.getConsumidorDePowerUpInfo();
    }

    public ConsumidorDeEvento<PowerUpInfoFim> getConsumidorDePowerUpFim()
    {
        return this;
    }    
    //CONSUMIDORES DE EVENTOS FIM

    public ProdutorDeEvento<bool> produtorDeTempoAcabado()
    {
        return displayTimer.produtorDeEventoTempoEsgotado;
    }

    private void colorindoPartesMaquina(Dictionary<string, string> dicionarioCores)
    {        
        String corHex = dicionarioCores[ConstantesCoresMaquina.PLACA_CIMA];
        partesDto.PlacaCima.color = Utils.getCorByHex(corHex);

        corHex = dicionarioCores[ConstantesCoresMaquina.BASE_PARTE];
        Color cor = Utils.getCorByHex(corHex);
        partesDto.BaseParteCima.color = cor;
        partesDto.BaseParteBaixo.color = cor;

        corHex = dicionarioCores[ConstantesCoresMaquina.BASE_CHAO];
        partesDto.BaseChao.color = Utils.getCorByHex(corHex);

        corHex = dicionarioCores[ConstantesCoresMaquina.BORDA_VIDRO];
        partesDto.BordaVidro.color = Utils.getCorByHex(corHex);

        corHex = dicionarioCores[ConstantesCoresMaquina.PLACA_FRONTAL];
        partesDto.PlacaFrontal.color = Utils.getCorByHex(corHex);

        corHex = dicionarioCores[ConstantesCoresMaquina.BARRA];
        partesDto.Barra.color = Utils.getCorByHex(corHex);

        corHex = dicionarioCores[ConstantesCoresMaquina.CHAO_DENTRO];
        partesDto.ChaoDentro.color = Utils.getCorByHex(corHex);

        corHex = dicionarioCores[ConstantesCoresMaquina.TUBO];
        partesDto.Tubo.color = Utils.getCorByHex(corHex);

        corHex = dicionarioCores[ConstantesCoresMaquina.VIGA_TRAS];
        cor = Utils.getCorByHex(corHex);
        partesDto.VigaTrasDireita.color = cor;
        partesDto.VigaTrasEsquerda.color = cor;
    }
}
