public class FactoryPowerUpMissilTeleguiado : AbstractFactoryPowerUp
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
                .configNomes(3, PowerUpEnums.TIPO.MISSIL_TELEGUIADO, "Missil Teleguiado")
                .configFamilia(PowerUpEnums.FAMILIA.EXPLOSIVOS)
                .configPreco(2)
                .configDuracao(9)
                .configSupplierDePowerUpGo(this)
                .configIsClicavel(true)
                .configDescricao(
                    "Acerte um missil teleguiado no coletavel para mudar a posição atual dele.",
                    "Fique atento ao tempo de duração para soltar o missil em cima do seu alvo.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new MissilTeleguiadoPowerUpGo();
    }
}
