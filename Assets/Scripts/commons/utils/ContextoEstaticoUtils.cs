using UnityEngine;

public class ContextoEstaticoUtils 
{
    public static MonoBehaviour MonoBehaviour { get; private set; }

    public static MapaEntidade mapaEntidade { get; private set; }
    public static AbstractLevel level { get; private set; }

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

    public static AbstractLevel loadLevelEstaticoAtualOrCreateLevel(MapaEnum mapaEnum, int indiceLevel)
    {
        if(level == null && MapaEnum.DEFAULTS != mapaEnum)
        {
            mapaEntidade = HelperMapaEntidade.getMapaEntidadeByMapaEnum(mapaEnum, false);            

            level = mapaEntidade.getLevelByIndiceDezena(indiceLevel);
            logInfoLevel(indiceLevel);
        }        
        return level;
    }

    public static void pausarGame()
    {
        Time.timeScale = 0;
    }

    public static void continuarGame()
    {
        Time.timeScale = 1;
    }   

    private static void logInfoLevel(int indiceLevel)
    {
        if (level == null)
        {
            Debug.LogError("LEVEL " + indiceLevel + " NAO EXISTE NO INDICE MAPA " + (mapaEntidade == null ? "MAPA INEXISTENTE": mapaEntidade.ToString()));
        }
    }
}
