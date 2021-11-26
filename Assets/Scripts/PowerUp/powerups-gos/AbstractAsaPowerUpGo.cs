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
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        helperInGame.ligarMirasNosColetaveis();
        coroutine = Utils.MonoBehaviour.StartCoroutine(selecionarAlvo());
    }

    public override void resetPup() { }

    private IEnumerator selecionarAlvo()
    {
        hitColetavel = false;
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        helperInGame.ligarMirasNosColetaveis();

        SelecionadorDeAlvos selecionadorDeAlvos = new SelecionadorDeAlvos();        
        yield return selecionadorDeAlvos.selecionarAlvo(inputGame);
        ColetavelTile coletavelSelecionado = selecionadorDeAlvos.coletavelSelecionado;

        helperInGame.ligarMiraAlvoFinalNoColetavel(coletavelSelecionado.nome);
        Utils.MonoBehaviour.StartCoroutine(voar(coletavelSelecionado));
    }

    private IEnumerator voar(ColetavelTile coletavelAcertado)
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
    protected abstract IEnumerator finalizarVoar(ColetavelTile coletavelAcertado);

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
