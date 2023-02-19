using UnityEngine;

public class RollbackPowerUpGo : AbstractDisplaySlotPowerUpGo
{
    public RollbackPowerUpGo()
        :base(powerUpDto.VazioPUp, "rollback")
    {
    }

    protected override Color getCorEfeito()
    {
        CorHdrEfeitoDto corHdr = powerUpDto.RollBackDto.CorEfeitoRollback;
        return HSBColor.toHdrColor(corHdr.CorMaterial, corHdr.HdrMaterial);
    }

    protected override PowerUpEnums.TIPO getTipoRestartPup()
    {
        return PowerUpEnums.TIPO.ROLLBACK;
    }   
}
