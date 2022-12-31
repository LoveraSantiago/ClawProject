public class FactoryPowerUpMinaTerrestre : AbstractFactoryPowerUp
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
                .configNomes(2, PowerUpEnums.TIPO.MINA_TERRESTRE, "Mina Terrestre")
                .configFamilia(PowerUpEnums.FAMILIA.EXPLOSIVOS)
                .configPreco(2)
                .configDuracao(3)
                .configArea(PowerUpEnums.AREA.CHAO)
                .configSupplierDePowerUpGo(this)
                .configIsClicavel(false)
                .configDescricao(
                    "Plante uma mina terrestre abaixo dos coletaveis para espalhar suas posições.",
                    "Fique atento a àrea de plantio da mina.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new MinaTerrestrePowerUpGo();
    }
}
