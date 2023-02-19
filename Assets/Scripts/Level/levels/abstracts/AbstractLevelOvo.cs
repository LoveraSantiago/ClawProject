public abstract class AbstractLevelOvo : AbstractLevel
{
    protected AbstractLevelOvo(MaquinaCor maquinaCor) : base(maquinaCor){}

    public override bool devolverParaBoard()
    {
        return true;
    }

    public override string getMsgObjetivoLevel()
    {
        return LevelUtils.MSG_MEMORIA;
    }

    public override TipoGame getTipoGame()
    {
        return TipoGame.MEMORIA;
    }
}
