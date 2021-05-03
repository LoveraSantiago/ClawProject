using UnityEngine;
using System.Collections;

public class PowerUpBomba : Coletavel,
                            GarraInteracaoComPowerUp,
                            ConsumidorDeEventoCollider
{
    public static readonly string STATIC_NOME = "bomba";

    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO
    //TODO RESETAR OBJETO

    private bool configurado;
    private bool acionado;
    private int bomba_explosao;

    private GameObject goExplosao;
    private Animator animator;

    private static MonoBehaviour monoBehaviour;
    private static PowerUpFinalizacao powerUpFinalizacao;

    public PowerUpBomba(GameObject tileBomb, PowerUpFinalizacao powerUpFinalizacaoArg, MonoBehaviour monoBehaviourArg)
        : base(tileBomb, STATIC_NOME)
    {
        monoBehaviour = monoBehaviourArg;
        powerUpFinalizacao = powerUpFinalizacaoArg;

        bomba_explosao = Animator.StringToHash("bomba-explosao");
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
        yield return new WaitForSeconds(0.25f);

        goExplosao.SetActive(false);
        ExplosaoShake explosaoShake = new ExplosaoShake(monoBehaviour);
        explosaoShake.shake();
        desligar();
        powerUpFinalizacao.preFinalizar();
        yield return new WaitForSeconds(1.1f);

        powerUpFinalizacao.finalizado();
        yield return null;
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
