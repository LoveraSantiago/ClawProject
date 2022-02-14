public abstract class AbstractFactoryPowerUp : Fornecedor<AbstractPowerUpGo>
{
    public abstract PowerUpEntidade factoryPupEntidade();
    public abstract AbstractPowerUpGo fornecer();
}
