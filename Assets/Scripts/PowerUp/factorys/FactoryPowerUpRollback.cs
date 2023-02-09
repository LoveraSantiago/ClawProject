public class FactoryPowerUpRollback : AbstractFactoryPowerUp
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
                .configNomes(10, PowerUpEnums.TIPO.ROLLBACK, "Rollback")
                .configFamilia(PowerUpEnums.FAMILIA.MECANISMO)
                .configDuracao(9)
                .configSupplierDePowerUpGo(this)
                .configIsClicavel(true)
                .configIsColetavel(true)
                .configDescricao(
                    "Selecione no display de coletados o coletado que deseja ser retornado à maquina.",
                    "Fique atento ao tempo de duração selecionar um coletado.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new RollbackPowerUpGo();
    }
}
