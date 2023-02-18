public abstract class AbstractLevelNormal : AbstractLevel
{
    protected AbstractLevelNormal(MaquinaCor maquinaCor) : base(maquinaCor){}

    public override TipoGame getTipoGame()
    {
        return TipoGame.NORMAL;
    }
}
