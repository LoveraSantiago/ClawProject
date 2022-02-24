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
        //TODO FAZER HIERARQUIA DE LEVELSFILTERS
        //ADICIONAR UM FILTER P ALLLEVELS
        return null;
    }

    public static List<string> getNormalLevelsAlias()
    {
        FilterLevels filterLevels = new FilterLevelsNormal();
        return filterLevels.getLevelsAlias(poolLevels);        
    }

    public static List<string> getElevadorLevelsAlias()
    {
        FilterLevels filterLevels = new FilterLevelsElevador();
        return filterLevels.getLevelsAlias(poolLevels);        
    }

    public static List<string> getObstaculoLevelsAlias()
    {
        FilterLevels filterLevels = new FilterLevelsObstaculos();
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
