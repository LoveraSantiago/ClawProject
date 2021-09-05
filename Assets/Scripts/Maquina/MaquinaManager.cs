using UnityEngine;

public class MaquinaManager : AcaoTempoEsgotado.ProdutorEvento,
                              AcaoColetadoFim.ProdutorEvento,
                              AcaoBotaoPUpVazio.ProdutorEvento,
                              AcaoCacaNiquel.ProdutorEvento,
                              AcaoColetado.ConsumidorEvento,                                
                              AcaoSincroniaComDirecaoDaGarra.ConsumidorEvento,
                              AcaoPUpAcionado.ConsumidorEvento,                                                            
                              AcaoBoardElevadoFim.ConsumidorEvento,
                              AcaoBBarPupEscolhido<PowerUpBtnInfo>.ConsumidorEvento
{    
    private PartesMaquinaDto partesDto;

    private Joystick joystick;
    private VigasTras vigasTras;
    private DisplayTimer displayTimer;
    private BotoesPowerUp botoesPowerUp;
    private ArcoIrisEfeito arcoIrisEfeito;
    private DisplayDeScores displayDeScores;    
    private DisplaysDeSlots displaysDeSlots;
    private BordasVidroFrente bordasFrenteVidro;
    
    public MaquinaManager(MaquinaDto maquinaDto, InputGame inputGame)
    {
        partesDto = maquinaDto.PartesDto;

        displaysDeSlots = new DisplaysDeSlots(maquinaDto.DisplaysSlotsDto, inputGame);        
        displayDeScores = new DisplayDeScores(maquinaDto.DisplayDeScoreDto);
        displayTimer    = new DisplayTimer(maquinaDto.DisplayTimerDto);
        joystick        = new Joystick(maquinaDto.JoystickDto);
        botoesPowerUp   = new BotoesPowerUp(maquinaDto.BotoesPowerUpDto);
        vigasTras       = new VigasTras(maquinaDto.VigasDto);
        bordasFrenteVidro = new BordasVidroFrente(maquinaDto.BordasFrenteDto);

        arcoIrisEfeito = new ArcoIrisEfeito(maquinaDto.FactorHdr)//REFATORAR FORMAS DE MONTAR CONJUNTO REVER INSTANCIAS DE MATERIALGLOW            
            .addArcoIrisConjunto(displaysDeSlots.getDisplayColetadoGlow())
            .addArcoIrisConjunto(displayDeScores)
            .addArcoIrisConjunto(displayTimer.getDisplayTimerGlow(maquinaDto.DisplayTimerDto))
            .addArcoIrisConjunto(vigasTras)
            .addArcoIrisConjunto(botoesPowerUp.getBotoesGlow())
            .addArcoIrisConjunto(bordasFrenteVidro);        
    }

    public void configuradoPeloLevel(AbstractLevel levelEscolhido)
    {
        botoesPowerUp.configuradoPeloLevel(levelEscolhido);
        joystick.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());        
        displaysDeSlots.configuradoPeloLevel(levelEscolhido);
        displayDeScores.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());
        vigasTras.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());
        bordasFrenteVidro.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());

        AntesExecutorTimerRestart executor = new AntesExecutorTimerRestart(botoesPowerUp, displayTimer, arcoIrisEfeito);
        displayTimer.configuradoPeloLevel(levelEscolhido, executor);

        new ColoridorMaquina()
            .colorir(partesDto, levelEscolhido.getDicionarioDeCores());
    }

    public void start()
    {
        displayTimer.iniciarContagemTempo();
        displaysDeSlots.iniciar();
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

    public void onEndDragPowerUp()
    {
        botoesPowerUp.endDrag();
    }

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        displayTimer.pause();

        PosExecutorAcaoColetadoFim posExecucao = new PosExecutorAcaoColetadoFim(displayTimer, botoesPowerUp);
        displaysDeSlots.mostrarColetadoNoDisplay(evento, arcoIrisEfeito, posExecucao);        
        displayDeScores.mostrarScore(evento.score, evento.resultCombinacao);
        botoesPowerUp.suspenderPowerUp();
    }   

    void AcaoPUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        if (evento.isInicio())
        {
            displaysDeSlots.processarPowerUp(evento.interacaoDisplayColetado);            
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
            botoesPowerUp.processarFimPowerUp();
            arcoIrisEfeito.desligarEfeito();
            displaysDeSlots.processarFimPowerUp(botoesPowerUp);            
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

    void AcaoBBarPupEscolhido<PowerUpBtnInfo>.ConsumidorEvento.consumirEvento(PowerUpBtnInfo evento)
    {
        ((AcaoBBarPupEscolhido<PowerUpBtnInfo>.ConsumidorEvento)botoesPowerUp).consumirEvento(evento);
    }

    ProdutorDeEvento<TempoEsgotado> AcaoTempoEsgotado.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoTempoEsgotado.ProdutorEvento)displayTimer).getProdutorDeEvento();
    }

    ProdutorDeEvento<ColetadoFim> AcaoColetadoFim.ProdutorEvento.getProdutorDeEvento()
    {        
        return ((AcaoColetadoFim.ProdutorEvento)displaysDeSlots).getProdutorDeEvento();
    }

    ProdutorDeEvento<int> AcaoBotaoPUpVazio.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoBotaoPUpVazio.ProdutorEvento)botoesPowerUp).getProdutorDeEvento();
    }

    ProdutorDeEvento<Vazio> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoCacaNiquel.ProdutorEvento)displaysDeSlots).getProdutorDeEvento();
    }
}
