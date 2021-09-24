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

    public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorRollback();
    }    

    public class FornecedorRollback : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new RollbackPowerUpGo();
        }
    }
}
