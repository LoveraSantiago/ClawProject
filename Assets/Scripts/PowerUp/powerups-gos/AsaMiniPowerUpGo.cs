using System.Collections;
using UnityEngine;

public class AsaMiniPowerUpGo : AbstractAsaPowerUpGo
{
    public AsaMiniPowerUpGo() 
        : base(powerUpDto.AsaDto.AsaMiniGo, "MiniAsas"){}

    protected override IEnumerator voar(ColetavelTile coletavelAcertado)    
    {
        setGravidade(powerUpDto.AsaDto.GravidadeNeg);
        acionarTriggerNoCollider();        
        playAnimacaoVoar();

        Vector3 posicaoInicial = getPosicao();
        float posXmax = posicaoInicial.x + powerUpDto.AsaDto.Offset;
        float posXmin = posicaoInicial.x - powerUpDto.AsaDto.Offset;

        ColetavelHelper coletaveisHelper = new ColetavelHelper();
        ColetavelTile coletavelMaisAlto = coletaveisHelper.getColetavelMaisAlto();
        while (getPosicao().y < coletavelMaisAlto.getPosicao().y + 1f)
        {
            Vector3 posicaoAtual = getPosicao();
            float xZigZag = Mathf.Lerp(posXmin, posXmax, Mathf.PingPong(Time.time, 1f));
            Vector3 posicaoZigZag = new Vector3(xZigZag, posicaoAtual.y, posicaoAtual.z);
            colocarNaPosicao(posicaoZigZag);
            yield return null;
        }

        coletavelAcertado.colocarNaPosicao(getPosicao());
        coletavelAcertado.ligar();
        desligar();

        powerUpFinalizacao.preFinalizar();

        yield return new WaitForSeconds(powerUpDto.AsaDto.DelayFinalizar);

        powerUpFinalizacao.finalizado();
        yield return null;
    }    

    public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorAsaMini();
    }

    public class FornecedorAsaMini : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new AsaMiniPowerUpGo();
        }
    }   
}
