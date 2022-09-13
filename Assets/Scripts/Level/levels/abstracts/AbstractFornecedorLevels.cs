public abstract class AbstractFornecedorLevels
{
    public AbstractLevel getLevel(int level)
    {
        return getLevelPorIndice(level);
    }

    protected abstract AbstractLevel getLevelPorIndice(int level);
    public abstract int getQtdLevels();    
}
