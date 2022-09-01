public class FactoryMapaEntidade 
{
    public static MapaEntidade getMapaEntidadeByMapaEnum(MapaEnum mapaEnum)
    {
        switch (mapaEnum)
        {
            case MapaEnum.DEFAULTS:  return new MapaEntidade(0, "Parque de Diversoes", "");
            case MapaEnum.FRUTAS:    return new MapaEntidade(1, "Parque Jurassico", "frutas");
            case MapaEnum.DINO:      return new MapaEntidade(2, "X", "dinos");
            case MapaEnum.BOLAS:     return new MapaEntidade(3, "X", "bolas");
            case MapaEnum.FALLGUYS:  return new MapaEntidade(4, "X", "fg");
            case MapaEnum.YUYU:      return new MapaEntidade(5, "X", "yuyu");
            case MapaEnum.GELEIA:    return new MapaEntidade(6, "X", "geleia");
            case MapaEnum.MARIO:     return new MapaEntidade(7, "X", "mario");
            case MapaEnum.MEGAMAN:   return new MapaEntidade(8, "X", "megaman");
            case MapaEnum.COGUMELOS: return new MapaEntidade(9, "X", "cogumelos");
            case MapaEnum.POOPS:     return new MapaEntidade(10, "X", "poops");
        }
        return null;
    }

    public static MapaEntidade getMapaEntidadeByIndice(int indice)
    {
        MapaEnum mapaEnum = Mapas.getMapaEnumPeloIndice(indice);
        return getMapaEntidadeByMapaEnum(mapaEnum);
    }
}
