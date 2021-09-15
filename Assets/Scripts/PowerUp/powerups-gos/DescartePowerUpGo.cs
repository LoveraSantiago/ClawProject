using UnityEngine;

public class DescartePowerUpGo : RollbackPowerUpGo
{

    private Coroutine coroutine;
    private bool finalizado;

    public DescartePowerUpGo()
        : base(powerUpDto.VazioPUp, "descarte")
    {
    } 

    protected override PowerUpEntidade.TIPO getTipoRestartPup()
    {
        return PowerUpEntidade.TIPO.DESCARTE;
    }

    public new static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorDescarte();
    }

    public class FornecedorDescarte : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new RollbackPowerUpGo();
        }
    }
}
