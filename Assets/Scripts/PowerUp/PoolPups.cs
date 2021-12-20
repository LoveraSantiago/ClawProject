public class PoolPups : GenericPool<PowerUpEnums.TIPO, PowerUpEntidade>
{
    public PoolPups addPup(PowerUpEnums.TIPO tipo, AbstractFactoryPup abstractFactory)
    {
        addChaveValor(tipo, abstractFactory.factoryPupEntidade());
        return this;
    }
}
