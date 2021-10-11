using UnityEngine;
using System.Collections;

public abstract class AbstractAsaPowerUpGo : PowerUpNaoInteracaoComGarra
{
    private static readonly int VOADA = Animator.StringToHash("voada");

    private bool hitColetavel;
    private Animator animator;
    private CircleCollider2D circleCollider;
    private Coroutine coroutine;

    public AbstractAsaPowerUpGo(GameObject goDto, string nome)
         : base(goDto, new GetGoComSpriteRenderer(), nome){}

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

    public override void resetPup() { }

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
        acionarTriggerNoCollider();
        playAnimacaoVoar();

        Vector3 posicaoInicial = getPosicao();
        float posXmax = posicaoInicial.x + powerUpDto.AsaDto.Offset;
        float posXmin = posicaoInicial.x - powerUpDto.AsaDto.Offset;

        while (getPosicao().y < getHalturaLimite())
        {
            Vector3 posicaoAtual = getPosicao();
            float xZigZag = Mathf.Lerp(posXmin, posXmax, Mathf.PingPong(Time.time, 1f));
            Vector3 posicaoZigZag = new Vector3(xZigZag, posicaoAtual.y, posicaoAtual.z);
            colocarNaPosicao(posicaoZigZag);
            yield return null;
        }
        yield return null;
        Utils.MonoBehaviour.StartCoroutine(finalizarVoar(coletavelAcertado));
    }

    protected abstract float getHalturaLimite();
    protected abstract IEnumerator finalizarVoar(ColetavelTile coletavelAcertado);

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

    private class GetGoComSpriteRenderer : Transformador<GameObject, GameObject>
    {
        public GameObject transformar(GameObject goColetavel)
        {
            return goColetavel.transform.Find("imagem").gameObject;
        }
    }

    protected void playAnimacaoVoar()
    {
        animator.Play(VOADA);
    }

    protected void acionarTriggerNoCollider()
    {
        circleCollider.isTrigger = true;
    }
}
