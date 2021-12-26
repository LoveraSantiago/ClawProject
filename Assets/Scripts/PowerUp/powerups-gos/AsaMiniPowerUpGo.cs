using System.Collections;
using UnityEngine;

public class AsaMiniPowerUpGo : AbstractAsaPowerUpGo
{
    public AsaMiniPowerUpGo() 
        : base(powerUpDto.AsaMiniDto.AsaMiniGo, "MiniAsas"){}

    protected override float getGravidadeNegativa()
    {
        return powerUpDto.AsaMiniDto.GravidadeNeg;
    }

    protected override float getOffset()
    {
        return powerUpDto.AsaMiniDto.Offset;
    }

    protected override float getHalturaLimite()
    {
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        ColetavelTile coletavelMaisAlto = helperInGame.getColetavelMaisAlto();
        return coletavelMaisAlto.getPosicao().y + powerUpDto.AsaMiniDto.IncrementoHaltura;
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
}
