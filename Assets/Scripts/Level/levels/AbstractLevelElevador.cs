public abstract class AbstractLevelElevador : AbstractLevel
{
    public override TIPO_GAME getTipoGame()
    {
        return TIPO_GAME.ELEVADOR;
    }

    public abstract int[,] getArrayDeColetaveisSub();

}
