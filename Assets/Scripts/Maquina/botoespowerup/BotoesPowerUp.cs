using UnityEngine;

public class BotoesPowerUp 
{
    private BotaoPowerUp[] btnsPowerUp;    
    private BotaoPowerUp btnAcionado;

    private DistribuidorParaBotoesPowerUp distribuidor;
    private ControleAcionamentoPowerUp controlePup;

    private Draggavel dragavelAtual;
    private Draggavel dragavelVazio;

    private InputGame inputGame;        

    public BotoesPowerUp(BotoesPowerUpDto btnsPowerUpsDto, InputGame inputGame)
    {
        this.inputGame = inputGame;       

        BotaoPowerUp.configurar(btnsPowerUpsDto.BordasBtns, btnsPowerUpsDto.AreaDraggavel);

        inicializarBotoes(btnsPowerUpsDto);
        distribuidor = new DistribuidorParaBotoesPowerUp(btnsPowerUpsDto.SpritesDeBotoes);
        controlePup = new ControleAcionamentoPowerUp();

        dragavelVazio = new AdapterDraggavelVazio();
        dragavelAtual = dragavelVazio;
    }

    private void inicializarBotoes(BotoesPowerUpDto btnsPowerUpsDto)
    {
        btnsPowerUp = new BotaoPowerUp[4];
        btnsPowerUp[0] = new BotaoPowerUp(btnsPowerUpsDto.BtnPowerUp[0]);
        btnsPowerUp[1] = new BotaoPowerUp(btnsPowerUpsDto.BtnPowerUp[1]);
        btnsPowerUp[2] = new BotaoPowerUp(btnsPowerUpsDto.BtnPowerUp[2]);
        btnsPowerUp[3] = new BotaoPowerUp(btnsPowerUpsDto.BtnPowerUp[3]);
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        distribuidor.distribuirArray(level.getPowerUpsParaBotoesMaquina(), btnsPowerUp);
        new ColoridorBotoes().colorir(btnsPowerUp, level.getDicionarioDeCores());        
    }
    
    public void update()
    {
        if (inputGame.aconteceuTapNaAreaInferior())
        {
            Vector2 posicaoTap = inputGame.getPosicaoTap();
            for (int contador = 0; contador < btnsPowerUp.Length; contador++)
            {
                if (btnsPowerUp[contador].isCliqueValido(controlePup, posicaoTap))
                {
                    acionarBotao(btnsPowerUp[contador]);
                    break;
                }
            }
        }           
    }

    public void desativarPowerUp()
    {
        controlePup.desabilitarPowerUp();        
    }

    public void suspenderPowerUp()
    {
        controlePup.suspenderPowerUp();
    }

    public void reativarPowerUp()
    {
        controlePup.habilitarPowerUp();
    }

    private void acionarBotao(BotaoPowerUp btn)
    {
        btn.clicar();
        controlePup.powerUpAcionado();
        btnAcionado = btn;
    }

    public void reclicarProximoPowerUp()
    {
        controlePup.powerUpFinalizado();
        btnAcionado.desclicar();
        distribuidor.distribuirProxItem(btnsPowerUp);
    }   

    private void draggarBotao(BotaoPowerUp btn)
    {
        controlePup.powerUpAcionado();        
        btn.draggar();
        btnAcionado = btn;
    }

    public void beginDrag(Vector2 posicaoDrag)
    {
        //Debug.Log("begindrag");
        if (controlePup.podeAcionarPupDraggavel())
        {
            dragavelAtual = dragavelVazio;
            for(int contador = 0; contador< btnsPowerUp.Length; contador++)
            {
                if (btnsPowerUp[contador].isDragValido(posicaoDrag))
                {
                    dragavelAtual = btnsPowerUp[contador];
                    btnAcionado = btnsPowerUp[contador];
                    break;
                }
            }            
            dragavelAtual.prepararDraggagem(posicaoDrag);
        }
    }

    public void drag(Vector2 delta)
    {
        if (controlePup.podeAcionarPupDraggavel())
        {
            dragavelAtual.updateDrag(delta);
        }
    }

    public void endDrag(MonoBehaviour monoBehaviour)
    {
        if (controlePup.podeAcionarPupDraggavel())
        {
            bool result = dragavelAtual.isDragFinalizadoAtivouPowerUp(monoBehaviour);            
            if (result)
            {
                draggarBotao(btnAcionado);
            }
            dragavelAtual = dragavelVazio;
        }
    }   
}
