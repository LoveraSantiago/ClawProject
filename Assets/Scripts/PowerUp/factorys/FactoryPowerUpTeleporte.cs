public class FactoryPowerUpTeleporte : AbstractFactoryPowerUp
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
                .configNomes(5, PowerUpEnums.TIPO.TELEPORTE, "Tele-Transporte")
                .configFamilia(PowerUpEnums.FAMILIA.TRANSMUTACAO)
                .configPreco(3)
                .configDuracao(9)
                .configSupplierDePowerUpGo(this)
                .configIsClicavel(true)
                .configDescricao(
                    "Troque as posições de um par de coletaveis.",
                    "Fique atento ao tempo de duração para realizar a troca.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new TeleportePowerUpGo();
    }
}
