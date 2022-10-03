public abstract class AbstractLevelOrdem : AbstractLevel
{
    public override TipoGame getTipoGame()
    {
        return TipoGame.ORDENADO;
    }

    public override string getMsgObjetivoLevel()
    {
        return AbstractLevel.MSG_ORDENADO;
    }

    public abstract BoardOrdem[] getBoardOrdem();
}
