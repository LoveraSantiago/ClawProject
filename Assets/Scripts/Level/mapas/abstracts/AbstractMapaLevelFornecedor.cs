public abstract class AbstractMapaLevelFornecedor
{
    public AbstractLevel getLevel(int level)
    {
        return getLevelPorIndice(level);
    }

    public abstract AbstractLevel getLevelPorIndice(int level);
    public abstract int getQtdLevels();    
}
