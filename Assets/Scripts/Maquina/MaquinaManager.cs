using UnityEngine;

public class MaquinaManager : AcaoDesligarMaquina.ProdutorEvento,
                              AcaoColetado.ConsumidorEvento,                                
                              AcaoSincroniaComDirecaoDaGarra.ConsumidorEvento,
                              AcaoPowerUpAcionado.ConsumidorEvento,                                                            
                              AcaoBoardElevadoFim.ConsumidorEvento,                              
                              AcaoBotaoPowerUpVazio.ConsumidorEvento,
                              AcaoItemEscolhido<PowerUpBtnInfo>.ConsumidorEvento
{
    private bool isGamePlay;
    private PartesMaquinaDtoV2 partesDto;

    private Joystick            joystick;       
    public  DisplayTimer        displayTimer { get; private set; }
    public  BotoesPowerUp       botoesPowerUp { get; private set; }
    public  BotaoLigaDesliga    botaoLigaDesliga { get; private set; }
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
        scrollPupsManager  = new ScrollPupsManager(maquinaDto.ScrollPupsDto);
        draggavel          = botoesPowerUp;
        isGamePlay = true;
    }

    public void configuradoPeloLevel(AbstractLevel levelEscolhido, MaquinaDto maquinaDto)
    {
        botoesPowerUp.configuradoPeloLevel(levelEscolhido);
        joystick.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());        
        displayDeColetados.configuradoPeloLevel(levelEscolhido, maquinaDto.DisplayColetadosDto);
        displayDeScores.configuradoPeloLevel(maquinaDto.DisplayDeScoreDto, levelEscolhido);
        scrollPupsManager.configuradoPeloLevel(maquinaDto.ScrollPupsDto, maquinaDto.Material7SegsDto, levelEscolhido);
        displayTimer.configuradoPeloLevel(maquinaDto.DisplayTimerDto, maquinaDto.Material7SegsDto, levelEscolhido);

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
        if (isGamePlay)
        {
            botoesPowerUp.update(maquinaDto.BotoesPowerUpDto, inputGame);
            botaoLigaDesliga.update(inputGame);
            displayTimer.update();
        }
        else
        {
            scrollPupsManager.update(inputGame);
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

    void AcaoBotaoPowerUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {
        scrollPupsManager.setIndiceBotaoVazioAtual(evento);
        draggavel = scrollPupsManager;
        isGamePlay = false;
    }

    void AcaoItemEscolhido<PowerUpBtnInfo>.ConsumidorEvento.consumirEvento(PowerUpBtnInfo evento)
    {   
        isGamePlay = true;
    }

    void AcaoSincroniaComDirecaoDaGarra.ConsumidorEvento.consumirEvento(DirecaoDaGarra evento)
    {
        ((AcaoSincroniaComDirecaoDaGarra.ConsumidorEvento)joystick).consumirEvento(evento);
    }    

    ProdutorDeEvento<DesligarMaquinaDto> AcaoDesligarMaquina.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoDesligarMaquina.ProdutorEvento)botaoLigaDesliga).getProdutorDeEvento();
    }  
}
