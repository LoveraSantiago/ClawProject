public abstract class AbstractLevelOrdem : AbstractLevel
{
    protected override TIPO_GAME getTipoGame()
    {
        return TIPO_GAME.ORDENADO;
    }

    public abstract BoardOrdem[] getBoardOrdem();
}
