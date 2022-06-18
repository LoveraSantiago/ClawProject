public class FactoryPowerUpBuracoNegro : AbstractFactoryPowerUp
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
            .configNomes(9, PowerUpEnums.TIPO.BURACO_NEGRO, "Buraco Negro", "buraco-negro")
            .configFamilia(PowerUpEnums.FAMILIA.LEVITACAO)
            .configPreco(10)
            .configDuracao(9)
            .configSupplierDePowerUpGo(this)
            .configIsClicavel(true)
            .configIsColetavel(true)
            .configDescricao("Um buraco negro para ajudar a coletar", 
                            "Selecione os coletaveis que serao atraidos para o buraco negro");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new BuracoNegroPowerUpGo();
    }
}
