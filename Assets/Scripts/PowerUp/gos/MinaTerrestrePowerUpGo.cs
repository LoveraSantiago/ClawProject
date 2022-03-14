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
        ligar();
        posInicial.y = powerUpDto.HalturaPupDraggavel;
        base.colocarNaPosicao(posInicial);
        Utils.MonoBehaviour.StartCoroutine(explodir());
    }

    public override void resetPup()
    {
        desligar();
        animacao.playIdle();        
        powerUpFinalizacao.preFinalizar();
    }

    private IEnumerator explodir()
    {
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
        EfeitoExplosao efeitoExplosao = new EfeitoExplosao(powerUpDto);
        efeitoExplosao.explodir(posicaoExplosao);
    }

    private void processarPosExplosao()
    {
        colliderExplosao.gameObject.SetActive(false);

        ExplosaoHit explosaoHit = new ExplosaoHit();
        explosaoHit.acertarGaiolas(colliderExplosao.transform.position, colliderExplosao.radius);

        CameraShake cameraShake = new CameraShake();
        cameraShake.shakeEParar(1f, new Vector3(50, 50, 50), 50f, 0.4f);
        resetPup();
    }    
}
