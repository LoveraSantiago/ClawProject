public class FactoryPowerUpMola : AbstractFactoryPowerUp
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
            .configNomes(12, PowerUpEnums.TIPO.MOLA, "Mola")
            .configFamilia(PowerUpEnums.FAMILIA.IMPULSO)
            .configPreco(2)
            .configDuracao(3)
            .configArea(PowerUpEnums.AREA.CHAO)
            .configSupplierDePowerUpGo(this)
            .configDescricao(
                "Plante uma mola de impulsão para os coletaveis serem posicionados em um lugar melhor",
                "Fique atento a àrea de plantio da mola.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new MolaPowerUpGo();
    }
}
