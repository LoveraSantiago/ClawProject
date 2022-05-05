using UnityEngine;

public class MaquinaManager : AcaoTempoEsgotado.ProdutorEvento,
                              AcaoColetadoFim.ProdutorEvento,                              
                              AcaoCacaNiquel.ProdutorEvento,
                              AcaoDesligarMaquina.ProdutorEvento,
                              AcaoColetado.ConsumidorEvento,                                
                              AcaoSincroniaComDirecaoDaGarra.ConsumidorEvento,
                              AcaoPowerUpAcionado.ConsumidorEvento,                                                            
                              AcaoBoardElevadoFim.ConsumidorEvento,
                              AcaoDesligarMaquinaResultado.ConsumidorEvento
{    
    private PartesMaquinaDtoV2 partesDto;

    private Joystick            joystick;       
    public  DisplayTimer        displayTimer { get; private set; }
    public  BotoesPowerUp       botoesPowerUp { get; private set; }
    private BotaoLigaDesliga    botaoLigaDesliga;
    public  ArcoIrisEfeito      arcoIrisEfeito { get; private set; }
    public  DisplayDeScores     displayDeScores { get; private set; }
    public  DisplaysDeColetados displayDeColetados { get; private set; }
    public  ScrollPupsManager   scrollPupsManager { get; private set; }
    private Draggavel           draggavel;

    public MaquinaManager(MaquinaDto maquinaDto)
    {
        partesDto = maquinaDto.PartesDtoV2;

        displayDeColetados = new DisplaysDeColetados(maquinaDto.DisplayColetadosDto);        
        displayDeScores    = new DisplayDeScores(maquinaDto.DisplayDeScoreDto);
        displayTimer       = new DisplayTimer(maquinaDto.DisplayTimerDto);
        joystick           = new Joystick(maquinaDto.MesaJoystickDto);
        botoesPowerUp      = new BotoesPowerUp(maquinaDto.BotoesPowerUpDto);
        botaoLigaDesliga   = new BotaoLigaDesliga(maquinaDto.BotaoLigaDesligaDto);
        arcoIrisEfeito     = new ArcoIrisEfeito(maquinaDto.MaquinaEfeitoGlowDto);
        scrollPupsManager  = new ScrollPupsManager();
        draggavel          = botoesPowerUp;
    }

    public void configuradoPeloLevel(AbstractLevel levelEscolhido, MaquinaDto maquinaDto)
    {
        botoesPowerUp.configuradoPeloLevel(levelEscolhido);
        joystick.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());        
        displayDeColetados.configuradoPeloLevel(levelEscolhido, maquinaDto.DisplayColetadosDto);
        displayDeScores.configuradoPeloLevel(maquinaDto.DisplayDeScoreDto, levelEscolhido);
        scrollPupsManager.configuradoPeloLevel(maquinaDto.ScrollPupsDto, levelEscolhido);
        displayTimer.configuradoPeloLevel(maquinaDto.DisplayTimerDto, levelEscolhido);

        new ColoridorMaquinaV2()
            .colorir(partesDto, levelEscolhido.getDicionarioDeCores());        
    }

    public void start(InputGame inputGame)
    {
        displayTimer.iniciarContagemTempo();
        displayDeColetados.iniciar(inputGame);
        scrollPupsManager.iniciar();
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

    public void onBeginDrag(Vector2 posicao)
    {
        if (draggavel.isDragAcionavel(posicao))
        {
            draggavel.onBeginDrag(posicao);
        }
    }

    public void onDragPowerUp(Vector2 delta, MaquinaDto maquinaDto)
    {
        if (draggavel.foiDragAcionado())
        {
            draggavel.onDrag(delta, maquinaDto);
        }
    }

    public void onEndDragPowerUp(MaquinaDto maquinaDto)
    {
        if (draggavel.foiDragAcionado())
        {
            draggavel.onEndDrag(maquinaDto);
        }
    }

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        displayDeColetados.mostrarColetadoNoDisplay(evento, arcoIrisEfeito);        
        displayDeScores.mostrarScore(evento.score, evento.resultCombinacao);        
        ((AcaoColetado.ConsumidorEvento)botoesPowerUp).consumirEvento(evento);
    }   

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        if (evento.isInicio)
        {
            displayDeColetados.processarPowerUp(evento);            
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
            displayDeColetados.processarFimPowerUp(botoesPowerUp);            
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

    void AcaoDesligarMaquinaResultado.ConsumidorEvento.consumirEvento(ResultadoDesligarMaquinaDto evento)
    {
        ((AcaoDesligarMaquinaResultado.ConsumidorEvento)botaoLigaDesliga).consumirEvento(evento);
        ((AcaoDesligarMaquinaResultado.ConsumidorEvento)botoesPowerUp).consumirEvento(evento);
    }

    ProdutorDeEvento<TempoEsgotadoDto> AcaoTempoEsgotado.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoTempoEsgotado.ProdutorEvento)displayTimer).getProdutorDeEvento();
    }

    ProdutorDeEvento<ColetadoFimDto> AcaoColetadoFim.ProdutorEvento.getProdutorDeEvento()
    {        
        return ((AcaoColetadoFim.ProdutorEvento)displayDeColetados).getProdutorDeEvento();
    }

    ProdutorDeEvento<CacaNiquelEventoDto> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoCacaNiquel.ProdutorEvento)displayDeColetados).getProdutorDeEvento();
    }

    ProdutorDeEvento<DesligarMaquinaDto> AcaoDesligarMaquina.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoDesligarMaquina.ProdutorEvento)botaoLigaDesliga).getProdutorDeEvento();
    }  
}
