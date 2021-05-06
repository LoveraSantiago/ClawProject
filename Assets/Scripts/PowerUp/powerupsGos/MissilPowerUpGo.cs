using System.Collections;
using UnityEngine;

public class MissilPowerUpGo : Coletavel,
                            GarraInteracaoComPowerUp,
                            ConsumidorDeEventoCollider
{
    public static readonly string STATIC_NOME = "missil";

    private bool configurado;
    private bool acionado;

    private int bomba_explosao;
    private int bomba_idle;

    private GameObject goExplosao;
    private GameObject goImagem;
    private Animator animator;

    private static MonoBehaviour monoBehaviour;
    private static PowerUpFinalizacao powerUpFinalizacao;

    public MissilPowerUpGo(GameObject tileMissil, PowerUpFinalizacao powerUpFinalizacaoArg, MonoBehaviour monoBehaviourArg)
        : base(tileMissil, STATIC_NOME)
    {
        monoBehaviour = monoBehaviourArg;
        powerUpFinalizacao = powerUpFinalizacaoArg;

        bomba_explosao = Animator.StringToHash("explosao");
        bomba_idle = Animator.StringToHash("idle");

        tileMissil.SetActive(false);
    }

    public void consumirEvento(Collision2D evento)
    {
        if (!acionado && Utils.isColetavel(evento))
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
        goImagem.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        yield return new WaitForSeconds(0.25f);

        goExplosao.SetActive(false);
        GrandeExplosaoShake explosaoShake = new GrandeExplosaoShake(monoBehaviour);
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
        goImagem.transform.localScale = new Vector3(1, 1, 1);
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
        
        goExplosao = goColetavel.transform.Find("explosao").gameObject;
        goImagem = goColetavel.transform.Find("imagem").gameObject;
        animator = goImagem.GetComponent<Animator>();

        configurado = true;
    }    
}
