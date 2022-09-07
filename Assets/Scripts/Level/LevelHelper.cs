public class LevelHelper
{
    public static int getIndiceMapaNormalLiberado()
    {
        return PlayerPrefsMapas.getIndiceMapaLiberado();
    }

    public static int getTotalLevelsDosMapasNormaisLiberados()
    {
        return getIndiceMapaNormalLiberado() * 10;
    }

    public static AbstractLevel getLevelNormalByIndicesTotaisDeLevels(int indice)
    {        
        int indiceLevel = (indice + 1) % 11;
        MapaEntidade mapaEntidade = getMapaNormalByIndicesTotasDeLevels(indice);
        return mapaEntidade.getLevel(indiceLevel);        
    }

    public static MapaEntidade getMapaNormalByIndicesTotasDeLevels(int indice)
    {
        int indiceMapaEntidade = (indice) / 10;
        MapaEnum mapaEnum = Mapas.getMapaNormalEnumPeloIndice(indiceMapaEntidade);
        MapaEntidade mapaEntidade = HelperMapaEntidade.getMapaEntidadeByMapaEnum(mapaEnum);
        return mapaEntidade;
    }           
}
