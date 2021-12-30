public class FactoryPupMiniAsas : AbstractFactoryPup
{    
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.MINI_ASAS, "Mini Asas de Escape", "mini-asas-botao")
                .configFamilia(PowerUpEnums.FAMILIA.LEVITACAO)
                .configPreco(2)
                .configDuracao(9)
                .configSupplierDePowerUpGo(this)
                .configIsClicavel(true)
                .configDescricao(
                    "Dê um par de mini asas ao coletavel do seu interesse para que ele tente alcançar a liberdade.",
                    "Selecione o coletavel de interesse a tentar alcançar a liberdade.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new AsaMiniPowerUpGo();
    }
}
