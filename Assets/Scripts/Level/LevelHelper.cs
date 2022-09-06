using System.Collections.Generic;

public class LevelHelper
{
    private static GenericPool<string, LevelEntidade> poolLevels = inicializarDicionarioDeEnum();       

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

    public static AbstractLevel getLevelByString(string level)
    {
        LevelEntidade levelEntidade = poolLevels.getValor(level);
        return levelEntidade.supplierLevel.fornecer();
    }

    public static List<string> getAllLevelsAlias()
    {
        return getLevelsFiltradosPor(new FilterLevelsAliasAll());
    }

    public static string[] getAllLevelsMapsAlias()
    {
        return getLevelsFiltradosPor(new FilterLevelsAliasMaps()).ToArray();
    }    

    public static List<string> getElevadorLevelsAlias()
    {
        return getLevelsFiltradosPor(new FilterLevelsAliasElevador());
    }

    public static List<string> getObstaculoLevelsAlias()
    {
        return getLevelsFiltradosPor(new FilterLevelsAliasObstaculos());
    }

    private static List<string> getLevelsFiltradosPor(FilterLevelsAlias filterLevels)
    {
        return filterLevels.getLevelsAlias(poolLevels);
    }

    private static GenericPool<string, LevelEntidade> inicializarDicionarioDeEnum()
    {
        GenericPool<string, LevelEntidade> dicionarioDeEnum = new GenericPool<string, LevelEntidade>();

        LevelEntidade[] levelsEntidades = LevelEntidade.getLevelsEntidades();
        for(int contador = 0; contador < levelsEntidades.Length; contador++)
        {
            LevelEntidade levelEntidade = levelsEntidades[contador];
            dicionarioDeEnum.addChaveValor(levelEntidade.level.ToString(), levelEntidade);
        }
        return dicionarioDeEnum;
    }  
}
