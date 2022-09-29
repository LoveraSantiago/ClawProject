using System.Collections.Generic;
using UnityEngine;

public class HelperMapaEntidade 
{
    private static Dictionary<MapaEnum, MapaEntidade> mapasEntidadesPorMapaEnum = new Dictionary<MapaEnum, MapaEntidade>();

    public static MapaEntidade getMapaEntidadeByMapaEnum(MapaEnum mapaEnum, bool loadLiberacao)
    {
        if (!mapasEntidadesPorMapaEnum.ContainsKey(mapaEnum))
        {
            mapasEntidadesPorMapaEnum.Add(mapaEnum, FactoryMapaEntidade.getMapaEntidadeByMapaEnum(mapaEnum, loadLiberacao));
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
}
