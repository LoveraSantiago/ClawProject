using UnityEngine;

public class MaquinaManager : Consumidor<InformacoesColetado>,
                              Consumidor<PowerUpInfo>,
                              Consumidor<PowerUpInfoFim>
{    
    private PartesMaquinaDto partesDto;

    private Elevador elevador;
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
        displayTimer       = new DisplayTimer(maquinaDto.DisplayTimerDto, monoBehaviour);
        joystick           = new Joystick(maquinaDto.JoystickDto, velocidadeJoystick);
        botoesPowerUp      = new BotoesPowerUp(maquinaDto.BotoesPowerUpDto, inputGame);
        elevador           = new Elevador(maquinaDto.ElevadorDto, monoBehaviour);

        arcoIrisEfeito = new ArcoIrisEfeito(monoBehaviour)
            .addArcoIrisConjunto(displayDeColetados)
            .addArcoIrisConjunto(displayDeScores)
            .addArcoIrisConjunto(displayTimer.getDisplayTimerGlow());
    }

    public void configuradoPeloLevel(AbstractLevel levelEscolhido)
    {
        botoesPowerUp.configuradoPeloLevel(levelEscolhido);
        displayTimer.configuradoPeloLevel(levelEscolhido);
        joystick.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());
        displayDeColetados.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());
        displayDeScores.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());

        new ColoridorMaquina()
            .colorir(partesDto, levelEscolhido.getDicionarioDeCores());

        displayTimer.getInnerProdutorDeEventoTempoRestart()
                    .registrarConsumidorDeEvento(elevador);
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
        displayTimer.pause();
        displayDeScores.iniciarContagemRegressiva(pupInfo.duracaoTempo);        
    }

    private void processarPreFimDePowerUp()
    {
        displayDeScores.piscarAsteriscos();
    }

    private void processarFimDePowerUp()
    {
        displayDeScores.finalizarContagemRegressiva();
        displayTimer.continuar();
        botoesPowerUp.reclicarProxPowerUp();        
        arcoIrisEfeito.desligarEfeitoArcoIris();
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

    public ProdutorDeEvento<bool> produtorEventoElevador()
    {
        return elevador.produtorEventoElevador;
    }
}
