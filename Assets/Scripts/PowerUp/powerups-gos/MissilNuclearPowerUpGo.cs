using System.Collections;
using UnityEngine;

public class MissilNuclearPowerUpGo : AbstractPowerUpGo,
                                      ConsumidorDeEventoCollider,
                                      PowerUpInteracaoComGarra
{   
    private bool acionado;

    private int missil_explosao;
    private int missil_idle;

    private GameObject goExplosao;    
    private Animator animator;
 
    public MissilNuclearPowerUpGo()
        : base(powerUpDto.MissilNuclearDto.MissilNuclearGo, "missil-nuclear")
    {
        missil_explosao = Animator.StringToHash("explosao");
        missil_idle = Animator.StringToHash("idle");

        goColetavel.SetActive(false);
    }

    public PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra()
    {
        return PowerUpEntidade.INTERACAOGARRA.MOVIMENTO;
    }

    public override PowerUpInteracaoComGarra getObjInteracaoComGarra()
    {
        return this;
    }

    public float getAnguloParaGarraSegurar()
    {
        return powerUpDto.MissilNuclearDto.AngGarra;
    }

    public override void colocarNaPosicao(Vector3 posicao)
    {        
        base.colocarNaPosicao(posicao + new Vector3(0, powerUpDto.MissilNuclearDto.HalturaPos, 0));
    }

    public override void configurarPup()
    {
        goColetavel.GetComponent<DetectorDeColisoes>()
            .registrarConsumidorCollision2dOnEnter(this);

        goExplosao = goColetavel.transform.Find("explosao").gameObject;
        animator = goColetavel.transform.Find("imagem").GetComponent<Animator>();
    }

    public override void iniciarPup()
    {
        ligar();
    }

    public override void resetPup()
    {
        desligar();
        animator.Play(missil_idle);
        powerUpFinalizacao.preFinalizar();
        acionado = false;
        desafixarVerticalmente();
        colocarNoAngulo(0);
    }

    public void consumir(Collision2D evento)
    {
        if (!acionado && UtilsTags.isColetavel(evento))
        {
            acionado = true;
            monoBehaviour.StartCoroutine(explodir());
        }
    }    

    private IEnumerator explodir()
    {
        yield return new WaitForSeconds(powerUpDto.MissilNuclearDto.DelayInicial);

        goExplosao.SetActive(true);
        animator.Play(missil_explosao);        
        yield return new WaitForSeconds(powerUpDto.MissilNuclearDto.DelayExplosao);

        goExplosao.SetActive(false);
        CameraShake cameraShake = new CameraShake();
        cameraShake.shakeEDiminuir(1f, new Vector3(150, 150, 150), 25f, 0.4f, monoBehaviour);
        resetPup();
        yield return new WaitForSeconds(powerUpDto.MissilNuclearDto.DelayFinal);

        powerUpFinalizacao.finalizado();
        yield return null;
    }
    
    public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorMissilNuclear();
    }

    public class FornecedorMissilNuclear : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new MissilNuclearPowerUpGo();
        }
    }
}
