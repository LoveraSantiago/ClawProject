using UnityEngine;
using System.Collections;

public class BotaoPowerUp : Draggavel
{
    private static readonly int VELOCIDADE_VOLTA = 15;

    private bool isDraggavel;    

    private Vector2 posicaoInicialDrag;
    private Vector3 posicaoOriginal;
    private Bounds boundExterno;

    private AparenciaBotaoPowerUp aparencia;
    private GameObject goBotaoInterno;   

    public BotaoPowerUp(GameObject goBotao)
    {        
        goBotaoInterno = goBotao.transform.Find("parte-dentro").gameObject;
        posicaoOriginal = goBotaoInterno.transform.position;
        boundExterno = goBotao.GetComponent<SpriteRenderer>().bounds;

        aparencia = new AparenciaBotaoPowerUp(goBotaoInterno);
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

    private bool isPosicaoDentroAreaBotao(Vector2 posicao)
    {
        return boundExterno.Contains(posicao);        
    }

    public bool isCliqueDentroAreaBotao(Vector2 posicao)
    {
        return !isDraggavel && isPosicaoDentroAreaBotao(posicao);
    }

    public bool isDragDentroAreaBotao(Vector2 posicao)
    {
        return isDraggavel && isPosicaoDentroAreaBotao(posicao);
    }        

    public void receberImg(Sprite img)
    {
        aparencia.receberImg(img);
    }

    //IMPLEMENTANDO INTERFACE DRAGGAVEL INICIO
    public void prepararDraggagem(Vector3 posInicialDrag)
    {
        this.posicaoInicialDrag = posInicialDrag;
    }

    public void updateDrag(Vector2 posicaoAtual)
    {
        Vector2 delta = posicaoAtual - posicaoInicialDrag;
        posicaoInicialDrag = posicaoAtual;

        Vector3 posicaoCalculada = new Vector3(
            goBotaoInterno.transform.position.x + delta.x,
            goBotaoInterno.transform.position.y + delta.y, 
            goBotaoInterno.transform.position.z);

        goBotaoInterno.transform.position = posicaoCalculada;
    }

    public void dragFinalizado(MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StartCoroutine(voltarBotaoDragPosOriginal());
    }
    //IMPLEMENTANDO INTERFACE DRAGGAVEL FIM    

    private IEnumerator voltarBotaoDragPosOriginal()
    {
        while ((Vector3.Distance(goBotaoInterno.transform.position, posicaoOriginal))
               > (VELOCIDADE_VOLTA * Time.deltaTime))
        {
            goBotaoInterno.transform.position = Vector3.MoveTowards(goBotaoInterno.transform.position, posicaoOriginal, VELOCIDADE_VOLTA * Time.deltaTime);
            yield return null;
        }
        goBotaoInterno.transform.position = posicaoOriginal;
    }

    public static void configurarSpriteBordas(Sprite[] spritesBordas)
    {
        AparenciaBotaoPowerUp.configurarSpriteBordas(spritesBordas);
        //spriteBordaNormal = spritesBordas[0];
        //spriteBordaSerrilhada = spritesBordas[1];
    }
}
