using UnityEngine;

public class MaquinaManager : AcaoDesligarMaquina.ProdutorEvento,                                                            
                              AcaoSincroniaComDirecaoDaGarra.ConsumidorEvento,
                              AcaoPowerUpAcionado.ConsumidorEvento,                                                            
                              AcaoBoardElevadoFim.ConsumidorEvento,                              
                              AcaoBotaoPowerUpVazio.ConsumidorEvento,
                              AcaoPupFromScrollSelecao.ConsumidorEvento
{
    private bool isGamePlay;
    private PartesMaquinaDtoV2 partesDto;

    private Joystick            joystick;       
    public  DisplayTimer        displayTimer       { get; private set; }
    public  BotoesPowerUp       botoesPowerUp      { get; private set; }
    public  BotaoLigaDesliga    botaoLigaDesliga   { get; private set; }
    public  ArcoIrisEfeito      arcoIrisEfeito     { get; private set; }
    public  DisplayDeScores     displayDeScores    { get; private set; }
    public  DisplaysDeColetados displayDeColetados { get; private set; }
    public  ScrollPupsManager   scrollPupsManager  { get; private set; }
    private Draggavel           draggavel;
    private SomMaquina          somMaquina;

    public MaquinaManager(MaquinaDto maquinaDto, SomMaquina somMaquina)
    {
        partesDto          = maquinaDto.PartesDtoV2;
        this.somMaquina    = somMaquina;
        arcoIrisEfeito     = new ArcoIrisEfeito(maquinaDto.MaquinaEfeitoGlowDto);
        displayDeColetados = new DisplaysDeColetados(maquinaDto.DisplayColetadosDto, arcoIrisEfeito, somMaquina);        
        displayDeScores    = new DisplayDeScores(maquinaDto.DisplayDeScoreDto, somMaquina);
        displayTimer       = new DisplayTimer(maquinaDto.DisplayTimerDto, somMaquina);
        joystick           = new Joystick(maquinaDto.MesaJoystickDto);
        botoesPowerUp      = new BotoesPowerUp(maquinaDto.BotoesPowerUpDto);
        botaoLigaDesliga   = new BotaoLigaDesliga(maquinaDto.BotaoLigaDesligaDto);
        scrollPupsManager  = new ScrollPupsManager(maquinaDto.ScrollPupsDto);
        draggavel          = botoesPowerUp;
        isGamePlay = true;
    }

    public void configuradoPeloLevel(MaquinaDto maquinaDto)
    {
        botoesPowerUp.configuradoPeloLevel();
        joystick.configuradoPeloLevel();        
        displayDeColetados.configuradoPeloLevel(maquinaDto.DisplayColetadosDto);
        displayDeScores.configuradoPeloLevel(maquinaDto.DisplayDeScoreDto);
        scrollPupsManager.configuradoPeloLevel(maquinaDto.ScrollPupsDto, maquinaDto.Material7SegsDto);
        displayTimer.configuradoPeloLevel(maquinaDto.DisplayTimerDto, maquinaDto.Material7SegsDto);

        new ColoridorMaquinaV2().colorir(partesDto);        
    }

    public void start(InputGame inputGame)
    {
        displayTimer.iniciarContagemTempo();
        displayDeColetados.iniciar(inputGame);
        scrollPupsManager.iniciar();
    }

    public void update(MaquinaDto maquinaDto, InputGame inputGame)
    {
        if (isGamePlay)
        {
            botoesPowerUp.update(maquinaDto.BotoesPowerUpDto, somMaquina, inputGame);
            botaoLigaDesliga.update(inputGame, somMaquina);
            displayTimer.update();
        }
        else
        {
            scrollPupsManager.update(inputGame, somMaquina);
        }
    }

    public void fixedUpdate()
    {
        joystick.fixedUpdate();
    }   

    public void onBeginDrag(Vector2 posicao)
    {
        if (draggavel.isDragAcionavel(posicao))
        {
            //Debug.Log("MaquinaManager begin drag");
            draggavel.onBeginDrag(posicao);
        }
    }

    public void onDragPowerUp(Vector2 delta, MaquinaDto maquinaDto)
    {
        if (draggavel.foiDragAcionado())
        {
            //Debug.Log("MaquinaManager on drag");
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

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        if (evento.isEstadoInicio)
        {
            displayDeColetados.processarPowerUp(evento);            
            arcoIrisEfeito.ligarEfeitoArcoIris();
            displayTimer.pause();
            displayDeScores.iniciarContagemRegressiva(evento.duracaoTempoPupEntidade);
        }
        else if (evento.isEstadoPreFinalizar)
        {
            displayDeScores.piscarAsteriscos();
        }
        else if (evento.isEstadoFinalizar)
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
            displayTimer.resetCoroutine();
        }
    }

    void AcaoBotaoPowerUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {
        scrollPupsManager.setIndiceBotaoVazioAtual(evento);
        draggavel = scrollPupsManager;
        isGamePlay = false;
    }

    void AcaoPupFromScrollSelecao.ConsumidorEvento.consumirEvento(PowerUpBtnInfo evento)
    {   
        isGamePlay = true;
        draggavel = botoesPowerUp;
    }

    void AcaoSincroniaComDirecaoDaGarra.ConsumidorEvento.consumirEvento(Direcao evento)
    {
        ((AcaoSincroniaComDirecaoDaGarra.ConsumidorEvento)joystick).consumirEvento(evento);
    }    

    ProdutorDeEvento<DesligarMaquinaDto> AcaoDesligarMaquina.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoDesligarMaquina.ProdutorEvento)botaoLigaDesliga).getProdutorDeEvento();
    }  
}
