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
}
