using UnityEngine;

public class BotoesPowerUp 
{
    //private bool acionadoPowerUp;

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
                 if (btnsPowerUp[0].isCliqueValido(controlePup, posicaoTap))
            {
                acionarBotao(btnsPowerUp[0]);                
            }
            else if (btnsPowerUp[1].isCliqueValido(controlePup, posicaoTap))
            {
                acionarBotao(btnsPowerUp[1]);
            }
            else if (btnsPowerUp[2].isCliqueValido(controlePup, posicaoTap))
            {
                acionarBotao(btnsPowerUp[2]);
            }
            else if (btnsPowerUp[3].isCliqueValido(controlePup, posicaoTap))
            {
                acionarBotao(btnsPowerUp[3]);
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
            if (btnsPowerUp[0].isDragValido(posicaoDrag))
            {   
                dragavelAtual = btnsPowerUp[0];
                btnAcionado = btnsPowerUp[0];
            }
            else if (btnsPowerUp[1].isDragValido(posicaoDrag))
            {            
                dragavelAtual = btnsPowerUp[1];
                btnAcionado = btnsPowerUp[1];
            }
            else if (btnsPowerUp[2].isDragValido(posicaoDrag))
            {            
                dragavelAtual = btnsPowerUp[2];
                btnAcionado = btnsPowerUp[2];
            }
            else if (btnsPowerUp[3].isDragValido(posicaoDrag))
            {            
                dragavelAtual = btnsPowerUp[3];
                btnAcionado = btnsPowerUp[3];
            }
            else
            {
                dragavelAtual = dragavelVazio;
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
