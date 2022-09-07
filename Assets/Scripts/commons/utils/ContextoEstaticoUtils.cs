using UnityEngine;

public class ContextoEstaticoUtils 
{
    public static MonoBehaviour MonoBehaviour { get; private set; }

    private static MapaEntidade mapaEntidade;
    private static AbstractLevel level;

    public static void configMainMono(MonoBehaviour monoBehaviour)
    {
        MonoBehaviour = monoBehaviour;
    }

    public static void configMapaEntidade(MapaEntidade mapaEntidade)
    {
        ContextoEstaticoUtils.mapaEntidade = mapaEntidade;
        PlayerPrefsMapas.salvarIndiceNavegacaoMapa(mapaEntidade);
    }

    public static MapaEntidade loadMapaEntidade()
    {
        if(mapaEntidade == null)
        {
            mapaEntidade = PlayerPrefsMapas.getIndiceNavegacaoMapa();
        }
        return mapaEntidade;
    }

    public static void configMapaLevelAtual(MapaEntidade mapaEntidade, AbstractLevel level)
    {
        configMapaEntidade(mapaEntidade);
        configLevelAtual(level);
    }
    
    public static void configLevelAtual(AbstractLevel level)
    {
        ContextoEstaticoUtils.level = level;
    }

    public static AbstractLevel loadLevelEstaticoAtualOrCreateLevel(int indiceMapa, int indiceLevel)
    {
        if(level == null)
        {
            mapaEntidade = HelperMapaEntidade.getMapaEntidadeByIndice(indiceMapa);
            logInfoMapaEntidade(indiceMapa);

            level = mapaEntidade.getLevel(indiceLevel);
            logInfoLevel(indiceLevel);
        }        
        return level;
    }

    private static void logInfoMapaEntidade(int indiceMapa)
    {
        if (mapaEntidade == null)
        {
            Debug.LogError("ESCOLHIDO INDICE DE MAPA INEXISTENTE " + indiceMapa);
        }
        else
        {
            Debug.LogWarning("CARREGADO MAPA " + mapaEntidade.ToString() + " A PARTIR DE PARAMETRIZACAO DE MAINGAMESCENE");
        }
    }

    private static void logInfoLevel(int indiceLevel)
    {
        if (level == null)
        {
            Debug.LogError("LEVEL " + indiceLevel + " NAO EXISTE NO INDICE MAPA " + (mapaEntidade == null ? "MAPA INEXISTENTE": mapaEntidade.ToString()));
        }
    }
}
