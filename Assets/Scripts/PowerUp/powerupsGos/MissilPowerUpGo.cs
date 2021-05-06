using System.Collections;
using UnityEngine;

public class MissilPowerUpGo : AbstractPowerUpGo,
                               ConsumidorDeEventoCollider
{    

    private bool configurado;
    private bool acionado;

    private int missil_explosao;
    private int missil_idle;

    private GameObject goExplosao;
    private GameObject goImagem;
    private Animator animator;
 
    public MissilPowerUpGo(GameObject tileMissil)
        : base(tileMissil, "missil")
    {
        missil_explosao = Animator.StringToHash("explosao");
        missil_idle = Animator.StringToHash("idle");

        tileMissil.SetActive(false);
    }

    public override bool garraPodeSegurar()
    {
        return true;
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
        animator.Play(missil_explosao);
        goImagem.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        yield return new WaitForSeconds(0.25f);

        goExplosao.SetActive(false);
        GrandeExplosaoShake explosaoShake = new GrandeExplosaoShake(monoBehaviour);
        explosaoShake.shake();
        resetMe();
        yield return new WaitForSeconds(1.1f);

        powerUpFinalizacao.finalizado();
        yield return null;
    }

    private void resetMe()
    {
        desligar();
        animator.Play(missil_idle);
        powerUpFinalizacao.preFinalizar();
        acionado = false;
        desafixarVerticalmente();
        goImagem.transform.localScale = new Vector3(1, 1, 1);
    }

    public override void ligar()
    {
        if (!configurado)
        {
            configurarObjetoMissil();
        }
        base.ligar();
    }

    private void configurarObjetoMissil()
    {
        goColetavel.GetComponent<DetectorDeColisoes>()
            .registrarConsumidorCollision2dOnEnter(this);
        
        goExplosao = goColetavel.transform.Find("explosao").gameObject;
        goImagem = goColetavel.transform.Find("imagem").gameObject;
        animator = goImagem.GetComponent<Animator>();

        configurado = true;
    }    
}
