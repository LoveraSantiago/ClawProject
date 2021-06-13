using System.Collections;
using UnityEngine;

public class MinaTerrestrePowerUpGo : AbstractPowerUpGo
{
    private static Vector3 posInicial;
    
    private int mina_explosao;
    private int mina_idle;

    private Animator animator;
    private GameObject goExplosao;

    private int tempoExplosao;

    public MinaTerrestrePowerUpGo()
        :base(powerUpDto.MinaTerrestrePUp, "mina-terrestre")
    {
        mina_explosao = Animator.StringToHash("explosao");
        mina_idle = Animator.StringToHash("idle");
    }

    public override PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra()
    {
        return PowerUpEntidade.INTERACAOGARRA.NAO_INTERACAO;
    }

    public override void iniciarNaPosicao(Vector3 posicao)
    {
        posInicial = posicao;
    }

    public override void configurarPup()
    {        
        animator = goColetavel.transform.Find("imagem").GetComponent<Animator>();
        goExplosao = goColetavel.transform.Find("explosao").gameObject;

        tempoExplosao = FactoryPowerUpEntidade.getPowerUpEntidadeByEnum(PowerUpEntidade.NAME.MINA_TERRESTRE).duracao;        
    }

    public override void iniciarPup()
    {
        ligar();
        posInicial.y = -3.7f;
        base.colocarNaPosicao(posInicial);
        monoBehaviour.StartCoroutine(explodir());
    }

    public override void resetPup()
    {
        desligar();
        animator.Play(mina_idle);
        powerUpFinalizacao.preFinalizar();
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
        resetPup();
        yield return new WaitForSeconds(1.1f);

        powerUpFinalizacao.finalizado();
        yield return null;
    }    

    public override void parar() { }
    public override void colocarNaPosicao(Vector3 posicao) { }
    public override void ligarGravidadeZero() { }
    public override void ligarGravidadeHum() { }
    public override void fixarVerticalmente() { }

    public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new Fornecedor();
    }

    public class Fornecedor : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new MinaTerrestrePowerUpGo();
        }
    }

}
