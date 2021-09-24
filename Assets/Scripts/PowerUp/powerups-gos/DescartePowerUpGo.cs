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

    public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorDescarte();
    }

    public class FornecedorDescarte : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new DescartePowerUpGo();
        }
    }
}
