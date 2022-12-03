public abstract class AbstractFornecedorLevels
{
    private int[] estadoChallenges;
    private int[] estadoScores;
    private string[] estadosTempos;

    public virtual AbstractLevel getLevelByIndiceDezena(int idMapa, int indice)
    {
        AbstractLevel level = getLevelPorIndice(indice);
        int indiceLevelAtual = ((10 * idMapa) - 10) + indice;

        int indiceDecremento = indice - 1;
        int challenge = estadoChallenges[indiceDecremento];
        int score = estadoScores[indiceDecremento];
        string tempo = estadosTempos[indiceDecremento];

        level.addInfosParaLevelEmAndamento(indiceLevelAtual, challenge, score, tempo);
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
            carregarEstadosLevels(mapaEntidade);
        }
        return estadoChallenges;
    }

    public void resetEstadosLevels(MapaEntidade mapaEntidade)
    {
        estadoChallenges = null;
        getEstadoChallenges(mapaEntidade);
    }

    protected abstract AbstractLevel getLevelPorIndice(int level);
    public abstract int getQtdLevels();    

    private void carregarEstadosLevels(MapaEntidade mapaEntidade)
    {
        estadoChallenges = PlayerPrefsMapas.getChallengesDoMapa(mapaEntidade);
        estadoScores     = PlayerPrefsMapas.getScoresDoMapa(mapaEntidade);
        estadosTempos    = PlayerPrefsMapas.getTemposDoMapa(mapaEntidade);
    }
}
