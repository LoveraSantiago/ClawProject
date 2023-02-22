using UnityEngine;
using System.Collections;

public class AsaPowerUpGo : AbstractAsaPowerUpGo
{   
    public AsaPowerUpGo() 
        : base(powerUpDto.AsaDto.AsaGo, "Asas"){}


    protected override float getGravidadeNegativa()
    {
        return powerUpDto.AsaDto.GravidadeNeg;
    }

    protected override float getOffset()
    {
        return powerUpDto.AsaDto.Offset;
    }

    protected override float getHalturaLimite()
    {
        return powerUpDto.AsaDto.Haltura;
    }

    protected override IEnumerator finalizarVoar(Coletavel coletavelAcertado)
    {
        powerUpFinalizacao.preFinalizar(coletavelAcertado);
        desligarComEstado();

        yield return new WaitForSeconds(powerUpDto.AsaDto.DelayFinalizar);

        powerUpFinalizacao.finalizado();
        yield return null;
        resetPup();
    }   
}
