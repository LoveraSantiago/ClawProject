using UnityEngine;

public class ContextoEstaticoUtils 
{
    public static MonoBehaviour MonoBehaviour { get; private set; }
    public static MapaEntidade MapaEntidade { get; private set; }
    private static AbstractLevel Level;

    public static void configMainMono(MonoBehaviour monoBehaviour)
    {
        MonoBehaviour = monoBehaviour;
    }

    public static void configMainMapaEntidade(MapaEntidade mapaEntidade, AbstractLevel level)
    {
        MapaEntidade = mapaEntidade;
        Level = level;
    }

    public static AbstractLevel loadResetLevelEstaticoOrCreateLevel(int indiceMapa, int indiceLevel)
    {
        if(Level == null)
        {
            MapaEntidade = HelperMapaEntidade.getMapaEntidadeByIndice(indiceMapa);
            Level = MapaEntidade.getLevel(indiceLevel);            
        }

        AbstractLevel levelAtual = Level;
        Level = null;
        return levelAtual;
    }
}
