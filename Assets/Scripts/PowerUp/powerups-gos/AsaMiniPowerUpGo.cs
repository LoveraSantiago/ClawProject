using System.Collections;
using UnityEngine;

public class AsaMiniPowerUpGo : AbstractAsaPowerUpGo
{
    public AsaMiniPowerUpGo() 
        : base(powerUpDto.AsaDto.AsaMiniGo, "MiniAsas"){}    

    protected override float getHalturaLimite()
    {
        ColetavelHelper coletaveisHelper = new ColetavelHelper();
        ColetavelTile coletavelMaisAlto = coletaveisHelper.getColetavelMaisAlto();
        return coletavelMaisAlto.getPosicao().y + 1f;
    }

    protected override IEnumerator finalizarVoar(ColetavelTile coletavelAcertado)
    {
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
