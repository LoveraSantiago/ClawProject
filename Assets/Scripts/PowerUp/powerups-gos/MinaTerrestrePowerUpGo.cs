using System.Collections;
using UnityEngine;

public class MinaTerrestrePowerUpGo : PowerUpNaoInteracaoComGarra
{
    private static Vector3 posInicial;

    private AnimacaoExplosaoPup animacao;
    private GameObject goExplosao;    

    public MinaTerrestrePowerUpGo()
        :base(powerUpDto.MinaDto.MinaTerrestreGo, "mina-terrestre")
    {        
    }    

    public override void iniciarNaPosicao(Vector3 posicao)
    {
        posInicial = posicao;
    }

    public override void configurarPup()
    {        
        Animator animator = goColetavel.transform.Find("imagem").GetComponent<Animator>();
        animacao = new AnimacaoExplosaoPup(animator);
        goExplosao = goColetavel.transform.Find("explosao").gameObject;
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
        animacao.playIdle();        
        powerUpFinalizacao.preFinalizar();
    }

    private IEnumerator explodir()
    {
        animacao.playPreExplodir();
        yield return new WaitForSeconds(powerUpDto.MinaDto.DelayInicial);

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
}
