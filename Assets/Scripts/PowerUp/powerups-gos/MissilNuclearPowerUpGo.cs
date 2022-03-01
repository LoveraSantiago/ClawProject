using System.Collections;
using UnityEngine;

public class MissilNuclearPowerUpGo : AbstractPowerUpGo,
                                      ConsumidorDeEventoCollider,
                                      PowerUpInteracaoComGarra
{   
    private bool acionado;
    private AnimacaoExplosaoPup animacao;
    private GameObject goExplosao;        
 
    public MissilNuclearPowerUpGo()
        : base(powerUpDto.MissilNuclearDto.MissilNuclearGo, "missil-nuclear")
    {
        desligar();        
    }

    public TipoInteracaoGarra getInteracaoComGarra()
    {
        return TipoInteracaoGarra.MOVIMENTO;
    }

    public override InteracaoPowerUpComComponente getInteracaoComComponente()
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
        extrairComponente<DetectorDeColisoes>()
            .registrarConsumidorCollision2dOnEnter(this);

        Animator animator = extrairAnimator("imagem");//TODO REPLICADO NOS PUPS EXPLOSIVOS REFATORAR!!!
        animacao = new AnimacaoExplosaoPup(animator);
    }

    public override void iniciarPup()
    {
        ligar();
    }

    public override void resetPup()
    {
        desligar();
        animacao.playIdle();        
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
            Utils.MonoBehaviour.StartCoroutine(explodir());
        }
    }    

    private IEnumerator explodir()
    {
        animacao.playPreExplodir();
        yield return new WaitForSeconds(powerUpDto.MissilNuclearDto.DelayInicial);

        goExplosao.SetActive(true);

        EfeitoExplosao efeitoExplosao = new EfeitoExplosao(powerUpDto);
        efeitoExplosao.explodir(getPosicao());
        
        yield return new WaitForSeconds(powerUpDto.MissilNuclearDto.DelayExplosao);

        goExplosao.SetActive(false);
        CameraShake cameraShake = new CameraShake();
        cameraShake.shakeEDiminuir(1f, new Vector3(150, 150, 150), 25f, 0.4f);
        resetPup();
        yield return new WaitForSeconds(powerUpDto.MissilNuclearDto.DelayPosExplosao);

        powerUpFinalizacao.finalizado();
        yield return null;
    }
}
