public class FactoryPowerUpTeleporte : AbstractFactoryPowerUp
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.TELEPORTE, "Tele-Transporte", "teleport-btn")
                .configFamilia(PowerUpEnums.FAMILIA.TRANSMUTACAO)
                .configPreco(3)
                .configDuracao(9)
                .configSupplierDePowerUpGo(this)
                .configIsClicavel(true)
                .configDescricao(
                    "Troque as posições de um par de coletaveis para mudar suas respectivas posições.",
                    "Selecione o primeiro coletavel a ser trocado de lugar. Selecione o segundo coletavel que será trocado de posicao com o primeiro");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new TeleportePowerUpGo();
    }
}
