using UnityEngine;

public class MaquinaManager : AcaoTempoEsgotado.ProdutorEvento,
                              AcaoColetadoFim.ProdutorEvento,
                              AcaoBotaoPUpVazio.ProdutorEvento,
                              AcaoCacaNiquel.ProdutorEvento,
                              AcaoDesligarMaquina.ProdutorEvento,
                              AcaoColetado.ConsumidorEvento,                                
                              AcaoSincroniaComDirecaoDaGarra.ConsumidorEvento,
                              AcaoPUpAcionado.ConsumidorEvento,                                                            
                              AcaoBoardElevadoFim.ConsumidorEvento,
                              AcaoBBarItemEscolhido<PowerUpBtnInfo>.ConsumidorEvento,
                              AcaoDesligarMaquinaCancelado.ConsumidorEvento
{    
    private PartesMaquinaDto partesDto;

    private Joystick          joystick;    
    private VigaParte         vigaEsquerda;
    private VigaParte         vigaDireita;
    private DisplayTimer      displayTimer;
    private BotoesPowerUp     botoesPowerUp;
    private BotaoLigaDesliga  botaoLigaDesliga;
    private ArcoIrisEfeito    arcoIrisEfeito;
    private DisplayDeScores   displayDeScores;    
    public  DisplaysDeSlots   displaysDeSlots { get; private set; }
    private BordasVidroFrente bordasFrenteVidro;
    private TudoDeSaida       tuboDeSaida;
    private Chao              chao;

    public MaquinaManager(MaquinaDto maquinaDto)
    {
        partesDto = maquinaDto.PartesDto;

        displaysDeSlots   = new DisplaysDeSlots(maquinaDto.DisplaysSlotsDto);        
        displayDeScores   = new DisplayDeScores(maquinaDto.DisplayDeScoreDto);
        displayTimer      = new DisplayTimer(maquinaDto.DisplayTimerDto);
        joystick          = new Joystick(maquinaDto.JoystickDto);
        botoesPowerUp     = new BotoesPowerUp(maquinaDto.BotoesPowerUpDto);
        botaoLigaDesliga  = new BotaoLigaDesliga(maquinaDto.BotaoLigaDesligaDto);        
        vigaEsquerda      = new VigaParte(maquinaDto.VigaLadoEsquerdoDto);
        vigaDireita       = new VigaParte(maquinaDto.VigaLadoDireitoDto);
        bordasFrenteVidro = new BordasVidroFrente(maquinaDto.BordasFrenteDto);
        tuboDeSaida       = new TudoDeSaida(maquinaDto.TuboDto);
        chao              = new Chao(maquinaDto.ChaoDto);

        arcoIrisEfeito = new ArcoIrisEfeito(maquinaDto.FactorHdr)//REFATORAR FORMAS DE MONTAR CONJUNTO REVER INSTANCIAS DE MATERIALGLOW            
            .addArcoIrisConjunto(displaysDeSlots.getDisplayColetadoGlow())
            .addArcoIrisConjunto(displayDeScores)
            .addArcoIrisConjunto(displayTimer.getDisplayTimerGlow(maquinaDto.DisplayTimerDto))            
            .addArcoIrisConjunto(vigaEsquerda)
            .addArcoIrisConjunto(vigaDireita)
            .addArcoIrisConjunto(botoesPowerUp.getBotoesGlow())
            .addArcoIrisConjunto(bordasFrenteVidro)
            .addArcoIrisConjunto(tuboDeSaida)
            .addArcoIrisConjunto(chao);        
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

        AntesExecutorTimerRestart executor = new AntesExecutorTimerRestart(botoesPowerUp, displayTimer, arcoIrisEfeito);
        displayTimer.configuradoPeloLevel(levelEscolhido, executor);

        new ColoridorMaquina()
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

    void AcaoPUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
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

    void AcaoDesligarMaquinaCancelado.ConsumidorEvento.consumirEvento(CancelarDesligarMaquina evento)
    {
        ((AcaoDesligarMaquinaCancelado.ConsumidorEvento)botaoLigaDesliga).consumirEvento(evento);
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

    ProdutorDeEvento<CacaNiquelEventoDto> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoCacaNiquel.ProdutorEvento)displaysDeSlots).getProdutorDeEvento();
    }

    ProdutorDeEvento<DesligarMaquina> AcaoDesligarMaquina.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoDesligarMaquina.ProdutorEvento)botaoLigaDesliga).getProdutorDeEvento();
    }  
}
