public abstract class AbstractFornecedorColetaveisLevels
{
    protected abstract ColetavelEntidade[] getArrayDeColetaveis();

    public string getRootPathSprites()
    {
        return "sprites/coletaveis/" + getPathSprite() + "/";
    }

    public abstract string getPathSprite();

    public AbstractLevel getLevel(ColetavelEntidade coletavelEntidade)
    {
        return getLevelToColetavel(coletavelEntidade);
    }

    protected abstract AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade);
}
