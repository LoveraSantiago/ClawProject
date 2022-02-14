public class FactoryPowerUpDescarte : AbstractFactoryPowerUp
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.DESCARTE, "Descarte", "descarte-botao")
                .configFamilia(PowerUpEnums.FAMILIA.MECANISMO)
                .configPreco(2)
                .configDuracao(9)
                .configSupplierDePowerUpGo(this)
                .configIsClicavel(true)
                .configIsColetavel(true)
                .configDescricao("Descarte um coletado para tentar uma melhor combinação de coletados.",
                "Selecione no display de coletados o coletado que deseja ser descartado.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new DescartePowerUpGo();
    }
}
