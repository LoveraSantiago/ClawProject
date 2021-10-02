using UnityEngine;
using System.Collections;

public class AsaPowerUpGo : PowerUpNaoInteracaoComGarra
{
    private readonly int VOADA;

    private bool hitColetavel;

    private ColetaveisMiras miras;
    private Animator animator;
    private CircleCollider2D circleCollider;
    private Coroutine coroutine;

    public AsaPowerUpGo() 
        : base(powerUpDto.AsaDto.AsaGo, new GetGoComSpriteRenderer(), "Asas")
    {
        VOADA = Animator.StringToHash("voada");
        //Debug.Log("Asa Instanciado");
        miras = new ColetaveisMiras();
    }

    public override void configurarPup()
    {
        animator = goColetavel.transform.Find("asas").GetComponent<Animator>();
        circleCollider = goColetavel.GetComponent<CircleCollider2D>();
    }    

    public override void iniciarPup()
    {
        miras.ligar();
        coroutine = Utils.MonoBehaviour.StartCoroutine(selecionarAlvo());
    }

    public override void resetPup(){}

    private IEnumerator selecionarAlvo()
    {
        hitColetavel = false;
        ColetavelQuery coletavelQuery = new ColetavelQuery();        
        while (!hitColetavel)
        {
            if (inputGame.aconteceuTapNaAreaSuperior())
            {
                bool resultAcertado = false;
                Collider2D coletavelAcertado = ColetavelHit.hit(inputGame, out resultAcertado);
                if (resultAcertado)
                {
                    string nomeAlvo = coletavelAcertado.name;
                    //Debug.Log("Acertou " + nomeAlvo);
                    miras.desligar();
                    ColetavelTile coletavelParaVoar = coletavelQuery.getColetavelInGameByName(nomeAlvo);
                                        
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

        while (getPosicao().y < powerUpDto.AsaDto.Haltura)
        {
            Vector3 posicaoAtual = getPosicao();
            float xZigZag = Mathf.Lerp(posXmin, posXmax, Mathf.PingPong(Time.time, 1f));
            Vector3 posicaoZigZag = new Vector3(xZigZag, posicaoAtual.y, posicaoAtual.z);
            colocarNaPosicao(posicaoZigZag);
            yield return null;
        }
        powerUpFinalizacao.preFinalizar(coletavelAcertado);
        desligar();

        yield return new WaitForSeconds(powerUpDto.AsaDto.DelayFinalizar);

        powerUpFinalizacao.finalizado();
        yield return null;
    }

    public override void timeout()
    {
        if (!hitColetavel)
        {
            Utils.MonoBehaviour.StopCoroutine(coroutine);
            miras.desligar();
            powerUpFinalizacao.finalizado();
        }
    }

    public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorAsa();
    }

    public class FornecedorAsa : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new AsaPowerUpGo();
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
