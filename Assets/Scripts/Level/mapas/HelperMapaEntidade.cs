using System.Collections.Generic;
using UnityEngine;

public class HelperMapaEntidade 
{
    private static Dictionary<MapaEnum, MapaEntidade> mapasEntidadesPorMapaEnum = new Dictionary<MapaEnum, MapaEntidade>();
    private static FactoryMapaEntidade factoryMapaEntidade = new FactoryMapaEntidade();

    public static MapaEntidade getMapaEntidadeByMapaEnum(MapaEnum mapaEnum)
    {
        if (!mapasEntidadesPorMapaEnum.ContainsKey(mapaEnum))
        {
            MapaEntidade mapaEntidade = factoryMapaEntidade.getMapaEntidadeByMapaEnum(mapaEnum);
            mapasEntidadesPorMapaEnum.Add(mapaEnum, mapaEntidade);
        }
        return mapasEntidadesPorMapaEnum[mapaEnum];
    }        

    public static MapaEntidade getMapaEntidadeByIndice(int indice)
    {
        MapaEnum mapaEnum = Mapas.getMapaTodosEnumPeloIndice(indice);
        return getMapaEntidadeByMapaEnum(mapaEnum);
    }

    public static MapaEntidade getMapaNormalByIndicesTotasDeLevels(int indice)
    {
        int indiceMapaEntidade = (indice) / 10;
        MapaEnum mapaEnum = Mapas.getMapaNormalEnumPeloIndice(indiceMapaEntidade);
        MapaEntidade mapaEntidade = getMapaEntidadeByMapaEnum(mapaEnum);
        Debug.Log("indice " + indice + " calculado " + indiceMapaEntidade + " mapa " + mapaEntidade);
        return mapaEntidade;
    }

    public static MapaEntidade[] getMapaEntidadesLiberados(int adicao)
    {
        return factoryMapaEntidade.getMapaEntidadesLiberados(adicao);
    }

    public static void configurar(PrefabLevelsDto prefabsLevelsDtoArg)
    {
        factoryMapaEntidade.configurar(prefabsLevelsDtoArg);
    }
}
