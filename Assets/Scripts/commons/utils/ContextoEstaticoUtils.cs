using UnityEngine;

public class ContextoEstaticoUtils 
{
    public static MonoBehaviour MonoBehaviour { get; private set; }
    public static MapaEntidade MapaEntidade { get; private set; }
    public static AbstractLevel Level { get; private set; }

    public static void configMainMono(MonoBehaviour monoBehaviour)
    {
        MonoBehaviour = monoBehaviour;
    }

    public static void configMainMapaEntidade(MapaEntidade mapaEntidade, AbstractLevel level)
    {
        MapaEntidade = mapaEntidade;
        Level = level;
    }
}
