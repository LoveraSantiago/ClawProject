using System.Collections;
using UnityEngine;

public class AcaoDragPowerUp 
{
    private static readonly int VELOCIDADE_VOLTA = 15;

    private static Bounds areaDraggavel;
    private static GameObject goAreaDraggavel;

    private Bounds  areaBotao;   
    private Vector2 posicaoInicialDrag;
    private Vector3 posicaoOriginal;

    public AcaoDragPowerUp(BotaoPowerUpDtoV2 botaoDtoV2)
    {
        posicaoOriginal = botaoDtoV2.TransformBtnTampa.position;
        areaBotao = botaoDtoV2.SprRendererBtnBase.bounds;        
    }

    public bool isPosicaoDentroAreaBotao(Vector2 posicao)
    {
        return areaBotao.Contains(posicao);
    }

    public void prepararDraggagem(Vector3 posInicialDrag, AparenciaBotaoPowerUp aparencia)
    {
        posicaoInicialDrag = posInicialDrag;
        goAreaDraggavel.SetActive(true);
    }

    public void updateDrag(Vector2 posicaoDrag, AparenciaBotaoPowerUp aparencia, BotaoPowerUpDtoV2 btnDto)
    {
        Vector2 delta = posicaoDrag - posicaoInicialDrag;
        posicaoInicialDrag = posicaoDrag;

        PosicaoTransform posicao = new PosicaoTransform(btnDto.TransformBtnTampa);
        Vector3 posicaoCalculada = posicao.adicionarNaPosicao(delta);
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

    public bool dragFinalizado(int indice, AcaoBotaoPowerUp acaoPowerUp, AparenciaBotaoPowerUp aparencia, BotaoPowerUpDtoV2 btnDto)
    {
        PosicaoTransform posicao = new PosicaoTransform(btnDto.TransformBtnTampa);
        if (aparencia.isMostrandoImagem())
        {
            acaoPowerUp.acionar(indice, posicao.getPosicao());
            aparencia.mostrarBotao();
            posicao.colocarNaPosicaoOriginal(posicaoOriginal);
            aparencia.limparImg();
            goAreaDraggavel.SetActive(false);
            return true;
        }
        else
        {
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(voltarBotaoDragPosOriginal(posicao, aparencia));
            goAreaDraggavel.SetActive(false);
            return false;
        }
    }

    private IEnumerator voltarBotaoDragPosOriginal(PosicaoTransform posicao, AparenciaBotaoPowerUp aparencia)
    {
        while ((Vector3.Distance(posicao.getPosicao(), posicaoOriginal))
               > (VELOCIDADE_VOLTA * Time.deltaTime))
        {
            posicao.moveTowards(posicaoOriginal, VELOCIDADE_VOLTA * Time.deltaTime);
            yield return null;
        }
        goAreaDraggavel.SetActive(false);
        posicao.colocarNaPosicaoOriginal(posicaoOriginal);        
        aparencia.mostrarBotao();
    }

    public static void configurarAreaDraggavel(GameObject areaDraggavelArg)
    {
        goAreaDraggavel = areaDraggavelArg;
        areaDraggavel = goAreaDraggavel.GetComponent<SpriteRenderer>().bounds;
    }
}
