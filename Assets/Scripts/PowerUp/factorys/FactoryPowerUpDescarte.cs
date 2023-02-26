public class FactoryPowerUpDescarte : AbstractFactoryPowerUp
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
                .configNomes(11, PowerUpEnums.TIPO.DESCARTE, "Descarte")
                .configFamilia(PowerUpEnums.FAMILIA.MECANISMO)
                .configPreco(2)
                .configDuracao(9)
                .configSupplierDePowerUpGo(this)
                .configIsClicavel(true)
                .configIsColetavel(true)
                .configDescricao("Descarte um coletado para tentar uma melhor combinação de coletados.",
                "Fique atento ao tempo de duração selecionar um coletado.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new DescartePowerUpGo();
    }
}
