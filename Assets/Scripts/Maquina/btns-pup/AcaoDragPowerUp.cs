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
    private Quaternion rotacaoOriginal;

    public AcaoDragPowerUp(BotaoPowerUpDto botaoDto)
    {
        rotacaoOriginal = botaoDto.GoBtnPowerUp.transform.localRotation;
        posicaoOriginal = botaoDto.GoParteDentro.transform.position;
        areaBotao = botaoDto.SprAreaExterna.bounds;
    }

    public bool isPosicaoDentroAreaBotao(Vector2 posicao)
    {
        return areaBotao.Contains(posicao);
    }

    public void prepararDraggagem(Vector3 posInicialDrag, AparenciaBotaoPowerUp aparencia)
    {
        posicaoInicialDrag = posInicialDrag;
        goAreaDraggavel.SetActive(true);
        aparencia.prepararRotacaoImgDrag();
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

    public bool dragFinalizado(int indice, AcaoBotaoPowerUp acaoPowerUp, AparenciaBotaoPowerUp aparencia)
    {
        if (aparencia.isMostrandoImagem())
        {
            acaoPowerUp.acionar(indice, aparencia.getPosicao());
            aparencia.mostrarBotao();                        
            aparencia.colocarNaPosicaoOriginalAcionado(posicaoOriginal, rotacaoOriginal);
            goAreaDraggavel.SetActive(false);
            return true;
        }
        else
        {
            Utils.MonoBehaviour.StartCoroutine(voltarBotaoDragPosOriginal(aparencia));
            goAreaDraggavel.SetActive(false);
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
        aparencia.colocarNaPosicaoOriginal(posicaoOriginal, rotacaoOriginal);
        aparencia.mostrarBotao();
    }

    public static void configurarAreaDraggavel(GameObject areaDraggavelArg)
    {
        goAreaDraggavel = areaDraggavelArg;
        areaDraggavel = goAreaDraggavel.GetComponent<SpriteRenderer>().bounds;
    }
}
