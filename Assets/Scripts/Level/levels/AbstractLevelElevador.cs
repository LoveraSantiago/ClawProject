public abstract class AbstractLevelElevador : AbstractLevel
{
    public override TipoGame getTipoGame()
    {
        return TipoGame.ELEVADOR;
    }

    public abstract int[,] getArrayDeColetaveisSub();

}
