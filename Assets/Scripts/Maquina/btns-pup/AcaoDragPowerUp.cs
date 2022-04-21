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

    //public AcaoDragPowerUp(BotaoPowerUpDto botaoDto, BotaoPowerUpDtoV2 botaoDtoV2)
    //{
    //    rotacaoOriginal = botaoDto.GoBtnPowerUp.transform.localRotation;
    //    posicaoOriginal = botaoDto.GoParteDentro.transform.position;
    //    areaBotao = botaoDto.SprAreaExterna.bounds;                
    //}

    public AcaoDragPowerUp(BotaoPowerUpDtoV2 botaoDtoV2)
    {
        rotacaoOriginal = botaoDtoV2.TransformBtnTampa.localRotation;
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
        //aparencia.prepararRotacaoImgDrag();
    }

    //public void updateDrag(Vector2 posicaoDrag, AparenciaBotaoPowerUp aparencia, BotaoPowerUpDto btnDto)
    //{
    //    Vector2 delta = posicaoDrag - posicaoInicialDrag;
    //    posicaoInicialDrag = posicaoDrag;

    //    PosicaoBotaoPowerUp posicao = new PosicaoBotaoPowerUp(btnDto);
    //    Vector3 posicaoCalculada = posicao.adicionarNaPosicao(delta);
    //    if(areaDraggavel.Contains(posicaoCalculada))
    //    {
    //        aparencia.mostrarSoImagem();
    //    }
    //    else if(posicaoCalculada.y > areaDraggavel.max.y)
    //    {
    //        aparencia.mostrarErro();
    //    }
    //    else
    //    {
    //        aparencia.mostrarBotao();
    //    }
    //}

    public void updateDrag(Vector2 posicaoDrag, AparenciaBotaoPowerUp aparencia, BotaoPowerUpDtoV2 btnDto)
    {
        Vector2 delta = posicaoDrag - posicaoInicialDrag;
        posicaoInicialDrag = posicaoDrag;

        PosicaoBotaoPowerUp posicao = new PosicaoBotaoPowerUp(btnDto);
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

    //public bool dragFinalizado(int indice, AcaoBotaoPowerUp acaoPowerUp, AparenciaBotaoPowerUp aparencia, BotaoPowerUpDto btnDto)
    //{
    //    PosicaoBotaoPowerUp posicao = new PosicaoBotaoPowerUp(btnDto);
    //    if (aparencia.isMostrandoImagem())
    //    {
    //        acaoPowerUp.acionar(indice, posicao.getPosicao());
    //        aparencia.mostrarBotao();
    //        posicao.colocarNaPosicaoOriginalAcionado(posicaoOriginal, rotacaoOriginal);
    //        aparencia.limparImg();
    //        goAreaDraggavel.SetActive(false);
    //        return true;
    //    }
    //    else
    //    {
    //        Utils.MonoBehaviour.StartCoroutine(voltarBotaoDragPosOriginal(posicao, aparencia));
    //        goAreaDraggavel.SetActive(false);
    //        return false;
    //    }
    //}

    public bool dragFinalizado(int indice, AcaoBotaoPowerUp acaoPowerUp, AparenciaBotaoPowerUp aparencia, BotaoPowerUpDtoV2 btnDto)
    {
        PosicaoBotaoPowerUp posicao = new PosicaoBotaoPowerUp(btnDto);
        if (aparencia.isMostrandoImagem())
        {
            acaoPowerUp.acionar(indice, posicao.getPosicao());
            aparencia.mostrarBotao();
            posicao.colocarNaPosicaoOriginalAcionado(posicaoOriginal, rotacaoOriginal);
            aparencia.limparImg();
            goAreaDraggavel.SetActive(false);
            return true;
        }
        else
        {
            Utils.MonoBehaviour.StartCoroutine(voltarBotaoDragPosOriginal(posicao, aparencia));
            goAreaDraggavel.SetActive(false);
            return false;
        }
    }

    private IEnumerator voltarBotaoDragPosOriginal(PosicaoBotaoPowerUp posicao, AparenciaBotaoPowerUp aparencia)
    {
        while ((Vector3.Distance(posicao.getPosicao(), posicaoOriginal))
               > (VELOCIDADE_VOLTA * Time.deltaTime))
        {
            posicao.moveTowards(posicaoOriginal, VELOCIDADE_VOLTA * Time.deltaTime);
            yield return null;
        }
        goAreaDraggavel.SetActive(false);
        posicao.colocarNaPosicaoOriginal(posicaoOriginal, rotacaoOriginal);        
        aparencia.mostrarBotao();
    }

    public static void configurarAreaDraggavel(GameObject areaDraggavelArg)
    {
        goAreaDraggavel = areaDraggavelArg;
        areaDraggavel = goAreaDraggavel.GetComponent<SpriteRenderer>().bounds;
    }
}
