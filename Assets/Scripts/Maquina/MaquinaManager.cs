using UnityEngine;

public class MaquinaManager : AcaoTempoEsgotado.ProdutorEvento,
                              AcaoColetadoFim.ProdutorEvento,
                              AcaoColetado.ConsumidorEvento,                                
                              AcaoSincroniaComDirecaoDaGarra.ConsumidorEvento,
                              AcaoPowerUp.ConsumidorEvento,                                                            
                              AcaoBoardElevadoFim.ConsumidorEvento
{    
    private PartesMaquinaDto partesDto;

    private DisplaysDeColetados displayDeColetados;
    private DisplayDeScores displayDeScores;
    private DisplayTimer displayTimer;
    private VigasTras vigasTras;

    private Joystick joystick;
    private BotoesPowerUp botoesPowerUp;

    private ArcoIrisEfeito arcoIrisEfeito;
    
    public MaquinaManager(
        MaquinaDto maquinaDto, MonoBehaviour monoBehaviour)
    {
        partesDto = maquinaDto.PartesDto;

        displayDeColetados = new DisplaysDeColetados(maquinaDto.DisplayDeColetadoDto, monoBehaviour);
        displayDeScores    = new DisplayDeScores(maquinaDto.DisplayDeScoreDto, monoBehaviour);
        displayTimer       = new DisplayTimer(maquinaDto.DisplayTimerDto, monoBehaviour);
        joystick           = new Joystick(maquinaDto.JoystickDto);
        botoesPowerUp      = new BotoesPowerUp(maquinaDto.BotoesPowerUpDto);
        vigasTras          = new VigasTras(maquinaDto.VigasDto);

        arcoIrisEfeito = new ArcoIrisEfeito(monoBehaviour)
            .addArcoIrisConjunto(displayDeColetados.getDisplayColetadoGlow())
            .addArcoIrisConjunto(displayDeScores)
            .addArcoIrisConjunto(displayTimer.getDisplayTimerGlow(maquinaDto.DisplayTimerDto))
            .addArcoIrisConjunto(vigasTras);        
    }

    public void configuradoPeloLevel(AbstractLevel levelEscolhido)
    {
        botoesPowerUp.configuradoPeloLevel(levelEscolhido);
        joystick.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());
        displayDeColetados.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());
        displayDeScores.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());
        vigasTras.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());

        AntesExecutorTimerRestart executor = new AntesExecutorTimerRestart(botoesPowerUp, displayTimer, arcoIrisEfeito);
        displayTimer.configuradoPeloLevel(levelEscolhido, executor);

        new ColoridorMaquina()
            .colorir(partesDto, levelEscolhido.getDicionarioDeCores());
    }

    public void start()
    {
        displayTimer.iniciarContagemTempo();        
    }

    public void update(InputGame inputGame)
    {
        botoesPowerUp.update(inputGame);
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

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        displayTimer.pause();

        PosExecutorAcaoColetadoFim posExecucao = new PosExecutorAcaoColetadoFim(displayTimer, botoesPowerUp);
        displayDeColetados.mostrarColetadoNoDisplay(evento, arcoIrisEfeito, posExecucao);
        displayDeScores.mostrarScore(evento.score, evento.resultCombinacao);
        botoesPowerUp.suspenderPowerUp();
    }   

    void AcaoPowerUp.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        if (evento.isInicio())
        {
            displayDeColetados.processarPowerUp(evento.interacaoDisplayColetado);
            arcoIrisEfeito.ligarEfeitoArcoIris();
            displayTimer.pause();
            displayDeScores.iniciarContagemRegressiva(evento.duracaoTempo);
        }
        else if (evento.isPreFinalizar())
        {
            displayDeScores.piscarAsteriscos();
        }
        else if (evento.isFinalizar())
        {
            displayDeScores.finalizarContagemRegressiva();
            displayTimer.continuar();
            botoesPowerUp.reclicarProximoPowerUp();
            arcoIrisEfeito.desligarEfeito();
            displayDeColetados.processarFimPowerUp();
        }
    }              

    void AcaoBoardElevadoFim.ConsumidorEvento.consumirEvento(BoardAcaoFim evento)
    {
        if (!evento.isGameOver)
        {
            botoesPowerUp.reativarPowerUp();
            arcoIrisEfeito.desligarEfeito();
            displayTimer.continuar();
        }
    }   

    void AcaoSincroniaComDirecaoDaGarra.ConsumidorEvento.consumirEvento(DirecaoDaGarra evento)
    {
        ((AcaoSincroniaComDirecaoDaGarra.ConsumidorEvento)joystick).consumirEvento(evento);
    }

    ProdutorDeEvento<TempoEsgotado> AcaoTempoEsgotado.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return ((AcaoTempoEsgotado.ProdutorEvento)displayTimer).getProdutorDeEventoColetado();
    }

    ProdutorDeEvento<ColetadoFim> AcaoColetadoFim.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return ((AcaoColetadoFim.ProdutorEvento)displayDeColetados).getProdutorDeEventoColetado();
    }
}
