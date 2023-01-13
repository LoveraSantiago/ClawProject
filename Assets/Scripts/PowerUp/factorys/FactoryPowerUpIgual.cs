public class FactoryPowerUpIgual : AbstractFactoryPowerUp
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
                .configNomes(4, PowerUpEnums.TIPO.IGUAL, "Igual")
                .configFamilia(PowerUpEnums.FAMILIA.TRANSMUTACAO)
                .configPreco(2)
                .configDuracao(9)
                .configSupplierDePowerUpGo(this)
                .configIsClicavel(true)
                .configDescricao(
                    "Transforme um primeiro coletavel igual a um segundo coletavel",
                    "Fique atento ao tempo de duração para igualar o coletavel.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new IgualPowerUpGo();
    }
}