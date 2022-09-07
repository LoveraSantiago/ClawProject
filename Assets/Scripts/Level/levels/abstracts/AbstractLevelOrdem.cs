public abstract class AbstractLevelOrdem : AbstractLevel
{
    public override TipoGame getTipoGame()
    {
        return TipoGame.ORDENADO;
    }

    public abstract BoardOrdem[] getBoardOrdem();
}
