public class FactoryPupAsas : AbstractFactoryPup
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.ASAS, "Asas da Liberdade", "asas-botao")
                .configFamilia(PowerUpEnums.FAMILIA.LEVITACAO)
                .configPreco(4)
                .configDuracao(9)
                .configSupplierDePowerUpGo(this)
                .configIsClicavel(true)
                .configIsColetavel(true)
                .configDescricao(
                    "Dê um par de asas ao coletavel do seu interesse para que ele alcance a liberdade.",
                    "Selecione o coletavel de interesse a alcançar a liberdade.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new AsaPowerUpGo();
    }
}
