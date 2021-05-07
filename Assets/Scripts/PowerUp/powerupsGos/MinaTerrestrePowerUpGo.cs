using System.Collections;
using UnityEngine;

public class MinaTerrestrePowerUpGo : AbstractPowerUpGo
{
    private static Vector3 posInicial;

    private bool configurado;
    private int mina_explosao;
    private int mina_idle;

    private Animator animator;
    private GameObject goExplosao;

    private int tempoExplosao;

    public MinaTerrestrePowerUpGo(GameObject tileMinaTerrestre)
        :base(tileMinaTerrestre, "mina-terrestre")
    {
        mina_explosao = Animator.StringToHash("explosao");
        mina_idle = Animator.StringToHash("idle");
    }

    public override bool garraPodeSegurar()
    {
        return false;
    }

    public override void iniciarNaPosicao(Vector3 posicao)
    {
        posInicial = posicao;
    }

    public override void ligar()
    {
        Debug.Log("ligar");
        if (!configurado)
        {
            configurarObjetoMina();
        }
        base.ligar();
        posInicial.y = -3.7f;
        base.colocarNaPosicao(posInicial);
        monoBehaviour.StartCoroutine(explodir());
    }

    private IEnumerator explodir()
    {
        yield return new WaitForSeconds(tempoExplosao);

        goExplosao.SetActive(true);
        goExplosao.transform.position = new Vector3(goExplosao.transform.position.x, goExplosao.transform.position.y + 0.4f, goExplosao.transform.position.z);
        animator.Play(mina_explosao);
        yield return new WaitForSeconds(0.25f);

        goExplosao.SetActive(false);
        PequenaExplosaoShake explosaoShake = new PequenaExplosaoShake(monoBehaviour);
        explosaoShake.shake();
        resetMe();
        yield return new WaitForSeconds(1.1f);

        powerUpFinalizacao.finalizado();
        yield return null;
    }

    private void resetMe()
    {
        desligar();        
        animator.Play(mina_idle);
        powerUpFinalizacao.preFinalizar();                
    }

    private void configurarObjetoMina()
    {
        animator   = goColetavel.transform.Find("imagem").GetComponent<Animator>();
        goExplosao = goColetavel.transform.Find("explosao").gameObject;
        
        configurado = true;
    }

    public override void parar() { }
    public override void colocarNaPosicao(Vector3 posicao) { }
    public override void desligarGravidade() { }
    public override void ligarGravidade() { }
    public override void fixarVerticalmente() { }

}
