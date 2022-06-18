public class FactoryPowerUpRollback : AbstractFactoryPowerUp
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
                .configNomes(10, PowerUpEnums.TIPO.ROLLBACK, "Rollback", "rollback-botao")
                .configFamilia(PowerUpEnums.FAMILIA.MECANISMO)
                .configDuracao(9)
                .configSupplierDePowerUpGo(this)
                .configIsClicavel(true)
                .configIsColetavel(true)
                .configDescricao(
                    "Selecione um coletado para retornar ao board para tentar uma melhor combinação de coletados.",
                    "Selecione no display de coletados o coletado que deseja ser retornado ao boarde.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new RollbackPowerUpGo();
    }
}
