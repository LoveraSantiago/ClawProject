using UnityEngine;

public class ContextoEstaticoUtils 
{
    public static MonoBehaviour MonoBehaviour { get; private set; }

    private static MapaEntidade MapaEntidade;
    private static AbstractLevel Level;

    public static void configMainMono(MonoBehaviour monoBehaviour)
    {
        MonoBehaviour = monoBehaviour;
    }

    public static void configMapaEntidade(MapaEntidade mapaEntidade)
    {
        MapaEntidade = mapaEntidade;
        PlayerPrefsMapas.salvarIndiceNavegacaoMapa(mapaEntidade);
    }

    public static MapaEntidade loadMapaEntidade()
    {
        if(MapaEntidade == null)
        {
            MapaEntidade = PlayerPrefsMapas.getIndiceNavegacaoMapa();
        }
        return MapaEntidade;
    }

    public static void configLevelAtual(AbstractLevel level)
    {
        Level = level;
    }

    public static AbstractLevel loadResetLevelEstaticoAtualOrCreateLevel(int indiceMapa, int indiceLevel)
    {
        if(Level == null)
        {
            MapaEntidade = HelperMapaEntidade.getMapaEntidadeByIndice(indiceMapa);
            logInfoMapaEntidade(indiceMapa);

            Level = MapaEntidade.getLevel(indiceLevel);
            logInfoLevel(indiceLevel);
        }

        AbstractLevel levelAtual = Level;
        Level = null;
        return levelAtual;
    }

    private static void logInfoMapaEntidade(int indiceMapa)
    {
        if (MapaEntidade == null)
        {
            Debug.LogError("ESCOLHIDO INDICE DE MAPA INEXISTENTE " + indiceMapa);
        }
        else
        {
            Debug.LogWarning("CARREGADO MAPA " + MapaEntidade.ToString() + " A PARTIR DE PARAMETRIZACAO DE MAINGAMESCENE");
        }
    }

    private static void logInfoLevel(int indiceLevel)
    {
        if (Level == null)
        {
            Debug.LogError("LEVEL " + indiceLevel + " NAO EXISTE NO INDICE MAPA " + (MapaEntidade == null ? "MAPA INEXISTENTE": MapaEntidade.ToString()));
        }
    }
}
