using System;
using UnityEngine;
using System.Collections.Generic;

public class MaquinaManager : Consumidor<InformacoesColetado>,
                              Consumidor<PowerUpInfo>,
                              Consumidor<PowerUpInfoFim>
{    

    private PartesMaquinaDto partesDto;

    private DisplaysDeColetados displayDeColetados;
    private DisplayDeScores displayDeScores;
    private DisplayTimer displayTimer;

    private Joystick joystick;
    private BotoesPowerUp botoesPowerUp;

    private ArcoIrisEfeito arcoIrisEfeito;

    //TODO RESOLVER EXCECO DE ARGUMENTOS NO CONSTRUTOR
    public MaquinaManager(MaquinaDto maquinaDto, float velocidadeJoystick, InputGame inputGame, MonoBehaviour monoBehaviour)
    {
        partesDto = maquinaDto.PartesDto;

        displayDeColetados = new DisplaysDeColetados(maquinaDto.DisplayDeColetadoDto, monoBehaviour);
        displayDeScores    = new DisplayDeScores(maquinaDto.DisplayDeScoreDto, monoBehaviour);
        displayTimer       = new DisplayTimer(maquinaDto.DisplayTimerDto);
        joystick           = new Joystick(maquinaDto.JoystickDto, velocidadeJoystick);
        botoesPowerUp      = new BotoesPowerUp(maquinaDto.BotoesPowerUpDto, inputGame);

        arcoIrisEfeito = new ArcoIrisEfeito(monoBehaviourM);
    }

    public void configuradoPeloLevel(AbstractLevel levelEscolhido)
    {
        botoesPowerUp.configuradoPeloLevel(levelEscolhido);
        displayTimer.configuradoPeloLevel(levelEscolhido);
        colorindoPartesMaquina(levelEscolhido.getDicionarioDeCores());
        joystick.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());
        displayDeColetados.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());
        displayDeScores.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());
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

    private void processarInicioPowerUp(PowerUpInfo pupInfo)
    {
        arcoIrisEfeito.ligarEfeitoArcoIris();
        displayDeScores.iniciarContagemRegressiva(pupInfo.duracaoTempo);
        displayDeColetados.acionadoPeloPowerUp();
    }

    private void processarPreFimDePowerUp()
    {
        displayDeScores.piscarAsteriscos();
    }

    private void processarFimDePowerUp()
    {
        displayDeScores.finalizarContagemRegressiva();
        botoesPowerUp.reclicarProxPowerUp();
        displayDeColetados.acionadoFimPowerUp();
    }

    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<INFORMACOESCOLETADO> INICIO
    public void consumir(InformacoesColetado infoColetado)
    {
        processarInformacoesDoColetado(infoColetado);
    }
    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<INFORMACOESCOLETADO> FIM

    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<PowerUpInfo> INICIO
    public void consumir(PowerUpInfo evento)
    {
        processarInicioPowerUp(evento);
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<PowerUpInfo> INICIO       

    //IMPLEMENTACAO CONSUMIDORDEEVENTO<INT> INICIO
    public void consumir(PowerUpInfoFim pupFim)
    {
        //Debug.Log("Maquina consumindo prefim " + powerUpInfoFim.preFinalizar);
        //Debug.Log("Maquina consumindo fim " + powerUpInfoFim.finalizar);
        if (pupFim.preFinalizar)
        {     
            processarPreFimDePowerUp();
        }
        else if (pupFim.finalizar)
        {         
            processarFimDePowerUp();
        }
    }
    //IMPLEMENTACAO CONSUMIDORDEEVENTO<INT> FIM

    //CONSUMIDORES DE EVENTOS INICIO
    public Consumidor<DirecaoDaGarra> getJoystickHasteConsumidorDirecao()
    {
        return joystick.getConsumidorDeEventoDeDirecao();
    }    

    public Consumidor<InformacoesColetado> getConsumidorInfoColetado()
    {
        return this;
    }

    public Consumidor<PowerUpInfo> getConsumidorDePowerUpInfo()
    {
        return this;
    }

    public Consumidor<PowerUpInfoFim> getConsumidorDePowerUpFim()
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

        corHex = dicionarioCores[ConstantesCoresMaquina.PLACA_SAIDA];
        partesDto.PlacaDeSaida.color = Utils.getCorByHex(corHex);

        corHex = dicionarioCores[ConstantesCoresMaquina.TUBO];
        Color corTubo = Utils.getCorByHex(corHex);
        corTubo.a = 0.88f;
        partesDto.Tubo.color = corTubo;        

        corHex = dicionarioCores[ConstantesCoresMaquina.VIGA_TRAS];
        cor = Utils.getCorByHex(corHex);
        partesDto.VigaTrasDireita.color = cor;
        partesDto.VigaTrasEsquerda.color = cor;

        corHex = dicionarioCores[ConstantesCoresMaquina.PLACA_FICHA];
        partesDto.PlacaFicha.color = Utils.getCorByHex(corHex);

        corHex = dicionarioCores[ConstantesCoresMaquina.PLACA_P_CIMA];
        partesDto.PlacaParteCima.color = Utils.getCorByHex(corHex);

        corHex = dicionarioCores[ConstantesCoresMaquina.PLACA_P_BAIXO];
        partesDto.PlacaParteBaixo.color = Utils.getCorByHex(corHex);

        corHex = dicionarioCores[ConstantesCoresMaquina.QUADRADO_MAIOR];
        partesDto.QuadMaior.color = Utils.getCorByHex(corHex);

        corHex = dicionarioCores[ConstantesCoresMaquina.QUADRADO_MENOR];
        partesDto.QuadMenor.color = Utils.getCorByHex(corHex);

        corHex = dicionarioCores[ConstantesCoresMaquina.FURO_CIMA];
        partesDto.FuroCima.color = Utils.getCorByHex(corHex);

        corHex = dicionarioCores[ConstantesCoresMaquina.FURO_BAIXO];
        partesDto.FuroBaixo.color = Utils.getCorByHex(corHex);
    }
}
