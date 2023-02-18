public abstract class AbstractLevelObstaculos : AbstractLevel
{
    protected AbstractLevelObstaculos(MaquinaCor maquinaCor) : base(maquinaCor){}

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
