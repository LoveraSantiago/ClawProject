using System;
using UnityEngine;

public class BotoesPowerUp 
{
    private BotaoPowerUp btnPUp1;
    private BotaoPowerUp btnPUp2;
    private BotaoPowerUp btnPUp3;
    private BotaoPowerUp btnPUp4;

    private Draggavel dragavelAtual;
    private Draggavel dragavelVazio;

    private InputGame inputGame;

    public BotoesPowerUp(PowerUpDto powerUpDto, InputGame inputGame)
    {
        this.inputGame = inputGame;

        btnPUp1 = new BotaoPowerUp(powerUpDto.BtnsPowerUp[0]);
        btnPUp2 = new BotaoPowerUp(powerUpDto.BtnsPowerUp[1]);
        btnPUp3 = new BotaoPowerUp(powerUpDto.BtnsPowerUp[2]);
        btnPUp4 = new BotaoPowerUp(powerUpDto.BtnsPowerUp[3]);

        dragavelVazio = new AdapterDraggavelVazio();
        dragavelAtual = dragavelVazio;

        btnPUp1.transormarEmBotalClicavel();
        btnPUp2.transformarEmBotaoDragavel();
        btnPUp3.transormarEmBotalClicavel();
        btnPUp4.transformarEmBotaoDragavel();
    }

    public void update()
    {
        if (inputGame.aconteceuTapNaAreaInferior())
        {
            Vector2 posicaoTap = inputGame.getPosicaoTap();
            if (btnPUp1.isCliqueDentroAreaBotao(posicaoTap))
            {
                Debug.Log("BTN1 CRICADO!!!");
            }
            else if (btnPUp2.isCliqueDentroAreaBotao(posicaoTap))
            {
                Debug.Log("BTN2 CRICADO!!!");
            }
            else if (btnPUp3.isCliqueDentroAreaBotao(posicaoTap))
            {
                Debug.Log("BTN3 CRICADO!!!");
            }
            else if (btnPUp4.isCliqueDentroAreaBotao(posicaoTap))
            {
                Debug.Log("BTN4 CRICADO!!!");
            }
        }
        dragavelAtual.updateDrag();
    }

    public void beginDrag(Vector3 posicaoDrag)
    {
        if (btnPUp1.isDragDentroAreaBotao(posicaoDrag))
        {
            Debug.Log("DRAG1 CRICADO!!!");
        }
        else if (btnPUp2.isDragDentroAreaBotao(posicaoDrag))
        {
            Debug.Log("DRAG2 CRICADO!!!");
        }
        else if (btnPUp3.isDragDentroAreaBotao(posicaoDrag))
        {
            Debug.Log("DRAG3 CRICADO!!!");
        }
        else if (btnPUp4.isDragDentroAreaBotao(posicaoDrag))
        {
            Debug.Log("DRAG4 CRICADO!!!");
        }
        else
        {
            dragavelAtual = dragavelVazio;
        }
    }

    public void drag()
    {
        if(dragavelAtual != dragavelVazio)
        {

        }
    }

    public void endDrag()
    {
        dragavelAtual = dragavelVazio;
    }
}
