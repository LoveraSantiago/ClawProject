using System.Collections.Generic;

public class HelperMapaEntidade 
{
    private static Dictionary<MapaEnum, MapaEntidade> mapasEntidadesPorMapaEnum = new Dictionary<MapaEnum, MapaEntidade>();

    public static MapaEntidade getMapaEntidadeByMapaEnum(MapaEnum mapaEnum)
    {
        if (!mapasEntidadesPorMapaEnum.ContainsKey(mapaEnum))
        {
            mapasEntidadesPorMapaEnum.Add(mapaEnum, FactoryMapaEntidade.getMapaEntidadeByMapaEnum(mapaEnum));
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
        MapaEntidade mapaEntidade = HelperMapaEntidade.getMapaEntidadeByMapaEnum(mapaEnum);
        return mapaEntidade;
    }
}
