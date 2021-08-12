using System.Collections;
using UnityEngine;

public class MissilTeleguiadoPowerUpGo : AbstractPowerUpGo,
                                         GarraInteracaoComPowerUp
{
    private readonly int MISSIL_ACIONADO;
    private readonly int MISSIL_EXPLOSAO;
    private readonly int MISSIL_IDLE;
    
    private bool hitColetavel;
    private float distanciaAnterior;
    
    private CapsuleCollider2D capsuleCollider;
    
    private Vector2[] pathMissilRecalculado;
    private PathMissilDto pathMissilDto;
    private Animator animator;

    private Coroutine coroutine;

    public MissilTeleguiadoPowerUpGo() : 
        base(powerUpDto.MissilTeleguiadoPUp, "missil-teleguiado")
    {
        this.pathMissilDto = powerUpDto.PathMissilDto;
        MISSIL_ACIONADO = Animator.StringToHash("missil-acionado");
        MISSIL_EXPLOSAO = Animator.StringToHash("explosao");
        MISSIL_IDLE     = Animator.StringToHash("idle");
    }

    public override GarraInteracaoComPowerUp getObjetoDeInteracaoComGarra()
    {
        return this;
    }

    public override float getAnguloParaGarraSegurar()
    {
        return 16f;
    }

    public override void colocarNaPosicao(Vector3 posicao)
    {
        base.colocarNaPosicao(posicao + new Vector3(0, -0.4f, 0));
    }

    public override void configurarPup()
    {        
        capsuleCollider = goColetavel.GetComponent<CapsuleCollider2D>();
        animator = goColetavel.transform.Find("imagem").GetComponent<Animator>();
    }

    public override void iniciarPup()
    {
        ligar();
        ligarMirasNosColetaveis();
        coroutine = monoBehaviour.StartCoroutine(selecionarAlvo());
    }

    public override void resetPup()
    {
        desligar();
        powerUpFinalizacao.finalizado();
        animator.Play(MISSIL_IDLE);
        colocarNoAngulo(0);
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
                    coletavelQuery.executeNoPoolDeColetaveis(new LigadorDeAlvoFinal(nomeAlvo));
                    hitColetavel = true;
                    monoBehaviour.StartCoroutine(disparandoMissil(coletavelQuery.getColetavelInGameByName(nomeAlvo)));
                }
            }
            yield return null;
        }
        yield return null;
    }

    
    private IEnumerator disparandoMissil(ColetavelTile coletavel)
    {
        animator.Play(MISSIL_ACIONADO);
        recalcularPath(coletavel.getPosicao());
        capsuleCollider.isTrigger = true;
        int contadorIndice = 0;
        float contador = 0;
        Vector2 p1 = pathMissilRecalculado[contadorIndice * 3];
        Vector2 p2 = pathMissilRecalculado[contadorIndice * 3 + 1];
        Vector2 p3 = pathMissilRecalculado[contadorIndice * 3 + 2];
        Vector2 p4 = pathMissilRecalculado[contadorIndice * 3 + 3];

        distanciaAnterior = 100;

        while (true)
        {
            contador += (2.5f * Time.deltaTime);
            Vector2 posicao = Utils.cubicCurve(p1, p2, p3, p4, contador);
            Vector2 posNext = Utils.cubicCurve(p1, p2, p3, p4, contador + 0.01f);
            colocarNaPosicao(posicao);

            Vector2 diferenca = posicao - posNext;
            diferenca.Normalize();
            float z = Mathf.Atan2(diferenca.y, diferenca.x) * Mathf.Rad2Deg;
            Quaternion quat = Quaternion.Euler(0f, 0f, z - 90);
            colocarNoAngulo(quat);

            float distanciaAtual = (p4 - posicao).magnitude;
            //Debug.Log("Dist: " + distanciaAtual + " Ang: " + z);
            
            if (distanciaAtual > distanciaAnterior)
            {
                distanciaAnterior = 100;
                //Debug.Log("********************");
                contador = 0;
                contadorIndice++;
                if ((contadorIndice * 3 + 3) > pathMissilDto.PathPointsMissil.Length)
                {
                    break;
                }
                p1 = pathMissilRecalculado[contadorIndice * 3];
                p2 = pathMissilRecalculado[contadorIndice * 3 + 1];
                p3 = pathMissilRecalculado[contadorIndice * 3 + 2];
                p4 = pathMissilRecalculado[contadorIndice * 3 + 3];
            }
            else
            {
                distanciaAnterior = distanciaAtual;
            }
            yield return null;
        }
        colocarNaPosicao(coletavel.getPosicao());
        parar();
        animator.Play(MISSIL_EXPLOSAO);
        coletavel.disparar(0, 20f);
        coletavel.desligarAnimacao();

        PequenaExplosaoShake explosaoShake = new PequenaExplosaoShake(monoBehaviour);
        explosaoShake.shake();
        powerUpFinalizacao.preFinalizar();

        yield return new WaitForSeconds(1.1f);
        resetPup();
        yield return null;
    }    

    private void recalcularPath(Vector3 posicaoFim)
    {
        if(posicaoFim.x > 0)
        {
            pathMissilDto.GoMainPath.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            pathMissilDto.GoMainPath.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        pathMissilRecalculado = new Vector2[pathMissilDto.PathPointsMissil.Length];
        for(int contador = 0; contador < pathMissilDto.PathPointsMissil.Length; contador++)
        {
            pathMissilRecalculado[contador] = pathMissilDto.PathPointsMissil[contador].position;
        }

        pathMissilRecalculado[pathMissilRecalculado.Length - 1] = posicaoFim;
        pathMissilRecalculado[pathMissilRecalculado.Length - 2] = new Vector2(posicaoFim.x, pathMissilRecalculado[pathMissilRecalculado.Length - 2].y);
    }

    public override void timeout()
    {
        if (!hitColetavel)
        {
            monoBehaviour.StopCoroutine(coroutine);

            desligarMirasNosColetaveis();
            resetPup();
        }
    }

    public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorMissilTeleguiado();
    }

    public class FornecedorMissilTeleguiado : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new MissilTeleguiadoPowerUpGo();
        }
    }
}
