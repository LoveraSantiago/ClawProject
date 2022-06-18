public class FactoryPowerUpMola : AbstractFactoryPowerUp
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
            .configNomes(12, PowerUpEnums.TIPO.MOLA, "Mola", "btn-mola")
            .configFamilia(PowerUpEnums.FAMILIA.IMPULSO)
            .configPreco(2)
            .configDuracao(3)
            .configArea(PowerUpEnums.AREA.CHAO)
            .configSupplierDePowerUpGo(this)
            .configDescricao(
                "Plante uma mola de impulsão para o coletavel ser posicionado em um lugar melhor para ser coletado",
                "Arraste a molsa para a area azul indicada. Um impulso ao coletavel de interesse para que ele va para uma posicao melhor para ser coletado.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new MolaPowerUpGo();
    }
}
