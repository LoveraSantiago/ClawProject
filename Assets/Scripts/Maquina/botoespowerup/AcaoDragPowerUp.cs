using System.Collections;
using UnityEngine;

public class AcaoDragPowerUp 
{
    private static readonly int VELOCIDADE_VOLTA = 15;
    private static GameObject goAreaDraggavel;

    private Vector2 posicaoInicialDrag;
    private Vector3 posicaoOriginal;
    private Bounds boundExterno;   

    public AcaoDragPowerUp(GameObject goBotao, GameObject goBotaoInterno)
    {
        posicaoOriginal = goBotaoInterno.transform.position;
        boundExterno = goBotao.GetComponent<SpriteRenderer>().bounds;
    }

    public bool isPosicaoDentroAreaBotao(Vector2 posicao)
    {
        return boundExterno.Contains(posicao);
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
    }

    public void dragFinalizado(AparenciaBotaoPowerUp aparencia, MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StartCoroutine(voltarBotaoDragPosOriginal(aparencia));
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
    }

    public static void configurarAreaDraggavel(GameObject areaDraggavelArg)
    {
        goAreaDraggavel = areaDraggavelArg;
    }
}
