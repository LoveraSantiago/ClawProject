using System.Collections;
using UnityEngine;

public class MissilTeleguiadoPowerUpGo : AbstractPowerUpGo,
                                         PowerUpInteracaoComGarra
{
    private readonly int MISSIL_ACIONADO;
    private readonly int MISSIL_EXPLOSAO;
    private readonly int MISSIL_IDLE;
    
    private bool hitColetavel;
    private float distanciaAnterior;

    private ColetaveisMiras miras;
    private CapsuleCollider2D capsuleCollider;
    
    private Vector2[] pathMissilRecalculado;    
    private Animator animator;

    private ParticleSystem particulas;
    private Coroutine coroutine;

    public MissilTeleguiadoPowerUpGo() : 
        base(powerUpDto.MissilTeleguiadoDto.MissilGo, "missil-teleguiado")
    {        
        MISSIL_ACIONADO = Animator.StringToHash("missil-acionado");
        MISSIL_EXPLOSAO = Animator.StringToHash("explosao");
        MISSIL_IDLE     = Animator.StringToHash("idle");

        miras = new ColetaveisMiras();
        particulas = goColetavel.transform.Find("imagem")
                                .transform.Find("faiscas")
                                .GetComponent<ParticleSystem>();
    }

    public PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra()
    {
        return PowerUpEntidade.INTERACAOGARRA.PARADO;
    }

    public override PowerUpInteracaoComGarra getObjInteracaoComGarra()
    {
        return this;
    }

    public float getAnguloParaGarraSegurar()
    {
        return powerUpDto.MissilTeleguiadoDto.AngGarra;
    }

    public override void colocarNaPosicao(Vector3 posicao)
    {
        base.colocarNaPosicao(posicao + new Vector3(0, powerUpDto.MissilTeleguiadoDto.HalturaPos, 0));
    }

    public override void configurarPup()
    {        
        capsuleCollider = goColetavel.GetComponent<CapsuleCollider2D>();
        animator = goColetavel.transform.Find("imagem").GetComponent<Animator>();
    }

    public override void iniciarPup()
    {
        ligar();
        miras.ligar();
        coroutine = monoBehaviour.StartCoroutine(selecionarAlvo());
    }

    public override void resetPup()
    {
        desligar();
        powerUpFinalizacao.finalizado();
        particulas.gameObject.SetActive(false);
        animator.Play(MISSIL_IDLE);
        colocarNoAngulo(0);
    }

    private IEnumerator selecionarAlvo()
    {
        hitColetavel = false;
        ColetavelQuery coletavelQuery = new ColetavelQuery();
        ColetavelHit coletavelHit = new ColetavelHit();
        while (!hitColetavel)
        {
            if (inputGame.aconteceuTapNaAreaSuperior())
            {
                Collider2D coletavelAcertado = coletavelHit.hit(inputGame);
                if (coletavelAcertado != null)
                {
                    string nomeAlvo = coletavelAcertado.name;
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
        particulas.gameObject.SetActive(true);
        particulas.Play();
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
            contador += (powerUpDto.MissilTeleguiadoDto.Velocidade * Time.deltaTime);
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
                if ((contadorIndice * 3 + 3) > powerUpDto.MissilTeleguiadoDto.PathMissilDto.PathPointsMissil.Length)
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
        particulas.Stop();
        animator.Play(MISSIL_EXPLOSAO);
        coletavel.disparar(powerUpDto.MissilTeleguiadoDto.VelocidadeHit, powerUpDto.MissilTeleguiadoDto.VelocidadeHit);
        coletavel.desligarAnimacao();

        CameraShake cameraShake = new CameraShake();
        cameraShake.shakeEParar(1f, new Vector3(50, 50, 50), 50f, 0.4f, monoBehaviour);
        powerUpFinalizacao.preFinalizar();

        yield return new WaitForSeconds(powerUpDto.MissilTeleguiadoDto.DelayFinalizar);
        resetPup();
        yield return null;
    }    

    private void recalcularPath(Vector3 posicaoFim)
    {
        PathMissilDto pathMissil = powerUpDto.MissilTeleguiadoDto.PathMissilDto;
        Transform tranformMain = pathMissil.GoMainPath.transform;
        if (posicaoFim.x > 0)
        {
            tranformMain.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            tranformMain.localScale = new Vector3(1f, 1f, 1f);
        }

        int lenghPath = pathMissil.PathPointsMissil.Length;
        pathMissilRecalculado = new Vector2[lenghPath];
        for(int contador = 0; contador < lenghPath; contador++)
        {
            pathMissilRecalculado[contador] = pathMissil.PathPointsMissil[contador].position;
        }

        pathMissilRecalculado[lenghPath - 1] = posicaoFim;
        pathMissilRecalculado[lenghPath - 2] = new Vector2(posicaoFim.x, pathMissilRecalculado[lenghPath - 2].y);
    }

    public override void timeout()
    {
        if (!hitColetavel)
        {
            monoBehaviour.StopCoroutine(coroutine);

            miras.desligar();
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
