using UnityEngine;
using System.Collections;

public class BombaPowerUpGo : AbstractPowerUpGo,
                            ConsumidorDeEventoCollider
{    
    private bool acionado;

    private int bomba_explosao;
    private int bomba_idle;
    
    private Animator animator;
    
    private CircleCollider2D circleCollider;

    public BombaPowerUpGo()
        : base(powerUpDto.BombPUp, "bomba")
    {
        bomba_explosao = Animator.StringToHash("explosao");
        bomba_idle     = Animator.StringToHash("idle");

        goColetavel.SetActive(false);
    }

    public override PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra()
    {
        return PowerUpEntidade.INTERACAOGARRA.MOVIMENTO;
    }

    public override float getAnguloParaGarraSegurar()
    {
        return 10f;
    }

    public override void configurarPup()
    {
        goColetavel.GetComponent<DetectorDeColisoes>()
            .registrarConsumidorCollision2dOnEnter(this);

        animator = goColetavel.transform.Find("imagem").GetComponent<Animator>();

        circleCollider = goColetavel.GetComponent<CircleCollider2D>();
    }

    public override void iniciarPup()
    {
        ligar();
    }

    public override void resetPup()
    {
        desligar();
        animator.Play(bomba_idle);
        acionado = false;
        desafixarVerticalmente();
        colocarNoAngulo(0);
    }

    public void consumirEvento(Collision2D evento)
    {        
        if(!acionado && Utils.isColetavel(evento))
        {
            acionado = true;
            monoBehaviour.StartCoroutine(explodir());
        }
    }
    
    private IEnumerator explodir()
    {
        yield return new WaitForSeconds(0.4f);
        
        animator.Play(bomba_explosao);
        processarExplosao();       

        yield return new WaitForSeconds(0.25f);
                
        PequenaExplosaoShake explosaoShake = new PequenaExplosaoShake(monoBehaviour);
        explosaoShake.shake();
        powerUpFinalizacao.preFinalizar();
        resetPup();
        yield return new WaitForSeconds(1.1f);

        powerUpFinalizacao.finalizado();
        yield return null;
    }    

    private void processarExplosao()
    {
        LayerMask mask = LayerMask.GetMask("Coletavel");
        Collider2D[] acertados = Physics2D.OverlapCircleAll(goColetavel.transform.position, 1f, mask);
        ColetavelQuery coletavelQuery = new ColetavelQuery();

        for (int contador = 0; contador < acertados.Length; contador++)
        {
            string nomeAcertado = acertados[contador].name;
            Coletavel acertado = coletavelQuery.getColetavelInGameByName(nomeAcertado);
            int angulo = determinarAngulo(acertado.getPosicao());
            acertado.disparar(angulo, 7.5f);
        }
    }

    private int determinarAngulo(Vector3 posicao)
    {        
        if (getPosicao().x < posicao.x) return -40;
        else return 40;
    }

    public static Supplier<AbstractPowerUpGo> getSupplier()
    {
        return new Supplier();
    }

    public class Supplier : Supplier<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo get()
        {
            return new BombaPowerUpGo();
        }
    }
}
