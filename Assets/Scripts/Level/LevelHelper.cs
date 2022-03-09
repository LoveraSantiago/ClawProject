using System.Collections.Generic;

public class LevelHelper
{
    private static GenericPool<string, LevelEntidade> poolLevels = inicializarDicionarioDeEnum();

    public static AbstractLevel getLevelByEnum(Level level)
    {
        LevelEntidade levelEntidade = poolLevels.getValor(level.ToString());
        return levelEntidade.supplierLevel.fornecer();
    }

    public static AbstractLevel getLevelByString(string level)
    {
        LevelEntidade levelEntidade = poolLevels.getValor(level);
        return levelEntidade.supplierLevel.fornecer();
    }

    public static List<string> getAllLevels()
    {
        return getLevelsFiltradosPor(new FilterLevelsAll());
    }

    public static List<string> getNormalLevelsAlias()
    {
        return getLevelsFiltradosPor(new FilterLevelsNormal());
    }

    public static List<string> getElevadorLevelsAlias()
    {
        return getLevelsFiltradosPor(new FilterLevelsElevador());
    }

    public static List<string> getObstaculoLevelsAlias()
    {
        return getLevelsFiltradosPor(new FilterLevelsObstaculos());
    }

    private static List<string> getLevelsFiltradosPor(FilterLevels filterLevels)
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
