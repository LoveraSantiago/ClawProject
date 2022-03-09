public class RollbackPowerUpGo : AbstractDisplaySlotPowerUpGo
{
    public RollbackPowerUpGo()
        :base(powerUpDto.VazioPUp, "rollback")
    {
    }

    protected override PowerUpEnums.TIPO getTipoRestartPup()
    {
        return PowerUpEnums.TIPO.ROLLBACK;
    }   
}
