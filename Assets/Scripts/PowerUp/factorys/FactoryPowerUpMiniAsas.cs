public class FactoryPowerUpMiniAsas : AbstractFactoryPowerUp
{    
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
                .configNomes(7, PowerUpEnums.TIPO.MINI_ASAS, "Mini Asas de Escape")
                .configFamilia(PowerUpEnums.FAMILIA.LEVITACAO)
                .configPreco(2)
                .configDuracao(9)
                .configSupplierDePowerUpGo(this)
                .configIsClicavel(true)
                .configDescricao(
                    "Dê um par de mini asas ao coletavel para tentar alcançar a liberdade.",
                    "Fique atento ao tempo de duração para dar asas ao coletavel.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new AsaMiniPowerUpGo();
    }
}
