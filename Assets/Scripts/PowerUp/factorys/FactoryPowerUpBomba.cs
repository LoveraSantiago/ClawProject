public class FactoryPowerUpBomba : AbstractFactoryPowerUp
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
                .configNomes(0, PowerUpEnums.TIPO.BOMBA_DA_GARRA, "Bomba")
                .configFamilia(PowerUpEnums.FAMILIA.EXPLOSIVOS)
                .configDuracao(9)
                .configSupplierDePowerUpGo(this)
                .configIsClicavel(true)
                .configDescricao(
                    "Jogue uma bomba nos coletaveis para espalhar suas posições.",
                    "Você tem 9 segundos para soltar a bomba em cima do seu alvo.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new BombaPowerUpGo();
    }
}
