using System.Collections;
using UnityEngine;

public class AcaoDragPowerUp 
{
    private static readonly int VELOCIDADE_VOLTA = 15;
    private static GameObject goAreaDraggavel;
    private static Bounds areaDraggavel;

    private Vector2 posicaoInicialDrag;
    private Vector3 posicaoOriginal;

    private Bounds areaBotao;   

    public AcaoDragPowerUp(GameObject goBotao, GameObject goBotaoInterno)
    {
        posicaoOriginal = goBotaoInterno.transform.position;
        areaBotao = goBotao.GetComponent<SpriteRenderer>().bounds;
    }

    public bool isPosicaoDentroAreaBotao(Vector2 posicao)
    {
        return areaBotao.Contains(posicao);
    }

    public void prepararDraggagem(Vector3 posInicialDrag)
    {
        this.posicaoInicialDrag = posInicialDrag;
        goAreaDraggavel.SetActive(true);
    }

    public void updateDrag(Vector2 posicaoDrag, AparenciaBotaoPowerUp aparencia)
    {
        Vector2 delta = posicaoDrag - posicaoInicialDrag;
        posicaoInicialDrag = posicaoDrag;

        Vector3 posicaoCalculada = aparencia.adicionarNaPosicao(delta);
        if(areaDraggavel.Contains(posicaoCalculada))
        {
            aparencia.mostrarSoImagem();
        }
        else if(posicaoCalculada.y > areaDraggavel.max.y)
        {
            aparencia.mostrarErro();
        }
        else
        {
            aparencia.mostrarBotao();
        }
    }

    public bool dragFinalizado(AcaoBotaoPowerUp acaoPowerUp, AparenciaBotaoPowerUp aparencia, MonoBehaviour monoBehaviour)
    {
        if (aparencia.isMostrandoImagem())
        {
            acaoPowerUp.acionar(aparencia.getPosicao());
            return true;
        }
        else
        {
            monoBehaviour.StartCoroutine(voltarBotaoDragPosOriginal(aparencia));
            return false;
        }

    }

    private IEnumerator voltarBotaoDragPosOriginal(AparenciaBotaoPowerUp aparencia)
    {
        while ((Vector3.Distance(aparencia.getPosicao(), posicaoOriginal))
               > (VELOCIDADE_VOLTA * Time.deltaTime))
        {            
            aparencia.moveTowards(posicaoOriginal, VELOCIDADE_VOLTA * Time.deltaTime);
            yield return null;
        }
        goAreaDraggavel.SetActive(false);
        aparencia.colocarNaPosicao(posicaoOriginal);
        aparencia.mostrarBotao();
    }

    public static void configurarAreaDraggavel(GameObject areaDraggavelArg)
    {
        goAreaDraggavel = areaDraggavelArg;
        areaDraggavel = goAreaDraggavel.GetComponent<SpriteRenderer>().bounds;
    }
}
