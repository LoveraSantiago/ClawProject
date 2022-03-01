using System.Collections;
using UnityEngine;

public class MinaTerrestrePowerUpGo : PowerUpSemInteracao
{
    private static Vector3 posInicial;

    private AnimacaoExplosaoPup animacao;
    private GameObject goExplosao;    

    public MinaTerrestrePowerUpGo()
        :base(powerUpDto.MinaDto.MinaTerrestreGo, "mina-terrestre"){}    

    public override void iniciarNaPosicao(Vector3 posicao)
    {
        posInicial = posicao;
    }

    public override void configurarPup()
    {
        Animator animator = extrairAnimator("imagem");
        animacao = new AnimacaoExplosaoPup(animator);

        goExplosao = extrairTransform("explosao").gameObject;
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

        goExplosao.SetActive(true);

        Vector3 posicaoExplosao = getPosicao() + new Vector3(0, powerUpDto.MinaDto.HalturaExplosao, 0);
        EfeitoExplosao efeitoExplosao = new EfeitoExplosao(powerUpDto);
        efeitoExplosao.explodir(posicaoExplosao);
        
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
}
