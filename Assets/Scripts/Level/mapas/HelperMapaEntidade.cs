using System.Collections.Generic;
using UnityEngine;

public class HelperMapaEntidade 
{
    private static Dictionary<MapaEnum, MapaEntidade> mapasEntidadesPorMapaEnum = new Dictionary<MapaEnum, MapaEntidade>();
    private static FactoryMapaEntidade factoryMapaEntidade = new FactoryMapaEntidade();

    public static MapaEntidade getMapaEntidadeByMapaEnum(MapaEnum mapaEnum, bool loadLiberacao)
    {
        if (!mapasEntidadesPorMapaEnum.ContainsKey(mapaEnum))
        {
            MapaEntidade mapaEntidade = factoryMapaEntidade.getMapaEntidadeByMapaEnum(mapaEnum, loadLiberacao);
            mapasEntidadesPorMapaEnum.Add(mapaEnum, mapaEntidade);
        }
        return mapasEntidadesPorMapaEnum[mapaEnum];
    }        

    public static MapaEntidade getMapaEntidadeByIndice(int indice, bool loadLiberacao)
    {
        MapaEnum mapaEnum = Mapas.getMapaTodosEnumPeloIndice(indice);
        return getMapaEntidadeByMapaEnum(mapaEnum, loadLiberacao);
    }

    public static MapaEntidade getMapaNormalByIndicesTotasDeLevels(int indice, bool loadLiberacao)
    {
        int indiceMapaEntidade = (indice) / 10;
        MapaEnum mapaEnum = Mapas.getMapaNormalEnumPeloIndice(indiceMapaEntidade);
        MapaEntidade mapaEntidade = getMapaEntidadeByMapaEnum(mapaEnum, loadLiberacao);
        Debug.Log("indice " + indice + " calculado " + indiceMapaEntidade + " mapa " + mapaEntidade);
        return mapaEntidade;
    }

    public static MapaEntidade[] getMapaEntidadesLiberados(int adicao, bool loadLiberacaoColetaveis)
    {
        return factoryMapaEntidade.getMapaEntidadesLiberados(adicao, loadLiberacaoColetaveis);
    }

    public static void configurar(PrefabLevelsDto prefabsLevelsDtoArg)
    {
        factoryMapaEntidade.configurar(prefabsLevelsDtoArg);
    }
}
