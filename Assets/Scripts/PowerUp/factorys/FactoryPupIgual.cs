public class FactoryPupIgual : AbstractFactoryPowerUp
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.IGUAL, "Igual", "igual-botao")
                .configFamilia(PowerUpEnums.FAMILIA.TRANSMUTACAO)
                .configPreco(2)
                .configDuracao(9)
                .configSupplierDePowerUpGo(this)
                .configIsClicavel(true)
                .configDescricao(
                    "Troque as posições de um par de coletaveis para mudar suas respectivas posições.",
                    "Selecione o primeiro coletavel a ser igualado com o segundo coletavel.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new IgualPowerUpGo();
    }
}