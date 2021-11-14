public class FactoryPupRollback
{
    public static PowerUpEntidade factory()
    {
        return new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.ROLLBACK, "Rollback", "rollback-botao")
                .configFamilia(PowerUpEnums.FAMILIA.MECANISMO)
                .configDuracao(9)
                .configSupplierDePowerUpGo(RollbackPowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configIsColetavel(true)
                .configDescricao(
                    "Selecione um coletado para retornar ao board para tentar uma melhor combinação de coletados.",
                    "Selecione no display de coletados o coletado que deseja ser retornado ao boarde."); 
    }
}
