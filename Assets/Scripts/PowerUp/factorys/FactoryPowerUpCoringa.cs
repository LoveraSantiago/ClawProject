public class FactoryPowerUpCoringa : AbstractFactoryPowerUp
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
                .configNomes(6, PowerUpEnums.TIPO.CORINGA, "Coringa")
                .configFamilia(PowerUpEnums.FAMILIA.TRANSMUTACAO)
                .configPreco(1)
                .configDuracao(9)
                .configSupplierDePowerUpGo(this)
                .configIsClicavel(true)
                .configDescricao(
                    "Troque um coletavel por um outro coletavel aleatorio",
                    "Fique atento ao tempo de duração para trocar o coletavel.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new CoringaPowerUpGo();
    }
}
