using UnityEngine;

public class BotaoPowerUp : Draggavel
{
    private bool isDraggavel;
    public bool hasPowerUp { get; private set; }

    private AparenciaBotaoPowerUp aparencia;
    private AcaoDragPowerUp acaoDrag;
    private AcaoBotaoPowerUp acaoBtnPowerUp;

    public BotaoPowerUp(GameObject goBotao)
    {        
        GameObject goBotaoInterno = goBotao.transform.Find("parte-dentro").gameObject;
        aparencia = new AparenciaBotaoPowerUp(goBotaoInterno);
        acaoDrag  = new AcaoDragPowerUp(goBotao, goBotaoInterno);

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

    public void desclicar()
    {
        aparencia.voltarCorOriginalBotao();
        aparencia.limparImg();
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

    public bool isCliqueValido(Vector2 posicao)
    {
        return !isDraggavel && acaoDrag.isPosicaoDentroAreaBotao(posicao) && hasPowerUp;
    }

    public bool isDragValido(Vector2 posicao)
    {
        return isDraggavel && acaoDrag.isPosicaoDentroAreaBotao(posicao) && hasPowerUp;
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

    public void dragFinalizado(MonoBehaviour monoBehaviour)
    {
        acaoDrag.dragFinalizado(aparencia, monoBehaviour);
    }
    //IMPLEMENTANDO INTERFACE DRAGGAVEL FIM

    public static void configurar(Sprite[] spritesBordas, GameObject areaDraggavel)
    {
        AparenciaBotaoPowerUp.configurarSpriteBordas(spritesBordas);
        AcaoDragPowerUp.configurarAreaDraggavel(areaDraggavel);

    }
}
