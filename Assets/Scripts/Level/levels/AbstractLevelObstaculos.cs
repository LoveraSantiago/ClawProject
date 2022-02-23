public abstract class AbstractLevelObstaculos : AbstractLevel
{
    public override TipoGame getTipoGame()
    {
        return TipoGame.OBSTACULO;
    }

    public abstract int[,] getArrayDeObstaculos();    
}
