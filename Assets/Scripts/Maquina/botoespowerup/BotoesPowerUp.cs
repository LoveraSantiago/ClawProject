using UnityEngine;

public class BotoesPowerUp 
{
    private bool acionadoPowerUp;
    private BotaoPowerUp btnPUp1;
    private BotaoPowerUp btnPUp2;
    private BotaoPowerUp btnPUp3;
    private BotaoPowerUp btnPUp4;
    private BotaoPowerUp btnAcionado;

    private Draggavel dragavelAtual;
    private Draggavel dragavelVazio;

    private InputGame inputGame;    
    

    public BotoesPowerUp(BotoesPowerUpDto btnsPowerUps, PowerUp.TIPO[] arrayDePowerUpsParaBotoes, InputGame inputGame)
    {
        this.inputGame = inputGame;       

        BotaoPowerUp.configurarSpriteBordas(btnsPowerUps.BordasBtns);
        inicializarBotoes(btnsPowerUps);

        dragavelVazio = new AdapterDraggavelVazio();
        dragavelAtual = dragavelVazio;
        
        btnPUp2.transformarEmBotaoDragavel();
        btnPUp3.transformarEmBotaoClicavel();
        btnPUp4.transformarEmBotaoDragavel();
    }

    private void inicializarBotoes(BotoesPowerUpDto btnsPowerUps)
    {
        btnPUp1 = new BotaoPowerUp(btnsPowerUps.BtnsPowerUp[0]);
        btnPUp2 = new BotaoPowerUp(btnsPowerUps.BtnsPowerUp[1]);
        btnPUp3 = new BotaoPowerUp(btnsPowerUps.BtnsPowerUp[2]);
        btnPUp4 = new BotaoPowerUp(btnsPowerUps.BtnsPowerUp[3]);
    }
    
    public void update()
    {
        if (!acionadoPowerUp && inputGame.aconteceuTapNaAreaInferior())
        {
            Vector2 posicaoTap = inputGame.getPosicaoTap();
            if (btnPUp1.isCliqueDentroAreaBotao(posicaoTap))
            {
                acionarBotao(btnPUp1);
                acaoBotaoPup1.acionar();                
            }
            else if (btnPUp2.isCliqueDentroAreaBotao(posicaoTap))
            {
                acionarBotao(btnPUp2);
            }
            else if (btnPUp3.isCliqueDentroAreaBotao(posicaoTap))
            {
                acionarBotao(btnPUp3);
            }
            else if (btnPUp4.isCliqueDentroAreaBotao(posicaoTap))
            {
                acionarBotao(btnPUp4);
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

    private AcaoBotaoPowerUp acaoBotaoPup1;//TEMPORARIAMENTE AQUI
    public void recebendoPowerUp(AcaoBotaoPowerUp acaoBotaoPup)
    {
        acaoBotaoPup1 = acaoBotaoPup;
        if (acaoBotaoPup.isClicavel())
        {
            btnPUp1.transformarEmBotaoClicavel();
            btnPUp1.receberImg(acaoBotaoPup.getImgBotao());
        }
        else
        {
            btnPUp1.transformarEmBotaoDragavel();
        }
    }

    public void beginDrag(Vector2 posicaoDrag)
    {
        if (!acionadoPowerUp)
        {
            if (btnPUp1.isDragDentroAreaBotao(posicaoDrag))
            {   
                dragavelAtual = btnPUp1;
            }
            else if (btnPUp2.isDragDentroAreaBotao(posicaoDrag))
            {            
                dragavelAtual = btnPUp2;
            }
            else if (btnPUp3.isDragDentroAreaBotao(posicaoDrag))
            {            
                dragavelAtual = btnPUp3;
            }
            else if (btnPUp4.isDragDentroAreaBotao(posicaoDrag))
            {            
                dragavelAtual = btnPUp4;
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
