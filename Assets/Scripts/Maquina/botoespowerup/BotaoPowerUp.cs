using UnityEngine;

public class BotaoPowerUp : Draggavel
{
    private bool isDraggavel;    

    private AparenciaBotaoPowerUp aparencia;
    private AcaoDragPowerUp acaoDrag;

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
    }

    public void desclicar()
    {
        aparencia.voltarCorOriginalBotao();
    }

    public void transformarEmBotaoDragavel()
    {
        aparencia.mostrarBordaSerrilhada();
        isDraggavel = true;
    }

    public void transformarEmBotaoClicavel()
    {
        aparencia.mostrarBordaNormal();
        isDraggavel = false;
    }   

    public bool isCliqueDentroAreaBotao(Vector2 posicao)
    {
        return !isDraggavel && acaoDrag.isPosicaoDentroAreaBotao(posicao);
    }

    public bool isDragDentroAreaBotao(Vector2 posicao)
    {
        return isDraggavel && acaoDrag.isPosicaoDentroAreaBotao(posicao);
    }        

    public void receberImg(Sprite img)
    {
        aparencia.receberImg(img);
    }

    //IMPLEMENTANDO INTERFACE DRAGGAVEL INICIO
    public void prepararDraggagem(Vector3 posInicialDrag)
    {
        acaoDrag.prepararDraggagem(posInicialDrag);
    }

    public void updateDrag(Vector2 posicaoAtual)
    {
        acaoDrag.updateDrag(posicaoAtual);
    }

    public void dragFinalizado(MonoBehaviour monoBehaviour)
    {
        acaoDrag.dragFinalizado(monoBehaviour);
    }
    //IMPLEMENTANDO INTERFACE DRAGGAVEL FIM

    public static void configurarSpriteBordas(Sprite[] spritesBordas)
    {
        AparenciaBotaoPowerUp.configurarSpriteBordas(spritesBordas);
    }
}
