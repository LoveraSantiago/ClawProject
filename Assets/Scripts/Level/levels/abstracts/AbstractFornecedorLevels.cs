public abstract class AbstractFornecedorLevels
{
    private int[] estadoChallenges;

    public AbstractLevel getLevelByIndiceDezena(int idMapa, int indice)
    {
        AbstractLevel level = getLevelPorIndice(indice);
        int indiceLevelAtual = ((10 * idMapa) - 10) + indice;
        level.addInfosParaLevelEmAndamento(indiceLevelAtual, estadoChallenges[indice - 1]);
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

    public int[] getEstadoChallenges(MapaEntidade mapaEntidade)
    {
        if(estadoChallenges == null)
        {
            estadoChallenges = PlayerPrefsMapas.getChallengesDoMapa(mapaEntidade);
        }
        return estadoChallenges;
    }

    public void resetChallenges(MapaEntidade mapaEntidade)
    {
        estadoChallenges = null;
        getEstadoChallenges(mapaEntidade);
    }

    protected abstract AbstractLevel getLevelPorIndice(int level);
    public abstract int getQtdLevels();    
}
