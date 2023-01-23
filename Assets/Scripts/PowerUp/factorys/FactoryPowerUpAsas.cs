public class FactoryPowerUpAsas : AbstractFactoryPowerUp
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
                .configNomes(8, PowerUpEnums.TIPO.ASAS, "Asas da Liberdade")
                .configFamilia(PowerUpEnums.FAMILIA.LEVITACAO)
                .configPreco(4)
                .configDuracao(9)
                .configSupplierDePowerUpGo(this)
                .configIsClicavel(true)
                .configIsColetavel(true)
                .configDescricao(
                    "Dê um par de asas ao coletavel do seu interesse para que ele alcance a liberdade.",
                    "Fique atento ao tempo de duração para dar asas ao coletavel.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new AsaPowerUpGo();
    }
}
