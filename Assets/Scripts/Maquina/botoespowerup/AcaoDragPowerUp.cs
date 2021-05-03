using System.Collections;
using UnityEngine;

public class AcaoDragPowerUp 
{
    private static readonly int VELOCIDADE_VOLTA = 15;

    private Vector2 posicaoInicialDrag;
    private Vector3 posicaoOriginal;
    private Bounds boundExterno;

    private GameObject goBotaoInterno;

    public AcaoDragPowerUp(GameObject goBotao, GameObject goBotaoInterno)
    {
        this.goBotaoInterno = goBotaoInterno;

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
}
