using UnityEngine;
using System.Collections;

public class BombaPowerUpGo : Coletavel,
                            GarraInteracaoComPowerUp,
                            ConsumidorDeEventoCollider
{
    private bool configurado;
    private bool acionado;

    private int bomba_explosao;
    private int bomba_idle;
    
    private Animator animator;

    private static MonoBehaviour monoBehaviour;
    private static PowerUpFinalizacao powerUpFinalizacao;
    private CircleCollider2D circleCollider;

    public BombaPowerUpGo(GameObject tileBomb, PowerUpFinalizacao powerUpFinalizacaoArg, MonoBehaviour monoBehaviourArg)
        : base(tileBomb, "bomba")
    {
        monoBehaviour = monoBehaviourArg;
        powerUpFinalizacao = powerUpFinalizacaoArg;

        bomba_explosao = Animator.StringToHash("explosao");
        bomba_idle = Animator.StringToHash("idle");

        tileBomb.SetActive(false);
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
        desligar();
        animator.Play(bomba_idle);
        resetMe();
        yield return new WaitForSeconds(1.1f);

        powerUpFinalizacao.finalizado();
        yield return null;
    }

    private void resetMe()
    {
        powerUpFinalizacao.preFinalizar();
        acionado = false;
        desafixarVerticalmente();
    }

    public override void ligar()
    {
        if (!configurado)
        {
            configurarObjetoBomba();            
        }
        base.ligar();
    }

    private void configurarObjetoBomba()
    {
        goColetavel.GetComponent<DetectorDeColisoes>()
            .registrarConsumidorCollision2dOnEnter(this);
        
        animator = goColetavel.transform.Find("imagem").GetComponent<Animator>();
        
        circleCollider = goColetavel.GetComponent<CircleCollider2D>();

        configurado = true;
    }    

    private void processarExplosao()
    {
        ColetavelQuery query = new ColetavelQuery();

        LayerMask mask = LayerMask.GetMask("Coletavel");
        Collider2D[] acertados = Physics2D.OverlapCircleAll(goColetavel.transform.position, 0.75f, mask);

        for (int contador = 0; contador < acertados.Length; contador++)
        {
            string nomeAcertado = acertados[contador].name;
            Coletavel acertado = query.getColetavelInGameByName(nomeAcertado);
            int angulo = determinarAngulo(acertado.getPosicao());
            acertado.disparar(angulo, 5f);
        }
    }

    private int determinarAngulo(Vector3 posicao)
    {
        if (getPosicao().x < posicao.x) return -45;
        else return 45;
    }
}
