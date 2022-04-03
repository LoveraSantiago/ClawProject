using UnityEngine;

public class MaquinaManager : AcaoTempoEsgotado.ProdutorEvento,
                              AcaoColetadoFim.ProdutorEvento,
                              AcaoBotaoPowerUpVazio.ProdutorEvento,
                              AcaoCacaNiquel.ProdutorEvento,
                              AcaoDesligarMaquina.ProdutorEvento,
                              AcaoColetado.ConsumidorEvento,                                
                              AcaoSincroniaComDirecaoDaGarra.ConsumidorEvento,
                              AcaoPowerUpAcionado.ConsumidorEvento,                                                            
                              AcaoBoardElevadoFim.ConsumidorEvento,
                              AcaoBBarItemEscolhido<PowerUpBtnInfo>.ConsumidorEvento,
                              AcaoDesligarMaquinaResultado.ConsumidorEvento
{    
    private PartesMaquinaDto partesDto;

    private Joystick            joystick;    
    private VigaParteV2         vigaEsquerda;
    private VigaParteV2         vigaDireita;
    private DisplayTimer        displayTimer;
    private BotoesPowerUp       botoesPowerUp;
    private BotaoLigaDesliga    botaoLigaDesliga;
    private ArcoIrisEfeito      arcoIrisEfeito;
    private DisplayDeScores     displayDeScores;    
    public  DisplaysDeSlots     displaysDeSlots { get; private set; }
    private BordasVidroFrenteV2 bordasFrenteVidro;
    private TudoDeSaidaV2       tuboDeSaida;
    private ChaoV2              chao;
    private BarraV2             barra;

    public MaquinaManager(MaquinaDto maquinaDto)
    {
        partesDto = maquinaDto.PartesDto;

        displaysDeSlots   = new DisplaysDeSlots(maquinaDto.DisplaysSlotsDto);        
        displayDeScores   = new DisplayDeScores(maquinaDto.DisplayDeScoreDto);
        displayTimer      = new DisplayTimer(maquinaDto.DisplayTimerDto);
        joystick          = new Joystick(maquinaDto.JoystickDto);
        botoesPowerUp     = new BotoesPowerUp(maquinaDto.BotoesPowerUpDto);
        botaoLigaDesliga  = new BotaoLigaDesliga(maquinaDto.BotaoLigaDesligaDto);        
        vigaEsquerda      = new VigaParteV2(maquinaDto.VigaLadoEsquerdoDto);
        vigaDireita       = new VigaParteV2(maquinaDto.VigaLadoDireitoDto);
        bordasFrenteVidro = new BordasVidroFrenteV2(maquinaDto.BordasFrenteDto);
        tuboDeSaida       = new TudoDeSaidaV2(maquinaDto.TuboDto);
        chao              = new ChaoV2(maquinaDto.ChaoDto);
        barra             = new BarraV2(maquinaDto.BarraDto);

        arcoIrisEfeito = new ArcoIrisEfeito(maquinaDto.FactorHdr)//REFATORAR FORMAS DE MONTAR CONJUNTO REVER INSTANCIAS DE MATERIALGLOW            
            .addArcoIrisConjunto(displaysDeSlots.getDisplayColetadoGlow())
            .addArcoIrisConjunto(displayDeScores)
            .addArcoIrisConjunto(displayTimer.getDisplayTimerGlow(maquinaDto.DisplayTimerDto))            
            .addArcoIrisConjunto(vigaEsquerda)
            .addArcoIrisConjunto(vigaDireita)
            .addArcoIrisConjunto(botoesPowerUp.getBotoesGlow())
            .addArcoIrisConjunto(bordasFrenteVidro)
            .addArcoIrisConjunto(tuboDeSaida)
            .addArcoIrisConjunto(chao)
            .addArcoIrisConjunto(barra);        
    }

    public void configuradoPeloLevel(AbstractLevel levelEscolhido, MaquinaDto maquinaDto)
    {
        botoesPowerUp.configuradoPeloLevel(levelEscolhido);
        joystick.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());        
        displaysDeSlots.configuradoPeloLevel(levelEscolhido, maquinaDto.DisplaysSlotsDto);
        displayDeScores.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());        
        vigaEsquerda.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());
        vigaDireita.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());
        bordasFrenteVidro.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());
        tuboDeSaida.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());
        chao.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());

        AntesExecutorTimerRestart executor = new AntesExecutorTimerRestart(botoesPowerUp, arcoIrisEfeito);
        displayTimer.configuradoPeloLevel(levelEscolhido, executor);

        new ColoridorMaquinaV2()
            .colorir(partesDto, levelEscolhido.getDicionarioDeCores());
    }

    public void start(InputGame inputGame)
    {
        displayTimer.iniciarContagemTempo();
        displaysDeSlots.iniciar(inputGame);
    }

    public void update(MaquinaDto maquinaDto, InputGame inputGame)
    {
        botoesPowerUp.update(maquinaDto.BotoesPowerUpDto, inputGame);
        botaoLigaDesliga.update(inputGame);
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

    public void onDragPowerUp(Vector2 delta, MaquinaDto maquinaDto)
    {
        botoesPowerUp.drag(delta, maquinaDto.BotoesPowerUpDto);
    }

    public void onEndDragPowerUp(MaquinaDto maquinaDto)
    {
        botoesPowerUp.endDrag(maquinaDto.BotoesPowerUpDto);
    }

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        displayTimer.pause();

        PosExecutorAcaoColetadoFim posExecucao = new PosExecutorAcaoColetadoFim(displayTimer, botoesPowerUp);
        displaysDeSlots.mostrarColetadoNoDisplay(evento, arcoIrisEfeito, posExecucao);        
        displayDeScores.mostrarScore(evento.score, evento.resultCombinacao);        
        ((AcaoColetado.ConsumidorEvento)botoesPowerUp).consumirEvento(evento);
    }   

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        if (evento.isInicio)
        {
            displaysDeSlots.processarPowerUp(evento);            
            arcoIrisEfeito.ligarEfeitoArcoIris();
            displayTimer.pause();
            displayDeScores.iniciarContagemRegressiva(evento.duracaoTempo);
        }
        else if (evento.isPreFinalizar)
        {
            displayDeScores.piscarAsteriscos();
        }
        else if (evento.isFinalizar)
        {
            displayDeScores.finalizarContagemRegressiva();
            displayTimer.continuar();
            botoesPowerUp.processarFimPowerUp();
            displaysDeSlots.processarFimPowerUp(botoesPowerUp);            
            arcoIrisEfeito.desligarEfeito();
        }
    }              

    void AcaoBoardElevadoFim.ConsumidorEvento.consumirEvento(SubidaBoardAcaoFim evento)
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

    void AcaoBBarItemEscolhido<PowerUpBtnInfo>.ConsumidorEvento.consumirEvento(PowerUpBtnInfo evento)
    {
        ((AcaoBBarItemEscolhido<PowerUpBtnInfo>.ConsumidorEvento)botoesPowerUp).consumirEvento(evento);
    }

    void AcaoDesligarMaquinaResultado.ConsumidorEvento.consumirEvento(ResultadoDesligarMaquinaDto evento)
    {
        ((AcaoDesligarMaquinaResultado.ConsumidorEvento)botaoLigaDesliga).consumirEvento(evento);
        ((AcaoDesligarMaquinaResultado.ConsumidorEvento)botoesPowerUp).consumirEvento(evento);
    }

    ProdutorDeEvento<TempoEsgotado> AcaoTempoEsgotado.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoTempoEsgotado.ProdutorEvento)displayTimer).getProdutorDeEvento();
    }

    ProdutorDeEvento<ColetadoFim> AcaoColetadoFim.ProdutorEvento.getProdutorDeEvento()
    {        
        return ((AcaoColetadoFim.ProdutorEvento)displaysDeSlots).getProdutorDeEvento();
    }

    ProdutorDeEvento<int> AcaoBotaoPowerUpVazio.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoBotaoPowerUpVazio.ProdutorEvento)botoesPowerUp).getProdutorDeEvento();
    }

    ProdutorDeEvento<CacaNiquelEventoDto> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoCacaNiquel.ProdutorEvento)displaysDeSlots).getProdutorDeEvento();
    }

    ProdutorDeEvento<DesligarMaquinaDto> AcaoDesligarMaquina.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoDesligarMaquina.ProdutorEvento)botaoLigaDesliga).getProdutorDeEvento();
    }  
}
