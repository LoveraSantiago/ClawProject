using UnityEngine;

public class BotoesPowerUp 
{
    private bool acionadoPowerUp;

    private BotaoPowerUp[] btnsPowerUp;    
    private BotaoPowerUp btnAcionado;

    private Draggavel dragavelAtual;
    private Draggavel dragavelVazio;

    private InputGame inputGame;        

    public BotoesPowerUp(BotoesPowerUpDto btnsPowerUps, InputGame inputGame)
    {
        this.inputGame = inputGame;       

        BotaoPowerUp.configurarSpriteBordas(btnsPowerUps.BordasBtns);
        inicializarBotoes(btnsPowerUps);

        dragavelVazio = new AdapterDraggavelVazio();
        dragavelAtual = dragavelVazio;
    }

    private void inicializarBotoes(BotoesPowerUpDto btnsPowerUps)
    {
        btnsPowerUp = new BotaoPowerUp[4];
        btnsPowerUp[0] = new BotaoPowerUp(btnsPowerUps.BtnsPowerUp[0]);
        btnsPowerUp[1] = new BotaoPowerUp(btnsPowerUps.BtnsPowerUp[1]);
        btnsPowerUp[2] = new BotaoPowerUp(btnsPowerUps.BtnsPowerUp[2]);
        btnsPowerUp[3] = new BotaoPowerUp(btnsPowerUps.BtnsPowerUp[3]);
    }

    public void configuraradoPeloLevel(PowerUp.TIPO[] arrayDePowerUpsParaBotoes)
    {

    }
    
    public void update()
    {
        if (!acionadoPowerUp && inputGame.aconteceuTapNaAreaInferior())
        {
            Vector2 posicaoTap = inputGame.getPosicaoTap();
            if (btnsPowerUp[0].isCliqueDentroAreaBotao(posicaoTap))
            {
                acionarBotao(btnsPowerUp[0]);                
            }
            else if (btnsPowerUp[1].isCliqueDentroAreaBotao(posicaoTap))
            {
                acionarBotao(btnsPowerUp[1]);
            }
            else if (btnsPowerUp[2].isCliqueDentroAreaBotao(posicaoTap))
            {
                acionarBotao(btnsPowerUp[2]);
            }
            else if (btnsPowerUp[3].isCliqueDentroAreaBotao(posicaoTap))
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
            if (btnsPowerUp[0].isDragDentroAreaBotao(posicaoDrag))
            {   
                dragavelAtual = btnsPowerUp[0];
            }
            else if (btnsPowerUp[1].isDragDentroAreaBotao(posicaoDrag))
            {            
                dragavelAtual = btnsPowerUp[1];
            }
            else if (btnsPowerUp[2].isDragDentroAreaBotao(posicaoDrag))
            {            
                dragavelAtual = btnsPowerUp[2];
            }
            else if (btnsPowerUp[3].isDragDentroAreaBotao(posicaoDrag))
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
