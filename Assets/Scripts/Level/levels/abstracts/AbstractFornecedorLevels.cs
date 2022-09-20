public abstract class AbstractFornecedorLevels
{
    public AbstractLevel getLevelByIndiceDezena(int idMapa, int indice)
    {
        AbstractLevel level = getLevelPorIndice(indice);
        level.setIndiceLevelAtual(((10 * idMapa) - 10) + indice);
        return level;
    }

    public AbstractLevel getLevelByIndiceGeral(int idMapa, int indice)
    {
        int indiceLevel = ((indice - 1) % 10) + 1;
        return getLevelByIndiceDezena(idMapa, indiceLevel);
    }

    public int getIndiceMaxLevelLiberadoDoMapa(int idMapa)
    {
        int maxLevelGeralLiberado = PlayerPrefsMapas.getIndiceLevelLiberado();
        if ((idMapa * 10) <= maxLevelGeralLiberado)
        {
            return getQtdLevels();
        }
        maxLevelGeralLiberado = maxLevelGeralLiberado % 10;
        if (maxLevelGeralLiberado == 0)
        {
            return 1;
        }
        return maxLevelGeralLiberado;
    }

    protected abstract AbstractLevel getLevelPorIndice(int level);
    public abstract int getQtdLevels();    
}
