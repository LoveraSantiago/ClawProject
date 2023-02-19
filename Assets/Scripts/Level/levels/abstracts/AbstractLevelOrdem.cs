public abstract class AbstractLevelOrdem : AbstractLevel
{
    protected AbstractLevelOrdem(MaquinaCor maquinaCor) : base(maquinaCor){}

    public override TipoGame getTipoGame()
    {
        return TipoGame.ORDENADO;
    }

    public override string getMsgObjetivoLevel()
    {
        return LevelUtils.MSG_ORDENADO;
    }

    public abstract BoardOrdem[] getBoardOrdem();
}
