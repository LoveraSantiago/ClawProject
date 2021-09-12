using System.Collections;
using UnityEngine;

public class MinaTerrestrePowerUpGo : PowerUpNaoInteracaoComGarra
{
    private static Vector3 posInicial;
    
    private int mina_explosao;
    private int mina_idle;

    private Animator animator;
    private GameObject goExplosao;

    private int tempoExplosao;

    public MinaTerrestrePowerUpGo()
        :base(powerUpDto.MinaDto.MinaTerrestreGo, "mina-terrestre")
    {
        mina_explosao = Animator.StringToHash("explosao");
        mina_idle = Animator.StringToHash("idle");
    }    

    public override void iniciarNaPosicao(Vector3 posicao)
    {
        posInicial = posicao;
    }

    public override void configurarPup()
    {        
        animator = goColetavel.transform.Find("imagem").GetComponent<Animator>();
        goExplosao = goColetavel.transform.Find("explosao").gameObject;

        tempoExplosao = FactoryPowerUpEntidade.getPowerUpEntidadeByEnum(PowerUpEntidade.TIPO.MINA_TERRESTRE).duracao;        
    }

    public override void iniciarPup()
    {
        ligar();
        posInicial.y = powerUpDto.MinaDto.Haltura;
        base.colocarNaPosicao(posInicial);
        Utils.MonoBehaviour.StartCoroutine(explodir());
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
        
        acionarEfeitoExplosao(getPosicao() + new Vector3(0, powerUpDto.MinaDto.HalturaExplosao, 0));        
        yield return new WaitForSeconds(powerUpDto.MinaDto.DelayExplosao);

        goExplosao.SetActive(false);
        CameraShake cameraShake = new CameraShake();
        cameraShake.shakeEParar(1f, new Vector3(50, 50, 50), 50f, 0.4f);
        resetPup();
        yield return new WaitForSeconds(powerUpDto.MinaDto.DelayPosExplosao);

        powerUpFinalizacao.finalizado();
        yield return null;
    }    

    public override void parar() { }//TODO TESTAR ACHO Q DA PRA REMOVER
    public override void colocarNaPosicao(Vector3 posicao) { }
    public override void ligarGravidadeZero() { }
    public override void ligarGravidadeHum() { }
    public override void fixarEixoX() { }

    public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorMina();
    }

    public class FornecedorMina : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new MinaTerrestrePowerUpGo();
        }
    }

}
