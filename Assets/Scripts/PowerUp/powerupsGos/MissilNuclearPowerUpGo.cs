using System.Collections;
using UnityEngine;

public class MissilNuclearPowerUpGo : AbstractPowerUpGo,
                               ConsumidorDeEventoCollider
{    

    private bool configurado;
    private bool acionado;

    private int missil_explosao;
    private int missil_idle;

    private GameObject goExplosao;    
    private Animator animator;
 
    public MissilNuclearPowerUpGo(GameObject tileMissil)
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

    public override float getAnguloGarraSegurar()
    {
        return 8f;
    }

    public override void colocarNaPosicao(Vector3 posicao)
    {        
        base.colocarNaPosicao(posicao + new Vector3(0, -0.4f, 0));
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
        colocarNoAngulo(0);
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
        animator = goColetavel.transform.Find("imagem").GetComponent<Animator>();

        configurado = true;
    }    
}
