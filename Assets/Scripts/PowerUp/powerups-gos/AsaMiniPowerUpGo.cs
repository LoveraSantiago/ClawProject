using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsaMiniPowerUpGo : PowerUpNaoInteracaoComGarra
{
    private readonly int VOADA;

    private bool hitColetavel;

    private Animator animator;
    private CircleCollider2D circleCollider;
    private Coroutine coroutine;

    public AsaMiniPowerUpGo() 
        : base(powerUpDto.AsaDto.AsaMiniGo, new GetGoComSpriteRenderer(), "Asas")
    {
        VOADA = Animator.StringToHash("voada");
    }

    public override void configurarPup()
    {
        animator = goColetavel.transform.Find("asas").GetComponent<Animator>();
        circleCollider = goColetavel.GetComponent<CircleCollider2D>();
    }

    public override void iniciarPup()
    {
        ColetavelHelper coletavelHelper = new ColetavelHelper();
        coletavelHelper.ligarMirasNosColetaveis();
        coroutine = Utils.MonoBehaviour.StartCoroutine(selecionarAlvo());
    }

    public override void resetPup(){}

    private IEnumerator selecionarAlvo()
    {
        hitColetavel = false;
        while (!hitColetavel)
        {
            if (inputGame.aconteceuTapNaAreaSuperior())
            {
                bool resultAcertado = false;
                ColetavelTile coletavelParaVoar = ColetavelHit.hit(inputGame, out resultAcertado);
                if (resultAcertado)
                {
                    string nomeAlvo = coletavelParaVoar.nome;
                    //Debug.Log("Acertou " + nomeAlvo);
                    ColetavelHelper coletavelHelper = new ColetavelHelper();
                    coletavelHelper.desligarMirasNosColetaveis();

                    colocarNaPosicao(coletavelParaVoar.getPosicao());
                    receberSprite(coletavelParaVoar.getSprite(), powerUpDto.AsaDto.Layer);

                    coletavelParaVoar.desligar();
                    ligar();
                    Utils.MonoBehaviour.StartCoroutine(voar(coletavelParaVoar));
                    hitColetavel = true;
                }
            }
            yield return null;
        }
        yield return null;
    }

    private IEnumerator voar(ColetavelTile coletavelAcertado)    
    {
        setGravidade(powerUpDto.AsaDto.GravidadeNeg);
        circleCollider.isTrigger = true;
        animator.Play(VOADA);

        Vector3 posicaoInicial = getPosicao();
        float posXmax = posicaoInicial.x + powerUpDto.AsaDto.Offset;
        float posXmin = posicaoInicial.x - powerUpDto.AsaDto.Offset;

        ColetavelHelper coletaveisHelper = new ColetavelHelper();
        ColetavelTile coletavelMaisAlto = coletaveisHelper.getColetavelMaisAlto();
        while (getPosicao().y < coletavelMaisAlto.getPosicao().y + 1f)
        {
            Vector3 posicaoAtual = getPosicao();
            float xZigZag = Mathf.Lerp(posXmin, posXmax, Mathf.PingPong(Time.time, 1f));
            Vector3 posicaoZigZag = new Vector3(xZigZag, posicaoAtual.y, posicaoAtual.z);
            colocarNaPosicao(posicaoZigZag);
            yield return null;
        }

        coletavelAcertado.colocarNaPosicao(getPosicao());
        coletavelAcertado.ligar();
        desligar();

        powerUpFinalizacao.preFinalizar();

        yield return new WaitForSeconds(powerUpDto.AsaDto.DelayFinalizar);

        powerUpFinalizacao.finalizado();
        yield return null;
    }

    public override void timeout()
    {
        if (!hitColetavel)
        {
            Utils.MonoBehaviour.StopCoroutine(coroutine);
            ColetavelHelper coletavelHelper = new ColetavelHelper();
            coletavelHelper.desligarMirasNosColetaveis();
            powerUpFinalizacao.finalizado();
        }
    }

    public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorAsaMini();
    }

    public class FornecedorAsaMini : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new AsaMiniPowerUpGo();
        }
    }

    private class GetGoComSpriteRenderer : Transformador<GameObject, GameObject>
    {
        public GameObject transformar(GameObject goColetavel)
        {
            return goColetavel.transform.Find("imagem").gameObject;
        }
    }
}
