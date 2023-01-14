using System.Collections;
using UnityEngine;

public class MinaTerrestrePowerUpGo : PowerUpSemInteracao
{
    private static Vector3 posInicial;

    private AnimacaoExplosaoPup animacao;
    private CircleCollider2D colliderExplosao;

    public MinaTerrestrePowerUpGo()
        :base(powerUpDto.MinaDto.MinaTerrestreGo, "mina-terrestre"){}    

    public override void iniciarNaPosicao(Vector3 posicao)
    {
        posInicial = posicao;
    }

    public override void configurarPup()
    {
        Animator animator = extrairComponenteFrom<Animator>("imagem");
        animacao = new AnimacaoExplosaoPup(animator);

        colliderExplosao = extrairComponenteFrom<CircleCollider2D>("explosao");
    }

    public override void iniciarPup()
    {
        posInicial.y = powerUpDto.HalturaPupDraggavel;
        base.colocarNaPosicao(posInicial);

        EfeitoSpawner efeitoSpwaner = new EfeitoSpawner(powerUpDto.EfeitoMaterializeDto);
        Sprite spriteBomba = powerUpDto.MinaDto.SpriteMina;
        
        efeitoSpwaner.spawnPowerUp(spriteBomba, getPosicao(), new Vector3(0.8f, 0.8f, 0));

        ContextoEstaticoUtils.monoBehaviour.StartCoroutine(explodir(efeitoSpwaner));
    }

    public override void resetPup()
    {
        desligar();
        animacao.playIdle();        
        powerUpFinalizacao.preFinalizar();

        EfeitoExplosoes efeitoExplosao = new EfeitoExplosoes();
        efeitoExplosao.desligar(powerUpDto.MinaDto.EfeitoExplosao);            
    }

    private IEnumerator explodir(EfeitoSpawner efeitoSpwaner)
    {
        yield return new WaitForSeconds(getDelayInicioMaterialize());

        ligar();
        efeitoSpwaner.desligar();
        animacao.playPreExplodir();
        yield return new WaitForSeconds(powerUpDto.MinaDto.DelayInicial);

        processarExplosao();
        yield return new WaitForSeconds(powerUpDto.MinaDto.DelayExplosao);

        processarPosExplosao();
        yield return new WaitForSeconds(powerUpDto.MinaDto.DelayPosExplosao);

        powerUpFinalizacao.finalizado();
        yield return null;
    }    

    private void processarExplosao()
    {
        colliderExplosao.gameObject.SetActive(true);

        Vector3 posicaoExplosao = getPosicao() + new Vector3(0, powerUpDto.MinaDto.HalturaExplosao, 0);
        EfeitoExplosoes efeitoExplosao = new EfeitoExplosoes();
        efeitoExplosao.ligar(powerUpDto.MinaDto.EfeitoExplosao, posicaoExplosao);

        somPowerUp.playSomExplosao();

        CameraShake cameraShake = new CameraShake();        
        cameraShake.shakeEParar(powerUpDto.MinaDto.CameraShakeDto);
    }

    private void processarPosExplosao()
    {
        colliderExplosao.gameObject.SetActive(false);

        ExplosaoHit explosaoHit = new ExplosaoHit();
        explosaoHit.acertarGaiolas(colliderExplosao.transform.position, colliderExplosao.radius);

        resetPup();
    }    
}
