public abstract class AbstractLevelObstaculos : AbstractLevel
{
    public override TipoGame getTipoGame()
    {
        return TipoGame.OBSTACULO;
    }

    public override string getMsgObjetivoLevel()
    {
        return LevelUtils.MSG_OBSTACULOS;
    }

    public abstract bool[,] getArrayDeObstaculos();    
}
