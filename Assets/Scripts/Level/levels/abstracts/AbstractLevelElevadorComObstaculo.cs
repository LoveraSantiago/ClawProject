public abstract class AbstractLevelElevadorComObstaculo : AbstractLevel
{
    public AbstractLevelElevadorComObstaculo(MaquinaCor maquinaCor) : base(maquinaCor) { }

    public override string getMsgObjetivoLevel()
    {
        return LevelUtils.MSG_ELEVADOR;
    }

    public override TipoGame getTipoGame()
    {
        return TipoGame.ELEVADOR;
    }

    public abstract int[,] getArrayDeColetaveisSub();

    public abstract bool[,] getArrayDeObstaculos();
}