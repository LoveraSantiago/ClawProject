public class FactoryPupBomba : AbstractFactoryPowerUp
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.BOMBA_DA_GARRA, "Bomba", "bomba")
                .configFamilia(PowerUpEnums.FAMILIA.EXPLOSIVOS)
                .configDuracao(9)
                .configSupplierDePowerUpGo(this)
                .configIsClicavel(true)
                .configDescricao(
                    "Jogue uma bomba nos coletaveis para espalhar suas posições.",
                    "A bomba é segurada pela garra e no momento exato toque na tela para que ela solte em cima do seu alvo. Você tem 9 segundos antes que ela solte em um lugar aleatorio.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new BombaPowerUpGo();
    }
}
