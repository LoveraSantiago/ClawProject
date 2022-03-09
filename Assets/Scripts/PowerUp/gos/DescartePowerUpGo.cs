using UnityEngine;

public class DescartePowerUpGo : AbstractDisplaySlotPowerUpGo
{

    private Coroutine coroutine;
    private bool finalizado;

    public DescartePowerUpGo()
        : base(powerUpDto.VazioPUp, "descarte")
    {
    } 

    protected override PowerUpEnums.TIPO getTipoRestartPup()
    {
        return PowerUpEnums.TIPO.DESCARTE;
    }    
}
