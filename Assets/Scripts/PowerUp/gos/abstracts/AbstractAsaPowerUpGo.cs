using UnityEngine;
using System.Collections;

public abstract class AbstractAsaPowerUpGo : PowerUpSemInteracao,
                                             Transformador<Coletavel, IEnumerator>
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
        animator = extrairAnimatorFrom("asas");
        circleCollider = extrairComponente<CircleCollider2D>();
    }

    public override void iniciarPup()
    {
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        helperInGame.ligarMirasNosColetaveis();

        hitColetavel = false;
        HumAlvoSelecionado alvoSelecionado = new HumAlvoSelecionado();
        coroutine = Utils.MonoBehaviour.StartCoroutine(alvoSelecionado.onSelecionado(inputGame, this));
    }

    public override void resetPup() { }

    public IEnumerator transformar(Coletavel coletavel)
    {
        return voar(coletavel);
    }

    private IEnumerator voar(Coletavel coletavelAcertado)
    {
        hitColetavel = true;

        colocarNaPosicao(coletavelAcertado.getPosicao());
        receberSprite(coletavelAcertado.getSprite(), powerUpDto.AsaDto.Layer);
        coletavelAcertado.desligar();        
        ligar();

        setGravidade(getGravidadeNegativa());
        acionarTriggerNoCollider();
        playAnimacaoVoar();

        Vector3 posicaoInicial = getPosicao();
        float offset = getOffset();
        float posXmax = posicaoInicial.x + offset;
        float posXmin = posicaoInicial.x - offset;

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

    protected abstract float getGravidadeNegativa();
    protected abstract float getOffset();
    protected abstract float getHalturaLimite();
    protected abstract IEnumerator finalizarVoar(Coletavel coletavelAcertado);

    public override void timeout()
    {
        if (!hitColetavel)
        {
            Utils.MonoBehaviour.StopCoroutine(coroutine);
            HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
            helperInGame.desligarMirasNosColetaveis();
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
