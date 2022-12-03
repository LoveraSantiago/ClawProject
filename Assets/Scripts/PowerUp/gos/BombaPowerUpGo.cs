using UnityEngine;
using System.Collections;

public class BombaPowerUpGo : AbstractExplosivelPowerUpGo,
                              ConsumidorDeEventoCollider                              
{    
    private bool acionado;    
    private AnimacaoExplosaoPup animacao;

    public BombaPowerUpGo()
        : base(powerUpDto.BombaDto.BombaGo, "bomba")
    {
        desligar();        
    }     

    public override float getAnguloParaGarraSegurar()
    {
        return powerUpDto.BombaDto.AngGarra;
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
        ligar();
    }

    public override void resetPup()
    {
        desligar();
        animacao.playIdle();
        acionado = false;
        desafixarVerticalmente();
        colocarNoAngulo(0);
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
        EfeitoExplosao efeitoExplosao = new EfeitoExplosao();
        efeitoExplosao.explodir(powerUpDto.EfeitoExplosao, getPosicao());
        somPowerUp.playSomExplosao();

        ExplosaoHit explosaoHit = new ExplosaoHit();
        explosaoHit.acertarTudo(getPosicao(), 
            powerUpDto.BombaDto.RaioExplosao, 
            powerUpDto.BombaDto.AnguloHit, 
            powerUpDto.BombaDto.VelocidadeHit);        
    }

    private void processarPosExplosao()
    {
        CameraShake cameraShake = new CameraShake();
        cameraShake.shakeEParar(1f, new Vector3(50, 50, 50), 50f, 0.4f);
        powerUpFinalizacao.preFinalizar();
    }

    private void processarFinalizacao()
    {
        resetPup();
        powerUpFinalizacao.finalizado();
    }    
}
