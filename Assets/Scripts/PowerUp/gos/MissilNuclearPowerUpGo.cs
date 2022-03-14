using System.Collections;
using UnityEngine;

public class MissilNuclearPowerUpGo : AbstractExplosivelPowerUpGo,
                                      ConsumidorDeEventoCollider
{   
    private bool acionado;
    private AnimacaoExplosaoPup animacao;
    private CircleCollider2D colliderExplosao;
 
    public MissilNuclearPowerUpGo()
        : base(powerUpDto.MissilNuclearDto.MissilNuclearGo, "missil-nuclear")
    {
        desligar();        
    }        

    public override float getAnguloParaGarraSegurar()
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
        
        colliderExplosao = extrairComponenteFrom<CircleCollider2D>("explosao");

        Animator animator = extrairComponenteFrom<Animator>("imagem");//TODO REPLICADO NOS PUPS EXPLOSIVOS REFATORAR!!!
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
        if (!acionado && isAlvoExplosivel(evento))
        {
            acionado = true;
            Utils.MonoBehaviour.StartCoroutine(explodir());
        }
    }    

    private IEnumerator explodir()
    {
        animacao.playPreExplodir();
        yield return new WaitForSeconds(powerUpDto.MissilNuclearDto.DelayInicial);

        processarExplosao();
        yield return new WaitForSeconds(powerUpDto.MissilNuclearDto.DelayExplosao);

        processarPosExplosao();
        yield return new WaitForSeconds(powerUpDto.MissilNuclearDto.DelayPosExplosao);

        powerUpFinalizacao.finalizado();
        yield return null;
    }

    private void processarExplosao()
    {
        colliderExplosao.gameObject.SetActive(true);        

        EfeitoExplosao efeitoExplosao = new EfeitoExplosao(powerUpDto);
        efeitoExplosao.explodir(getPosicao());
    }

    private void processarPosExplosao()
    {
        colliderExplosao.gameObject.SetActive(false);

        ExplosaoHit explosaoHit = new ExplosaoHit();
        explosaoHit.acertarGaiolas(colliderExplosao.transform.position, colliderExplosao.radius);

        CameraShake cameraShake = new CameraShake();
        cameraShake.shakeEDiminuir(1f, new Vector3(150, 150, 150), 25f, 0.4f);
        resetPup();
    }
}
