using UnityEngine;
using System.Collections;

public class AsaPowerUpGo : AbstractPowerUpGo
{
    private readonly int VOADA;

    private bool hitColetavel;
    private CircleCollider2D circleCollider;
    private Animator animator;

    public AsaPowerUpGo() 
        : base(powerUpDto.AsaPup, new GetGoComSpriteRenderer(), "Asas")
    {
        VOADA = Animator.StringToHash("voada");
    }

    public override void configurarPup()
    {
        animator = goColetavel.transform.Find("asas").GetComponent<Animator>();
        circleCollider = goColetavel.GetComponent<CircleCollider2D>();
    }

    public override PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra()
    {
        return PowerUpEntidade.INTERACAOGARRA.NAO_INTERACAO;
    }

    public override void iniciarPup()
    {
        ligarMirasNosColetaveis();
        monoBehaviour.StartCoroutine(selecionarAlvo());
    }

    public override void resetPup()
    {
        
    }

    private IEnumerator selecionarAlvo()
    {
        hitColetavel = false;
        ColetavelQuery coletavelQuery = new ColetavelQuery();
        while (!hitColetavel)
        {
            if (inputGame.aconteceuTapNaAreaSuperior())
            {
                Collider2D coletavelHit = getColetavelHit();
                if (coletavelHit != null)
                {
                    string nomeAlvo = coletavelHit.name;
                    Debug.Log("Acertou " + nomeAlvo);
                    desligarMirasNosColetaveis();
                    ColetavelTile coletavelParaVoar = coletavelQuery.getColetavelInGameByName(nomeAlvo);

                    colocarNaPosicao(coletavelParaVoar.getPosicao());
                    receberSprite(coletavelParaVoar.getSprite(), 32);

                    coletavelParaVoar.desligar();
                    ligar();
                    monoBehaviour.StartCoroutine(voar(coletavelParaVoar));
                }
            }
            yield return null;
        }

        yield return null;
    }

    private IEnumerator voar(ColetavelTile coletavelAcertado)
    {
        setGravidade(-0.075f);
        circleCollider.isTrigger = true;
        animator.Play(VOADA);

        Vector3 posicaoInicial = getPosicao();
        float posXmax = posicaoInicial.x + 0.3f;
        float posXmin = posicaoInicial.x - 0.3f;

        while (getPosicao().y < 3)
        {
            Vector3 posicaoAtual = getPosicao();
            float xZigZag = Mathf.Lerp(posXmin, posXmax, Mathf.PingPong(Time.time, 1f));
            Vector3 posicaoZigZag = new Vector3(xZigZag, posicaoAtual.y, posicaoAtual.z);
            colocarNaPosicao(posicaoZigZag);
            yield return null;
        }
        powerUpFinalizacao.preFinalizar(coletavelAcertado);
        desligar();

        yield return new WaitForSeconds(0.5f);

        powerUpFinalizacao.finalizado();
        yield return null;
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
