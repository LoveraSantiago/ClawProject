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
    
    private MonoBehaviour monoBehaviour;

    public BotoesPowerUp(PowerUpDto powerUpDto, InputGame inputGame, MonoBehaviour monoBehaviour)
    {
        this.inputGame = inputGame;
        this.monoBehaviour = monoBehaviour;        

        BotaoPowerUp.configurarSpriteBordas(powerUpDto.BordasBtns);
        btnPUp1 = new BotaoPowerUp(powerUpDto.BtnsPowerUp[0]);
        btnPUp2 = new BotaoPowerUp(powerUpDto.BtnsPowerUp[1]);
        btnPUp3 = new BotaoPowerUp(powerUpDto.BtnsPowerUp[2]);
        btnPUp4 = new BotaoPowerUp(powerUpDto.BtnsPowerUp[3]);

        dragavelVazio = new AdapterDraggavelVazio();
        dragavelAtual = dragavelVazio;
        
        btnPUp2.transformarEmBotaoDragavel();
        btnPUp3.transformarEmBotaoClicavel();
        btnPUp4.transformarEmBotaoDragavel();
    }
    
    public void update()
    {
        if (inputGame.aconteceuTapNaAreaInferior())
        {
            Vector2 posicaoTap = inputGame.getPosicaoTap();
            if (btnPUp1.isCliqueDentroAreaBotao(posicaoTap))
            {   
                btnPUp1.clicar(monoBehaviour);
                acaoBotaoPup1.acionar();                
            }
            else if (btnPUp2.isCliqueDentroAreaBotao(posicaoTap))
            {   
                btnPUp2.clicar(monoBehaviour);                
            }
            else if (btnPUp3.isCliqueDentroAreaBotao(posicaoTap))
            {   
                btnPUp3.clicar(monoBehaviour);                
            }
            else if (btnPUp4.isCliqueDentroAreaBotao(posicaoTap))
            {             
                btnPUp4.clicar(monoBehaviour);                
            }
        }        
    }

    private AcaoBotaoPowerUp acaoBotaoPup1;//TEMPORARIAMENTE AQUI
    public void recebendoPowerUp(AcaoBotaoPowerUp acaoBotaoPup)
    {
        acaoBotaoPup1 = acaoBotaoPup;
        if (acaoBotaoPup.isClicavel())
        {
            btnPUp1.transformarEmBotaoClicavel();
        }
        else
        {
            btnPUp1.transformarEmBotaoDragavel();
        }
    }

    public void beginDrag(Vector2 posicaoDrag)
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

    public void drag(Vector2 delta)
    {        
        dragavelAtual.updateDrag(delta);        
    }

    public void endDrag()
    {
        dragavelAtual.dragFinalizado(monoBehaviour);
        dragavelAtual = dragavelVazio;
    }    
}
