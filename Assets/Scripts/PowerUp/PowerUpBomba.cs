using UnityEngine;
using System.Collections;

public class PowerUpBomba : Coletavel,
                            GarraInteracaoComPowerUp,
                            ConsumidorDeEventoCollider
{
    public static readonly string STATIC_NOME = "bomba";  

    private bool configurado;
    private bool acionado;

    private int bomba_explosao;
    private int bomba_idle;

    private GameObject goExplosao;
    private Animator animator;

    private static MonoBehaviour monoBehaviour;
    private static PowerUpFinalizacao powerUpFinalizacao;
    private CircleCollider2D circleCollider;

    public PowerUpBomba(GameObject tileBomb, PowerUpFinalizacao powerUpFinalizacaoArg, MonoBehaviour monoBehaviourArg)
        : base(tileBomb, STATIC_NOME)
    {
        monoBehaviour = monoBehaviourArg;
        powerUpFinalizacao = powerUpFinalizacaoArg;

        bomba_explosao = Animator.StringToHash("explosao");
        bomba_idle = Animator.StringToHash("idle");

        goExplosao = tileBomb.transform.Find("explosao").gameObject;
        circleCollider = goExplosao.GetComponent<CircleCollider2D>();
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

        goExplosao.SetActive(true);
        animator.Play(bomba_explosao);

        ContactFilter2D filter = new ContactFilter2D();
        ContactFilter2D none = filter.NoFilter();
        Collider2D[] array = { };

        int result = circleCollider.OverlapCollider(none, array);
        Debug.Log("Qtd acertados: " + result);

        yield return new WaitForSeconds(0.25f);

        //goExplosao.SetActive(false);
        ExplosaoShake explosaoShake = new ExplosaoShake(monoBehaviour);
        explosaoShake.shake();
        desligar();
        animator.Play(bomba_idle);
        reset();
        yield return new WaitForSeconds(1.1f);

        powerUpFinalizacao.finalizado();
        yield return null;
    }

    private void reset()
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
        configurarDetectorDeCollider();
        configurarExplosao();
        configurarAnimator();
        configurado = true;
    }

    private void configurarDetectorDeCollider()
    {
        goColetavel.GetComponent<DetectorDeColisoes>()
            .registrarConsumidorCollision2dOnEnter(this);
    }

    private void configurarExplosao()
    {
        goExplosao = goColetavel.transform.Find("explosao").gameObject;
    }

    private void configurarAnimator()
    {
        animator = goColetavel.transform.Find("imagem").GetComponent<Animator>();        
    }
}
