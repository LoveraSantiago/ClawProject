using UnityEngine;

public class BotoesPowerUp 
{
    private bool acionadoPowerUp;

    private BotaoPowerUp[] btnsPowerUp;    
    private BotaoPowerUp btnAcionado;
    private DistribuidorParaBotoesPowerUp distribuidor;

    private Draggavel dragavelAtual;
    private Draggavel dragavelVazio;

    private InputGame inputGame;        

    public BotoesPowerUp(BotoesPowerUpDto btnsPowerUpsDto, InputGame inputGame)
    {
        this.inputGame = inputGame;       

        BotaoPowerUp.configurarSpriteBordas(btnsPowerUpsDto.BordasBtns);

        inicializarBotoes(btnsPowerUpsDto);
        distribuidor = new DistribuidorParaBotoesPowerUp(btnsPowerUp, btnsPowerUpsDto.SpritesDeBotoes);

        dragavelVazio = new AdapterDraggavelVazio();
        dragavelAtual = dragavelVazio;
    }

    private void inicializarBotoes(BotoesPowerUpDto btnsPowerUpsDto)
    {
        btnsPowerUp = new BotaoPowerUp[4];
        btnsPowerUp[0] = new BotaoPowerUp(btnsPowerUpsDto.BtnsPowerUp[0]);
        btnsPowerUp[1] = new BotaoPowerUp(btnsPowerUpsDto.BtnsPowerUp[1]);
        btnsPowerUp[2] = new BotaoPowerUp(btnsPowerUpsDto.BtnsPowerUp[2]);
        btnsPowerUp[3] = new BotaoPowerUp(btnsPowerUpsDto.BtnsPowerUp[3]);
    }

    public void configuraradoPeloLevel(PowerUp.TIPO[] arrayDePowerUpsParaBotoes)
    {
        distribuidor.distribuirArray(arrayDePowerUpsParaBotoes);
    }
    
    public void update()
    {
        if (!acionadoPowerUp && inputGame.aconteceuTapNaAreaInferior())
        {
            Vector2 posicaoTap = inputGame.getPosicaoTap();
            if (btnsPowerUp[0].isCliqueValido(posicaoTap))
            {
                acionarBotao(btnsPowerUp[0]);                
            }
            else if (btnsPowerUp[1].isCliqueValido(posicaoTap))
            {
                acionarBotao(btnsPowerUp[1]);
            }
            else if (btnsPowerUp[2].isCliqueValido(posicaoTap))
            {
                acionarBotao(btnsPowerUp[2]);
            }
            else if (btnsPowerUp[3].isCliqueValido(posicaoTap))
            {
                acionarBotao(btnsPowerUp[3]);
            }
        }        
    }

    private void acionarBotao(BotaoPowerUp btn)
    {
        btn.clicar();
        acionadoPowerUp = true;
        btnAcionado = btn;
    }

    public void desacionarBotao()
    {
        acionadoPowerUp = false;
        btnAcionado.desclicar();
    }   

    public void beginDrag(Vector2 posicaoDrag)
    {
        if (!acionadoPowerUp)
        {
            if (btnsPowerUp[0].isDragValido(posicaoDrag))
            {   
                dragavelAtual = btnsPowerUp[0];
            }
            else if (btnsPowerUp[1].isDragValido(posicaoDrag))
            {            
                dragavelAtual = btnsPowerUp[1];
            }
            else if (btnsPowerUp[2].isDragValido(posicaoDrag))
            {            
                dragavelAtual = btnsPowerUp[2];
            }
            else if (btnsPowerUp[3].isDragValido(posicaoDrag))
            {            
                dragavelAtual = btnsPowerUp[3];
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
        if (!acionadoPowerUp)
        {
            dragavelAtual.updateDrag(delta);
        }
    }

    public void endDrag(MonoBehaviour monoBehaviour)
    {
        if (!acionadoPowerUp)
        {
            dragavelAtual.dragFinalizado(monoBehaviour);
            dragavelAtual = dragavelVazio;
        }
    }   
}
