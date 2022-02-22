public class PoolPowerUps : GenericPool<PowerUpEnums.TIPO, PowerUpEntidade>
{
    public PoolPowerUps addPup(PowerUpEnums.TIPO tipo, AbstractFactoryPowerUp abstractFactory)
    {
        addChaveValor(tipo, abstractFactory.factoryPupEntidade());
        return this;
    }
}
