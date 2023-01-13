public class FactoryPowerUpMissilNuclear : AbstractFactoryPowerUp
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return new PowerUpEntidade()
                .configNomes(1, PowerUpEnums.TIPO.MISSIL_NUCLEAR, "Bomba Nuclear")
                .configFamilia(PowerUpEnums.FAMILIA.EXPLOSIVOS)
                .configDuracao(9)
                .configSupplierDePowerUpGo(this)
                .configIsClicavel(true)
                .configDescricao(
                    "Jogue a bomba de grande raio explosivo nos coletaveis para espalhar suas posições.",
                    "Fique atento ao tempo de duração para soltar a bomba em cima do seu alvo.");
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new MissilNuclearPowerUpGo();
    }
}
