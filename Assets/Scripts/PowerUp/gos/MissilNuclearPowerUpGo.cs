using System.Collections;
using UnityEngine;

public class MissilNuclearPowerUpGo : AbstractExplosivelPowerUpGo,
                                      ConsumidorDeEventoCollider
{   
    private bool acionado;
    private AnimacaoExplosaoPup animacao;
    private CircleCollider2D colliderExplosao;
 
    public MissilNuclearPowerUpGo()
        : base(powerUpDto.MissilNuclearDto.MissilNuclearGo, new FinderDeSprRenderer1Nivel("imagem"), "missil-nuclear")
    {
        desligar();        
    }        

    public override float getAnguloParaGarraSegurar()
    {
        return powerUpDto.MissilNuclearDto.AngGarra;
    }

    public override float getDelayInicio()
    {
        return getDelayInicioMaterialize();
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
        EfeitoSpawner efeitoSpwaner = new EfeitoSpawner(powerUpDto.EfeitoMaterializeDto);
        Sprite spriteMissil = powerUpDto.MissilNuclearDto.SpriteMissilNuclear;
        efeitoSpwaner.spawnPowerUp(spriteMissil, getPosicao(), new Vector3(1.25f, 1.25f, 0));
        ContextoEstaticoUtils.monoBehaviour.StartCoroutine(showBombaAposSpawnMaterialize(efeitoSpwaner));
    }

    private IEnumerator showBombaAposSpawnMaterialize(EfeitoSpawner efeitoSpwaner)
    {
        yield return new WaitForSeconds(getDelayInicio());
        ligar();
        fixarEixoY();
        efeitoSpwaner.desligar();
    }

    public override void resetPup()
    {
        desligar();
        animacao.playIdle();        
        powerUpFinalizacao.preFinalizar();
        acionado = false;
        desafixarVerticalmente();
        colocarNoAngulo(0);        

        EfeitoExplosoes efeitoExplosao = new EfeitoExplosoes();
        efeitoExplosao.desligar(powerUpDto.MissilNuclearDto.EfeitoExplosao);
    }

    public void consumir(Collision2D evento)
    {
        if (!acionado && isAlvoExplosivel(evento))
        {
            acionado = true;
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(explodir());
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

        EfeitoExplosoes efeitoExplosao = new EfeitoExplosoes();
        efeitoExplosao.ligar(powerUpDto.MissilNuclearDto.EfeitoExplosao, getPosicao());

        somPowerUp.playSomExplosao();

        CameraShake cameraShake = new CameraShake();
        cameraShake.shakeEDiminuir(powerUpDto.MissilNuclearDto.CameraShakeDto);
    }

    private void processarPosExplosao()
    {
        colliderExplosao.gameObject.SetActive(false);

        ExplosaoHit explosaoHit = new ExplosaoHit();
        explosaoHit.acertarGaiolas(colliderExplosao.transform.position, colliderExplosao.radius);

        //CameraShake cameraShake = new CameraShake();        
        //cameraShake.shakeEDiminuir(powerUpDto.MissilNuclearDto.CameraShakeDto);
        resetPup();
    }
}
