using UnityEngine;

public class MaquinaManager : AcaoTempoEsgotado.ProdutorEvento,
                              AcaoColetadoFim.ProdutorEvento,
                              AcaoColetado.ConsumidorEvento,    
                              AcaoSincroniaComDirecaoDaGarra.ConsumidorEvento,
                              AcaoPowerUp.ConsumidorEvento,                              
                              AcaoTempoEsgotado.ConsumidorEvento,
                              AcaoBoardElevadoFim.ConsumidorEvento,
                              AcaoColetadoFim.ConsumidorEvento
{    
    private PartesMaquinaDto partesDto;

    private DisplaysDeColetados displayDeColetados;
    private DisplayDeScores displayDeScores;
    private DisplayTimer displayTimer;
    private VigasTras vigasTras;

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
        vigasTras          = new VigasTras(maquinaDto.VigasDto);

        arcoIrisEfeito = new ArcoIrisEfeito(monoBehaviour)
            .addArcoIrisConjunto(displayDeColetados)
            .addArcoIrisConjunto(displayDeScores)
            .addArcoIrisConjunto(displayTimer.getDisplayTimerGlow())
            .addArcoIrisConjunto(vigasTras);        
    }

    public void configuradoPeloLevel(AbstractLevel levelEscolhido)
    {
        botoesPowerUp.configuradoPeloLevel(levelEscolhido);
        displayTimer.configuradoPeloLevel(levelEscolhido);
        joystick.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());
        displayDeColetados.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());
        displayDeScores.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());
        vigasTras.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());

        new ColoridorMaquina()
            .colorir(partesDto, levelEscolhido.getDicionarioDeCores());
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

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        displayTimer.pause();
        displayDeColetados.adicionarSpriteAoDisplay(arcoIrisEfeito, evento.sprite, evento.resultCombinacao);
        displayDeScores.mostrarScore(evento.score, evento.resultCombinacao);
    }

    void AcaoPowerUp.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        if (evento.isInicio())
        {
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
            botoesPowerUp.reclicarProxPowerUp();
            arcoIrisEfeito.desligarEfeito();
        }
    }           

    void ProdutorConsumidoresDeEvento<TempoEsgotado>.ConsumidorEvento.consumirEvento(TempoEsgotado evento)
    {
        if (evento.restart)
        {
            botoesPowerUp.desativarPowerUp();
            displayTimer.pause();
            arcoIrisEfeito.ligarBlinkRed();
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

    void AcaoColetadoFim.ConsumidorEvento.consumirEvento(ColetadoFim evento)
    {
        displayTimer.continuar();
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
