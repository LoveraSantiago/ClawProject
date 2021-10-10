using UnityEngine;
using System.Collections;

public class AsaPowerUpGo : AbstractAsaPowerUpGo
{   
    public AsaPowerUpGo() 
        : base(powerUpDto.AsaDto.AsaGo, "Asas"){}           

    protected override IEnumerator voar(ColetavelTile coletavelAcertado)
    {
        setGravidade(powerUpDto.AsaDto.GravidadeNeg);
        acionarTriggerNoCollider();
        playAnimacaoVoar();

        Vector3 posicaoInicial = getPosicao();
        float posXmax = posicaoInicial.x + powerUpDto.AsaDto.Offset;
        float posXmin = posicaoInicial.x - powerUpDto.AsaDto.Offset;

        while (getPosicao().y < powerUpDto.AsaDto.Haltura)
        {
            Vector3 posicaoAtual = getPosicao();
            float xZigZag = Mathf.Lerp(posXmin, posXmax, Mathf.PingPong(Time.time, 1f));
            Vector3 posicaoZigZag = new Vector3(xZigZag, posicaoAtual.y, posicaoAtual.z);
            colocarNaPosicao(posicaoZigZag);
            yield return null;
        }
        powerUpFinalizacao.preFinalizar(coletavelAcertado);
        desligar();

        yield return new WaitForSeconds(powerUpDto.AsaDto.DelayFinalizar);

        powerUpFinalizacao.finalizado();
        yield return null;
    }   

    public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorAsa();
    }

    public class FornecedorAsa : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new AsaPowerUpGo();
        }
    }   
}
