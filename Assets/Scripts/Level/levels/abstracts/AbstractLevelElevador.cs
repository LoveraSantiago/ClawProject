public abstract class AbstractLevelElevador : AbstractLevel
{
    public AbstractLevelElevador(MaquinaCor maquinaCor):base(maquinaCor) { }

    public override TipoGame getTipoGame()
    {
        return TipoGame.ELEVADOR;
    }

    public override string getMsgObjetivoLevel()
    {
        return LevelUtils.MSG_ELEVADOR;
    }

    public abstract int[,] getArrayDeColetaveisSub();

}
