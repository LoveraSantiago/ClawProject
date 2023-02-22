using UnityEngine;
using System.Collections;

public abstract class AbstractAsaPowerUpGo : PowerUpSemInteracao,
                                             Transformador<Coletavel, IEnumerator>
{
    private static readonly int VOADA = Animator.StringToHash("abrindo-asas");

    private bool hitColetavel;
    private Animator animator;
    private CircleCollider2D circleCollider;
    private Coroutine coroutine;

    public AbstractAsaPowerUpGo(GameObject goDto, string nome)
         : base(goDto, new FinderDeSprRenderer1Nivel("imagem"), nome){}

    public override void configurarPup()
    {
        animator = extrairComponente<Animator>();
        circleCollider = extrairComponente<CircleCollider2D>();
    }

    public override void iniciarPup()
    {
        HelperColetaveisInGame.ligarMirasNosColetaveis(true);

        hitColetavel = false;
        HumAlvoColetavelSelecionado alvoSelecionado = new HumAlvoColetavelSelecionado(true);
        coroutine = ContextoEstaticoUtils.monoBehaviour.StartCoroutine(alvoSelecionado.onSelecionar(inputGame, this));
    }

    public override void resetPup() 
    {
        setGravidade(0f);
    }

    public IEnumerator transformar(Coletavel coletavel)
    {
        return voar(coletavel);
    }

    private IEnumerator voar(Coletavel coletavelAcertado)
    {
        hitColetavel = true;

        PowerUpRotacionadorDeColetavel rotacionador = new PowerUpRotacionadorDeColetavel(powerUpDto.VelocidadeRotacao, coletavelAcertado);
        yield return rotacionador.rotacionar();

        colocarNaPosicao(coletavelAcertado.getPosicao());
        Sprite spriteAcertado = getSpriteAcertado(coletavelAcertado);        
        receberSprite(spriteAcertado);
        coletavelAcertado.desligarComEstado();        
        ligarComEstado();

        somPowerUp.playSomAnjo();
        playAnimacaoVoar();
        yield return new WaitForSeconds(powerUpDto.AsaDto.DelayAsaAbrir);

        setGravidade(getGravidadeNegativa());
        somPowerUp.iniciarSomAsa();
        acionarTriggerNoCollider();

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
        somPowerUp.pararSomAsa();
        yield return null;
        ContextoEstaticoUtils.monoBehaviour.StartCoroutine(finalizarVoar(coletavelAcertado));
    }

    protected abstract float getGravidadeNegativa();
    protected abstract float getOffset();
    protected abstract float getHalturaLimite();
    protected abstract IEnumerator finalizarVoar(Coletavel coletavelAcertado);

    public override void timeout()
    {
        if (!hitColetavel)
        {
            ContextoEstaticoUtils.monoBehaviour.StopCoroutine(coroutine);

            HelperColetaveisInGame.desligarMirasNosColetaveis();
            powerUpFinalizacao.finalizado();
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

    private Sprite getSpriteAcertado(Coletavel coletavelAcertado)
    {
        if (coletavelAcertado.isOvo())
        {
            return powerUpDto.SpriteOvo;
        }
        else
        {
            return coletavelAcertado.getSprite();
        }
    }
}
