using UnityEngine;
using System.Collections;

public class BombaPowerUpGo : AbstractExplosivelPowerUpGo,
                              ConsumidorDeEventoCollider                              
{    
    private bool acionado;    
    private AnimacaoExplosaoPup animacao;

    public BombaPowerUpGo()
        : base(powerUpDto.BombaDto.BombaGo, new FinderDeSprRenderer1Nivel("imagem"), "bomba")
    {
        //Debug.Log("Bomba instanciada");
        desligar();        
    }     

    public override float getAnguloParaGarraSegurar()
    {
        return powerUpDto.BombaDto.AngGarra;
    }

    public override float getDelayInicio()
    {
        return getDelayInicioMaterialize();
    }

    public override void configurarPup()
    {
        extrairComponente<DetectorDeColisoes>()        
            .registrarConsumidorCollision2dOnEnter(this);
        
        Animator animator = extrairComponenteFrom<Animator>("imagem");
        animacao = new AnimacaoExplosaoPup(animator);
    }

    public override void iniciarPup()
    {
        //Debug.Log("Bomba iniciada");
        EfeitoSpawner efeitoSpwaner = new EfeitoSpawner(powerUpDto.EfeitoMaterializeDto);
        Sprite spriteBomba = powerUpDto.BombaDto.SpriteBomba;
        efeitoSpwaner.spawnPowerUp(spriteBomba, getPosicao(), Vector3.one);
        ContextoEstaticoUtils.monoBehaviour.StartCoroutine(showBombaAposSpawnMaterialize(efeitoSpwaner));
    }

    private IEnumerator showBombaAposSpawnMaterialize(EfeitoSpawner efeitoSpwaner)
    {
        yield return new WaitForSeconds(getDelayInicio());
        ligar();
        efeitoSpwaner.desligar();
    }

    public override void resetPup()
    {
        desligar();
        animacao.playIdle();
        acionado = false;
        desafixarVerticalmente();
        colocarNoAngulo(0);        

        EfeitoExplosoes efeitoExplosao = new EfeitoExplosoes();
        efeitoExplosao.desligar(powerUpDto.BombaDto.EfeitoExplosao);
    }

    public void consumir(Collision2D evento)
    {        
        if(!acionado && isAlvoExplosivel(evento))
        {
            acionado = true;
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(explodir());
        }
    }    
    
    private IEnumerator explodir()
    {        
        animacao.playPreExplodir();
        yield return new WaitForSeconds(powerUpDto.BombaDto.DelayInicial);

        processarExplosao();        
        yield return new WaitForSeconds(powerUpDto.BombaDto.DelayExplosao);

        processarPosExplosao();
        yield return new WaitForSeconds(powerUpDto.BombaDto.DelayPosExplosao);

        processarFinalizacao();
        yield return null;
    }    

    private void processarExplosao()
    {
        EfeitoExplosoes efeitoExplosao = new EfeitoExplosoes();
        efeitoExplosao.ligar(powerUpDto.BombaDto.EfeitoExplosao, getPosicao());
        somPowerUp.playSomExplosao();

        ExplosaoHit explosaoHit = new ExplosaoHit();
        explosaoHit.acertarTudo(getPosicao(), 
            powerUpDto.BombaDto.RaioExplosao, 
            powerUpDto.BombaDto.AnguloHit, 
            powerUpDto.BombaDto.VelocidadeHit);        
        
        CameraShake cameraShake = new CameraShake();
        cameraShake.shakeEParar(powerUpDto.BombaDto.CameraShakeDto);
    }

    private void processarPosExplosao()
    {
        powerUpFinalizacao.preFinalizar();
    }

    private void processarFinalizacao()
    {
        resetPup();
        powerUpFinalizacao.finalizado();
    }        
}
