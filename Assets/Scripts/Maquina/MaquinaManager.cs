using UnityEngine;

public class MaquinaManager : AcaoTempoEsgotado.ProdutorEvento,
                              AcaoColetado.ConsumidorEvento,    
                              AcaoSincroniaComDirecaoDaGarra.ConsumidorEvento,
                              AcaoPowerUpInicio.ConsumidorEvento,
                              AcaoPowerUpFim.ConsumidorEvento,
                              AcaoTempoEsgotado.ConsumidorEvento
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
        displayTimer       = new DisplayTimer(maquinaDto.DisplayTimerDto, monoBehaviour);
        joystick           = new Joystick(maquinaDto.JoystickDto, velocidadeJoystick);
        botoesPowerUp      = new BotoesPowerUp(maquinaDto.BotoesPowerUpDto, inputGame);

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
        displayDeColetados.adicionarSpriteAoDisplay(evento.sprite, evento.resultCombinacao);
        displayDeScores.mostrarScore(evento.score, evento.resultCombinacao);
    }

    void AcaoPowerUpInicio.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        arcoIrisEfeito.ligarEfeitoArcoIris();
        displayTimer.pause();
        displayDeScores.iniciarContagemRegressiva(evento.duracaoTempo);                
    }       

    void AcaoPowerUpFim.ConsumidorEvento.consumirEvento(PowerUpInfoFim evento)
    {
        if (evento.preFinalizar)
        {
            displayDeScores.piscarAsteriscos();
        }
        else if (evento.finalizar)
        {
            displayDeScores.finalizarContagemRegressiva();
            displayTimer.continuar();
            botoesPowerUp.reclicarProxPowerUp();
            arcoIrisEfeito.desligarEfeitoArcoIris();
        }        
    }

    void ProdutorConsumidoresDeEvento<TempoEsgotado>.ConsumidorEvento.consumirEvento(TempoEsgotado evento)
    {
        if (evento.restart)
        {
            displayTimer.pause();
            arcoIrisEfeito.ligarEfeitoRed();
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
}
