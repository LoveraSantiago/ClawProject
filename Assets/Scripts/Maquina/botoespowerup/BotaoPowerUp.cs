using UnityEngine;

public class BotaoPowerUp : Draggavel
{
    private bool isDraggavel;
    public bool hasPowerUp { get; private set; }

    private AparenciaBotaoPowerUp aparencia;
    private AcaoDragPowerUp acaoDrag;
    private AcaoBotaoPowerUp acaoBtnPowerUp;

    public BotaoPowerUp(BotaoPowerUpDto botaoDto)
    {
        aparencia = new AparenciaBotaoPowerUp(botaoDto);
        acaoDrag  = new AcaoDragPowerUp(botaoDto);

        isDraggavel = false;
    }

    public void clicar()
    {
        aparencia.colorirBotao();
        if (hasPowerUp)
        {
            acaoBtnPowerUp.acionar();            
            hasPowerUp = false;
        }
    }

    public void draggar()
    {
        aparencia.colorirBotao();
        if (hasPowerUp)
        {            
            hasPowerUp = false;
        }
    }

    public void desclicar()
    {
        aparencia.voltarCorOriginalBotao();
        aparencia.limparImg();
    }

    public void receberCorLevel(string corBotao, string corDentro, string corContorno)
    {
        aparencia.colorirBotaoFromLevel(corBotao, corDentro, corContorno);
    }

    public void receberAcaoPowerUp(AcaoBotaoPowerUp acaoBtnPowerUp)
    {
        this.acaoBtnPowerUp = acaoBtnPowerUp;
        if (acaoBtnPowerUp.isClicavel())
        {
            transformarEmBotaoClicavel();
        }
        else
        {
            transformarEmBotaoDragavel();
        }
        aparencia.receberImg(acaoBtnPowerUp.getImgBotao());
        hasPowerUp = true;
    }

    private void transformarEmBotaoDragavel()
    {
        aparencia.mostrarBordaSerrilhada();
        isDraggavel = true;
    }

    private void transformarEmBotaoClicavel()
    {
        aparencia.mostrarBordaNormal();
        isDraggavel = false;
    }       

    public bool isCliqueValido(ControleAcionamentoPowerUp controleAcionamento, Vector2 posicao)
    {
        return !isDraggavel
               && hasPowerUp
               && controleAcionamento.podeAcionarPupBtn(acaoBtnPowerUp)
               && acaoDrag.isPosicaoDentroAreaBotao(posicao);
    }

    public bool isDragValido(Vector2 posicao)
    {
        return isDraggavel && hasPowerUp && acaoDrag.isPosicaoDentroAreaBotao(posicao);
    }           

    //IMPLEMENTANDO INTERFACE DRAGGAVEL INICIO
    public void prepararDraggagem(Vector3 posInicialDrag)
    {        
        acaoDrag.prepararDraggagem(posInicialDrag);
    }

    public void updateDrag(Vector2 posicaoDrag)
    {
        acaoDrag.updateDrag(posicaoDrag, aparencia);
    }

    public bool isDragFinalizadoAtivouPowerUp(MonoBehaviour monoBehaviour)
    {
        return acaoDrag.dragFinalizado(acaoBtnPowerUp, aparencia, monoBehaviour);        
    }
    //IMPLEMENTANDO INTERFACE DRAGGAVEL FIM

    public static void configurar(Sprite[] spritesBordas, GameObject areaDraggavel)
    {
        AparenciaBotaoPowerUp.configurarSpriteBordas(spritesBordas);
        AcaoDragPowerUp.configurarAreaDraggavel(areaDraggavel);
    }
}
