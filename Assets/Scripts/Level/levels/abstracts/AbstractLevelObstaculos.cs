public abstract class AbstractLevelObstaculos : AbstractLevel
{
    public override TipoGame getTipoGame()
    {
        return TipoGame.OBSTACULO;
    }

    public override string getMsgObjetivoLevel()
    {
        return AbstractLevel.MSG_OBSTACULOS;
    }

    public abstract bool[,] getArrayDeObstaculos();    
}
