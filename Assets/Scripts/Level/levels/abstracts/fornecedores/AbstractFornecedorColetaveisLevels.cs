public abstract class AbstractFornecedorColetaveisLevels
{
    public abstract ColetavelEntidade[] getColetaveis();

    public AbstractLevel getLevel(ColetavelEntidade coletavelEntidade)
    {
        return getLevelToColetavel(coletavelEntidade);
    }

    protected abstract AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade);
}
