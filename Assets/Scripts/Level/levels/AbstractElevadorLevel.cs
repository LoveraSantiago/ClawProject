public abstract class AbstractElevadorLevel : AbstractLevel
{
    protected override TIPO_GAME getTipoGame()
    {
        return TIPO_GAME.ELEVADOR;
    }

    public abstract int[,] getArrayDeColetaveisSub();

}
