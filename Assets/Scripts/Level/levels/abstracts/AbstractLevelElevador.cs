public abstract class AbstractLevelElevador : AbstractLevel
{
    public override TipoGame getTipoGame()
    {
        return TipoGame.ELEVADOR;
    }

    public override string getMsgObjetivoLevel()
    {
        return AbstractLevel.MSG_ELEVADOR;
    }

    public abstract int[,] getArrayDeColetaveisSub();

}
