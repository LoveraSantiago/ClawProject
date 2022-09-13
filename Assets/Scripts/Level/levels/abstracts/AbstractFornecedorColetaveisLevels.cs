public abstract class AbstractFornecedorColetaveisLevels
{
    protected abstract ColetavelEntidade[] getArrayDeColetaveis();

    public AbstractLevel getLevel(ColetavelEntidade coletavelEntidade)
    {
        return getLevelToColetavel(coletavelEntidade);
    }

    protected abstract AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade);
}
