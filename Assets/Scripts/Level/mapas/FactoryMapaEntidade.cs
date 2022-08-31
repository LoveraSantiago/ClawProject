public class FactoryMapaEntidade 
{
    public static MapaEntidade getMapaEntidadeByMapaEnum(MapaEnum mapaEnum)
    {
        switch (mapaEnum)
        {
            case MapaEnum.DEFAULTS:  return new MapaEntidade(0, "");
            case MapaEnum.FRUTAS:    return new MapaEntidade(1, "frutas");
            case MapaEnum.DINO:      return new MapaEntidade(2, "dinos");
            case MapaEnum.BOLAS:     return new MapaEntidade(3, "bolas");
            case MapaEnum.FALLGUYS:  return new MapaEntidade(4, "fg");
            case MapaEnum.YUYU:      return new MapaEntidade(5, "yuyu");
            case MapaEnum.GELEIA:    return new MapaEntidade(6, "geleia");
            case MapaEnum.MARIO:     return new MapaEntidade(7, "mario");
            case MapaEnum.MEGAMAN:   return new MapaEntidade(8, "megaman");
            case MapaEnum.COGUMELOS: return new MapaEntidade(9, "cogumelos");
            case MapaEnum.POOPS:     return new MapaEntidade(10, "poops");
        }
        return null;
    }
}
