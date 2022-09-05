using System.Collections.Generic;

public class LevelHelper
{
    private static GenericPool<string, LevelEntidade> poolLevels = inicializarDicionarioDeEnum();   

    public static int getTotalNormalLevels()
    {
        return Mapas.getNormalMapas().Length * 10;
    }

    public static AbstractLevel getNormalLevelByIndice(int indice)
    {
        int indiceMapaEntidade = (indice -1) / 10;
        int indiceLevel = indice % 10;

        MapaEnum mapaEnum = Mapas.getMapaNormalEnumPeloIndice(indiceMapaEntidade);
        MapaEntidade mapaEntidade = HelperMapaEntidade.getMapaEntidadeByMapaEnum(mapaEnum);
        return mapaEntidade.getLevel(indiceLevel);        
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

    public static List<string> geLevelsNaoObstaculosAlias()
    {
        return getLevelsFiltradosPor(new FilterLevelsAliasNormal());
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
